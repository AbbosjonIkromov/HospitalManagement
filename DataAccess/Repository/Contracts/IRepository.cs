namespace HospitalManagement.DataAccess.Repository.Contracts
{
    public interface IRepository<TEntity> 
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(long id);

        Task<TEntity> GetByIdAsync(long id);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
