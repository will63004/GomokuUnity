using GameCore.Pair;
using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    internal class LoginGameState : GameState
    {
        private readonly IGameFSM gameFSM;
        private readonly IRoomManager roomManager;

        public LoginGameState(IGameFSM gameFSM, IRoomManager roomManager)
        {
            this.gameFSM = gameFSM;
            this.roomManager = roomManager;
        }

        internal override async Task EnterAsync(eGameFSM curState)
        {
            //TODO 連接Server獲得房間資料
            roomManager.CreateSpaceRoom("First", out int _);
            roomManager.CreateSpaceRoom("Second", out int _);

            await base.EnterAsync(curState);

            await gameFSM.ChangeFSMAsync(eGameFSM.PairRoom);
        }
    }
}