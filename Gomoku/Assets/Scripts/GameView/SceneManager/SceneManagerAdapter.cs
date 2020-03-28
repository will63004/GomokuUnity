using GameCore.Scene;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameView.Scene
{
    public class SceneManagerAdapter : ISceneManager
    {
        public async Task LoadSceneAsync(eScene scene, eLoadSceneMode mode = eLoadSceneMode.Single)
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)scene, (LoadSceneMode)mode);
            while (!asyncOperation.isDone) 
            {
                await Task.Yield();
            }

            await Task.CompletedTask;
        }
    }
}