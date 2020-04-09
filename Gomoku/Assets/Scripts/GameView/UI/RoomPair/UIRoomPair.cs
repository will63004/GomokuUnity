using GameCore.DI;
using GameCore.Pair;
using GameCore.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI.RoomPair 
{
    public class UIRoomPair : MonoBehaviour, IUIRoomPair
    {
        [SerializeField]
        private Text roomName;

        [SerializeField]
        private Rooms rooms;

        private IRoomManager roomManager;

        private void Awake()
        {
            roomManager = TempDI.RoomManager;
        }

        public void Refresh()
        {
            rooms.Refresh(roomManager.GetRooms());
            //roomName.text
        }
    }
}


