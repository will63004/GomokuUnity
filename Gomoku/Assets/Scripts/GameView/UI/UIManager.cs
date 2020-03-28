using GameCore.UI;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace GameView.UI
{
    public class UIManager : IUIManager
    {
        public async Task<T> LoadUIAsync<T>() where T : class
        {
            return await Addressables.LoadAssetAsync<T>("Assets/UI/UIPairRoom.prefab").Task;
        }

        public Task<T> UnloadUIAsync<T>() where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}