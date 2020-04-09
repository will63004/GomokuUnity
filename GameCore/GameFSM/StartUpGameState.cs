using GameCore.Scene;
using GameCore.UI;
using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class StartUpGameState : GameState
    {
        private IGameFSM gameFSM;
        private ISceneManager sceneManager;
        private IUIManager uiManager;

        public StartUpGameState(IGameFSM gameFSM, ISceneManager sceneManager, IUIManager uiManager)
        {
            this.gameFSM = gameFSM;
            this.sceneManager = sceneManager;
            this.uiManager = uiManager;
        }

        internal override async Task EnterAsync(eGameFSM curState)
        {
            await uiManager.LoadUIAsync<IUIStartUp>();

            await base.EnterAsync(curState);
        }

        internal override async Task ExitAsync()
        {
            await uiManager.UnloadUIAsync<IUIStartUp>();

            await base.ExitAsync();
        }
    }
}