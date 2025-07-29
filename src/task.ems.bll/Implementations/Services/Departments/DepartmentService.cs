using task.ems.bll.Abstractions.Services.Departments;
using task.ems.dal.Entities.Logs;
using task.ems.dal.Enums.Logs;

namespace task.ems.bll.Implementations.Services.Departments
{
    internal sealed class DepartmentService(
        IDepartmentRepository departmentRepository,
        ILogHistoryRepository logHistoryRepository,
        IUnitOfWork unitOfWork
    ) : IDepartmentService
    {
        public async Task<ResponseOf<CreateDepartmentResult>> CreateAsync(
            CreateDepartmentRequest request,
            CancellationToken cancellationToken
        )
        {
            var modifiedRows = 0;

            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            Department department = request;

            modifiedRows++;
            await departmentRepository.CreateAsync(department, cancellationToken);
            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Department,
                    TransactionType = TransactionType.Create,
                },
                cancellationToken
            );
            var success = await unitOfWork.SaveChangesAsync(modifiedRows, cancellationToken);
            if (success)
            {
                await transaction.CommitAsync(cancellationToken);
                return new() { Message = "success", Result = department };
            }
            await transaction.RollbackAsync(cancellationToken);
            throw new ServiceException();
        }

        public async Task<Response> DeleteAsync(
            DeleteDepartmentRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var modifiedRows = 0;
            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            var department = await departmentRepository.FindAsync(request.Id, cancellationToken);

            modifiedRows++;
            departmentRepository.Delete(department);

            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Department,
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

        public async Task<ResponseOf<DepartmentDto>> GetAsync(
            GetDepartmentRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var department = await departmentRepository.GetByIdAsync(request.Id, cancellationToken);
            return new() { Message = "success", Result = department };
        }

        public async Task<PaginationResponse<IEnumerable<PaginateDepartmentDto>>> PaginateAsync(
            PaginateDepartmentsRequest request,
            CancellationToken cancellationToken = default
        )
        {
            int totalCount = await departmentRepository.CountAsync(cancellationToken);

            var departments = await departmentRepository.PaginateAsync(
                request.PageIndex,
                request.PageSize,
                request.search,
                request.SortDirection,
                cancellationToken
            );
            return new()
            {
                Count = departments.Count,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Result = departments.Select(e => (PaginateDepartmentDto)e),
            };
        }

        public async Task<ResponseOf<UpdateDepartmentResult>> UpdateAsync(
            UpdateDepartmentRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var modifiedRows = 0;
            await using var transaction = await unitOfWork.BeginTransactionAsync(cancellationToken);
            var department = await departmentRepository.FindAsync(request.Id, cancellationToken);
            department.Update(request.Name, request.ManagerId);
            modifiedRows++;

            modifiedRows++;
            await logHistoryRepository.CreateAsync(
                new LogHistory
                {
                    EntityType = EntityType.Department,
                    TransactionType = TransactionType.Update,
                },
                cancellationToken
            );

            var success = await unitOfWork.SaveChangesAsync(modifiedRows, cancellationToken);
            if (success)
            {
                await transaction.CommitAsync(cancellationToken);
                return new() { Message = "success", Result = department };
            }
            await transaction.RollbackAsync(cancellationToken);
            throw new ServiceException();
        }
    }
}
