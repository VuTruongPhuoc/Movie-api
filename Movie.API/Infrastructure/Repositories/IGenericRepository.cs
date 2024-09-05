namespace Movie.API.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<bool> InsertAsync(T Entity);
        Task<bool> UpdateAsync(T Entity);
        Task<bool> DeleteAsync(object id);
        Task SaveChangeAsync();

    }
}
