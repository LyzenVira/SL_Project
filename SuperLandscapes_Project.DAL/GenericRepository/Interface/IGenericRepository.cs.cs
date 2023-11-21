using SuperLandscapes_Project.DAL.Entities.Base;

namespace SuperLandscapes_Project.DAL.GenericRepository.Interface
{
    public interface IGenericRepository<TEntity> where
        TEntity  : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(Guid id);

    }
}
