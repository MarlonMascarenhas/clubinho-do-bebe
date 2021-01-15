
namespace Infra.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Insert(TEntity entity);

        bool Delete(TEntity entity);

        TEntity GetById(int id);

        bool Update(TEntity entity);
    }
}