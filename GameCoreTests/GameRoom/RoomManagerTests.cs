using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using GameCore.Pair;

namespace GameCore.GameRoom.Tests
{
    [TestFixture()]
    public class RoomManagerTests
    {
        private RoomManager roomManager;

        [SetUp]
        public void SetUp()
        {
            roomManager = new RoomManager();
        }

        [Test()]
        public void CreateRoomTest()
        {
            string roomName = "Justice";

            bool ok = roomManager.CreateSpaceRoom(roomName, out int id);

            Assert.AreEqual(ok, true);
            Assert.IsTrue(roomManager.TryGetRoom(id, out Room room));
            Assert.AreEqual(room.Name, roomName);
        }
    }
}