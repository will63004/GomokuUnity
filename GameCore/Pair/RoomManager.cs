using System.Collections.Generic;
using System.Linq;

namespace GameCore.Pair
{
    public class RoomManager
    {
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        public bool CreateSpaceRoom(string roomName, out int roomId)
        {
            Room room = new Room(roomName);
            roomId = room.GetHashCode();
            return rooms.TryAdd(roomId, room);
        }

        public bool TryGetRoom(int roomId, out Room room)
        {
            return rooms.TryGetValue(roomId, out room);
        }

        public IList<Room> GetRooms()
        {
            return rooms.Values.ToList();
        }

        public bool EnterRoom(int roomId, ulong playerId)
        {
            if (rooms.TryGetValue(roomId, out Room room))
            {
                return room.AddPlayer(playerId);
            }
            else
                return false;
        }
    }
}
