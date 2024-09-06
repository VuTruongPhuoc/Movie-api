namespace Movie.API.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task<T> InsertAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task<bool> DeleteAsync(object id);
        Task SaveAsync();

    }
}
