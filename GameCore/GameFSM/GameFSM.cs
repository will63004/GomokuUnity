using GameCore.Pair;
using GameCore.Scene;
using GameCore.UI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCore.GameFSM
{
    public class GameFSM : IGameFSM
    {
        private IReadOnlyDictionary<eGameFSM, GameState> states;

        private eGameFSM CurState { get; } = eGameFSM.Default;

        public GameFSM(ISceneManager sceneManager, IUIManager uiManager, IRoomManager roomManager)
        {
            var states = new Dictionary<eGameFSM, GameState>();
            states.Add(eGameFSM.Default, new DefaultGameState(this));
            states.Add(eGameFSM.StartUp, new StartUpGameState(this, sceneManager, uiManager));
            states.Add(eGameFSM.Login, new LoginGameState(this, roomManager));
            states.Add(eGameFSM.PairRoom, new PairRoomState(this, uiManager));
            this.states = states;
        }

        public async Task ChangeFSMAsync(eGameFSM to)
        {
            await states[CurState].ExitAsync();

            if (states.TryGetValue(to, out GameState gameState))
                await gameState.EnterAsync(CurState);
            else
                throw new Exception("Changed to invalid GameState");
        }
    }
}
