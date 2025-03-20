using HospitalManagement.DataAccess.Repository.Contracts;

namespace HospitalManagement.DataAccess.Repository.Impements
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly HospitalContext context;

        public Repository(HospitalContext context)
        {
            this.context = context;
        }
        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById(long id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
