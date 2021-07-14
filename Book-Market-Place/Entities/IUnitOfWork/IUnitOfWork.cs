using System.Threading.Tasks;

namespace Entities.IUnitOfWork
{
    public interface IUnitOfWork
    {
        Task Save();

    }
}
