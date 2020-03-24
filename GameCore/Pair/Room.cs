using System;
using System.Collections.Generic;

namespace GameCore.Pair
{
    public class Room
    {
        public const int MaxPlayerAmount = 2;

        public string Name { get; private set; }
        private List<ulong> players = new List<ulong>();
        public IReadOnlyList<ulong> Players { get => players; }

        public Room(string roomName)
        {
            this.Name = roomName;
        }

        public bool AddPlayer(ulong playerId)
        {
            if (players.Count >= MaxPlayerAmount)
                return false;

            players.Add(playerId);
            return true;
        }
    }
}
