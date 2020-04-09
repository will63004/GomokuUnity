using GameCore.UI;
using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class PairRoomState : GameState
    {
        private readonly IGameFSM gameFSM;
        private readonly IUIManager uiManager;

        public PairRoomState(IGameFSM gameFSM, IUIManager uiManager)
        {
            this.gameFSM = gameFSM;
            this.uiManager = uiManager;
        }

        internal override async Task EnterAsync(eGameFSM curState)
        {
            await uiManager.LoadUIAsync<IUIRoomPair>();

            await base.EnterAsync(curState);
        }

        internal override async Task ExitAsync()
        {
            await uiManager.UnloadUIAsync<IUIRoomPair>();

            await base.ExitAsync();
        }
    }
}