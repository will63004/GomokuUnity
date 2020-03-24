using System;
using System.Collections.Generic;

namespace GameCore.Pair
{
    public class RoomManager
    {
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        public bool CreateSpaceRoom(string roomName, out int id)
        {
            Room room = new Room(roomName);
            id = room.GetHashCode();
            return rooms.TryAdd(id, room);
        }

        public bool TryGetRoom(int id, out Room room)
        {
            return rooms.TryGetValue(id, out room);
        }
    }
}
