using GameCore.DI;
using GameCore.GameFSM;
using GameCore.Pair;
using GameView.Scene;
using GameView.UI;
using Table;
using UnityEngine;

public class Main : MonoBehaviour
{
    private async void Awake()
    {
        var tableLoader = new TableLoader();
        await tableLoader.LoadAllTableAsync();
        TempDI.TableLoader = tableLoader;

        var sceneManager = new SceneManagerAdapter();
        TempDI.SceneManager = sceneManager;

        var uiManager = new UIManager(tableLoader.GetTable<IUIPath>(), sceneManager);
        TempDI.UIManager = uiManager;
        await uiManager.Init();

        var roomManager = new RoomManager();
        TempDI.RoomManager = roomManager;

        var gameFSM = new GameFSM(sceneManager, uiManager, roomManager);
        TempDI.GameFSM = gameFSM;

        await gameFSM.ChangeFSMAsync(eGameFSM.StartUp);
    }
}
