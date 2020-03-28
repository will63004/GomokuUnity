using GameCore.Scene;
using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class StartUpGameState : GameState
    {
        private IGameFSM gameFSM;
        private ISceneManager sceneManager;

        public StartUpGameState(IGameFSM gameFSM, ISceneManager sceneManager)
        {
            this.gameFSM = gameFSM;
            this.sceneManager = sceneManager;
        }

        internal override async Task EnterAsync(eGameFSM curState)
        {
            await sceneManager.LoadSceneAsync(eScene.StartUp);
        }
    }
}