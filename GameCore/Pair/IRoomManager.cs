using System.Collections.Generic;

namespace GameCore.Pair
{
    public interface IRoomManager
    {
        bool CreateSpaceRoom(string roomName, out int roomId);
        bool TryGetRoom(int roomId, out Room room);
        IList<Room> GetRooms();
        bool EnterRoom(int roomId, ulong playerId);
    }
}