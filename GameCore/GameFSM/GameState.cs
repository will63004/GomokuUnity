using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class GameState
    {
        protected eGameFSM CurState { get; set; }

        internal virtual async Task ExitAsync()
        {
            await Task.CompletedTask;
        }

        internal virtual async Task EnterAsync(eGameFSM curState)
        {
            await Task.CompletedTask;
        }
    }
}