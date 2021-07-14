using Entities.POCOEntities.BaseEntity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.IRepositories
{
    public interface IRepositories<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int ID);

        ValueTask<TEntity> Get(int id);

        Task<List<TEntity>> GetAll();

        IQueryable<TEntity> GetQuery();
    }
}
