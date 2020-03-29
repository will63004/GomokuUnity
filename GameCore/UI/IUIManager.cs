using System.Threading.Tasks;

namespace GameCore.UI
{
    public interface IUIManager
    {
        Task<T> LoadUIAsync<T>() where T : class;
        Task UnloadUIAsync<T>() where T : class;
    }
}