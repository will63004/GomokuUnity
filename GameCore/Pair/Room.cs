using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Pair
{
    public class Room
    {
        public string Name { get; set; }

        public Room(string roomName)
        {
            this.Name = roomName;
        }
    }
}
