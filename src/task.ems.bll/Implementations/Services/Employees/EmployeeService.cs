using task.ems.dal.Entities.Logs;
using task.ems.dal.Enums.Logs;

namespace task.ems.bll.Implementations.Services.Employees
{
    internal sealed class EmployeeService(
        IEmployeeRepository employeeRepository,
        ILogHistoryRepository logHistoryRepository,
        IUnitOfWork unitOfWork
    ) : IEmployeeService
    {
        public async Task<ResponseOf<CreateEmployeeResult>> CreateAsync(
            CreateEmployeeRequest request,
            CancellationToken cancellationToken
        )
        {
            var modifiedRows = 0;

            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            Employee employee = request;

            modifiedRows++;
            await employeeRepository.CreateAsync(employee, cancellationToken);

            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Employee,
                    TransactionType = TransactionType.Create,
                },
                cancellationToken
            );

            var success = await unitOfWork.SaveChangesAsync(modifiedRows, cancellationToken);
            if (success)
            {
                await transaction.CommitAsync(cancellationToken);
                return new() { Message = "success", Result = employee };
            }
            await transaction.RollbackAsync(cancellationToken);
            throw new ServiceException();
        }

        public async Task<Response> DeleteAsync(
            DeleteEmployeeRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var modifiedRows = 0;
            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            var employee = await employeeRepository.FindAsync(request.Id, cancellationToken);

            modifiedRows++;
            employeeRepository.Delete(employee);

            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Employee,
                    TransactionType = TransactionType.Delete,
                },
                cancellationToken
            );

            var success = await unitOfWork.SaveChangesAsync(modifiedRows, cancellationToken);

            if (success)
            {
                await transaction.CommitAsync(cancellationToken);
                return new Response();
            }
            await transaction.RollbackAsync(cancellationToken);
            throw new ServiceException();
        }

        public async Task<ResponseOf<EmployeeDto>> GetAsync(
            GetEmployeeRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var employee = await employeeRepository.GetByIdAsync(request.Id, cancellationToken);
            return new() { Message = "success", Result = employee };
        }

        public async Task<PaginationResponse<IEnumerable<EmployeeDto>>> PaginateAsync(
            PaginateEmployeesRequest request,
            CancellationToken cancellationToken = default
        )
        {
            int totalCount = await employeeRepository.CountAsync(cancellationToken);

            var employees = await employeeRepository.PaginateAsync(
                request.PageIndex,
                request.PageSize,
                request.name,
                request.departMent,
                request.Status,
                request.fromDate,
                request.toDate,
                request.SortDirection,
                cancellationToken
            );
            return new()
            {
                Count = employees.Count,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Result = employees.Select(e => (EmployeeDto)e),
            };
        }

        public async Task<ResponseOf<UpdateEmployeeResult>> UpdateAsync(
            UpdateEmployeeRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var modifiedRows = 0;
            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            var employee = await employeeRepository.FindAsync(request.Id, cancellationToken);
            employee.Update(
                request.Name,
                request.Email,
                request.HireDate,
                request.Status,
                request.DepartmentId
            );
            modifiedRows++;

            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Employee,
                    TransactionType = TransactionType.Update,
                },
                cancellationToken
            );

            var success = await unitOfWork.SaveChangesAsync(modifiedRows, cancellationToken);
            if (success)
            {
                await transaction.CommitAsync(cancellationToken);
                return new() { Message = "success", Result = employee };
            }
            await transaction.RollbackAsync(cancellationToken);
            throw new ServiceException();
        }
    }
}
