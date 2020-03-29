using System.Threading.Tasks;

namespace GameCore.Table
{
    public interface ITableLoader
    {
        Task LoadAllTableAsync();
        T GetTable<T>() where T : class, ITable;
        Task<T> GetTableAsync<T>() where T : class, ITable;
    }
}
