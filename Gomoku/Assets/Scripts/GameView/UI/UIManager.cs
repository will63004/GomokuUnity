using GameCore.Scene;
using GameCore.UI;
using GameView.Scene;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Table;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameView.UI
{
    public class UIManager : IUIManager
    {
        private UIConsole UIConsole { get; set; }
        private IUIPath UIPath { get; }
        private SceneManagerAdapter SceneManager { get; }

        private Dictionary<Type, GameObject> UIs { get; set; } = new Dictionary<Type, GameObject>();

        public UIManager(IUIPath uiPath, SceneManagerAdapter sceneManager)
        {
            UIPath = uiPath;
            SceneManager = sceneManager;
        }

        public async Task Init()
        {
            await SceneManager.LoadSceneAsync(eScene.UI);
            UIConsole = GameObject.FindObjectOfType(typeof(UIConsole)) as UIConsole;
        }

        public async Task<T> LoadUIAsync<T>() where T : class
        {
            string path = UIPath.GetPath<T>();
            GameObject go = await Addressables.LoadAssetAsync<GameObject>(path).Task;
            go = MonoBehaviour.Instantiate(go);
            UIConsole.InsertUI(go.transform);
            T ui = go.GetComponent<T>();
            UIs.Add(typeof(T), go);
            return ui;
        }

        public async Task UnloadUIAsync<T>() where T : class
        {
            if (UIs.TryGetValue(typeof(T), out GameObject ui))
            {
                MonoBehaviour.Destroy(ui);
            }

            await Task.CompletedTask;
        }
    }
}