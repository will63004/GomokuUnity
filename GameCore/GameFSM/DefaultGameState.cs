using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class DefaultGameState : GameState
    {
        private IGameFSM gameFSM;

        public DefaultGameState(IGameFSM gameFSM)
        {
            this.gameFSM = gameFSM;
        }

        internal override async Task EnterAsync(eGameFSM curState)
        {
            await base.EnterAsync(curState);
        }

        internal override async Task ExitAsync()
        {
            await base.ExitAsync();
        }
    }
}