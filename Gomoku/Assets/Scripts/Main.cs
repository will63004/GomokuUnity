using GameCore.DI;
using GameCore.GameFSM;
using GameView.Scene;
using UnityEngine;

public class Main : MonoBehaviour
{
    private async void Awake()
    {
        var sceneManager = new SceneManagerAdapter();
        TempDI.SceneManager = sceneManager;

        var gameFSM = new GameFSM(sceneManager, null);
        TempDI.GameFSM = gameFSM;

        await gameFSM.ChangeFSMAsync(eGameFSM.StartUp);
    }
}
