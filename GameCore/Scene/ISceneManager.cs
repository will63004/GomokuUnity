using System.Threading.Tasks;

namespace GameCore.Scene
{
    public interface ISceneManager
    {
        Task LoadSceneAsync(eScene scene, eLoadSceneMode mode = eLoadSceneMode.Single);
    }
}