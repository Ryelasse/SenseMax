using Microsoft.Identity.Client;
using SenseMax;
namespace SenseRepositoryDB;

public interface IRepositoryDB<T>
{
    public IEnumerable<T> GetEntities();
    public T? GetEntityById(int id);
    public T? AddEntity(T t);
    public T? DeleteEntity(int id);
    public T? UpdateEntity(int id, T data);
}