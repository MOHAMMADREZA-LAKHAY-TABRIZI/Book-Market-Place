using EF.Persistance.DataBase;
using Entities.IRepositories;
using Entities.POCOEntities.BaseEntity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Persistance.Repository
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : BaseEntity
    {
        private readonly BookMarketPlaceDBContex dbContext;

        public Repositories(BookMarketPlaceDBContex dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Delete(int ID)
        {
            var recordFound = dbContext.Find<TEntity>(ID);

            dbContext.Entry<TEntity>(recordFound).State = EntityState.Deleted;

            // dbContext.Set<TEntity>().Remove(recordFound);

        }

        public ValueTask<TEntity> Get(int ID)
        {
            var recordFound = dbContext.FindAsync<TEntity>(ID);

            return recordFound;

        }

        public Task<List<TEntity>> GetAll()
        {
            return dbContext.Set<TEntity>().ToListAsync<TEntity>();
        }

        public IQueryable<TEntity> GetQuery()
        {
            return dbContext.Set<TEntity>().AsQueryable<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            // dbContext.Set<TEntity>().Add(entity);

            dbContext.Entry<TEntity>(entity).State = EntityState.Added;

        }

        public void Update(TEntity entity)
        {

            //dbContext.Set<TEntity>().Update(entity);

            dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

        }
    }
}

