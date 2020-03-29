using GameCore.GameFSM;
using GameCore.Scene;
using GameCore.Table;
using GameCore.UI;

namespace GameCore.DI
{
    public static class TempDI
    {
        public static ISceneManager SceneManager { get; set; }

        public static IGameFSM GameFSM { get; set; }

        public static IUIManager UIManager { get; set; }

        public static ITableLoader TableLoader { get; set; }
    }
}
