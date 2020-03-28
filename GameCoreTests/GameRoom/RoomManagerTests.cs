using GameCore.Pair;
using NUnit.Framework;
using System.Collections.Generic;

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
            bool ok = CreateOneRoom(roomName, out int id);

            Assert.AreEqual(ok, true);
            Assert.IsTrue(roomManager.TryGetRoom(id, out Room room));
            Assert.AreEqual(room.Name, roomName);
        }

        [Test]
        public void GetRoomsTest()
        {
            _ = CreateOneRoom("Room1", out _);

            _ = CreateOneRoom("Room2", out _);

            //Act
            IList<Room> rooms = roomManager.GetRooms();

            Assert.AreEqual(rooms.Count, 2);
        }

        [Test]
        public void EnterEmptyRoomTest()
        {
            //Act
            bool ok = roomManager.EnterRoom(1, 8763);

            Assert.AreEqual(ok, false);
        }

        [Test, TestCaseSource("EnterRoomMember")]
        public void EnterRoomTest(List<(ulong player, bool answer)> playerAndAnswers)
        {
            _ = CreateOneRoom("Room1", out int id);

            //Act
            bool[] expecteds = new bool[playerAndAnswers.Count];
            for (int i = 0; i < playerAndAnswers.Count; ++i)
            {
                expecteds[i] = roomManager.EnterRoom(id, playerAndAnswers[i].player);
            }

            for (int i = 0; i < playerAndAnswers.Count; ++i)
                Assert.AreEqual(expecteds[i], playerAndAnswers[i].answer);
        }

        private static IEnumerable<TestCaseData> EnterRoomMember()
        {
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true) });
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true), (2, true) });
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true), (2, true), (3, false) });
        }

        private bool CreateOneRoom(string roomName, out int id)
        {
            return roomManager.CreateSpaceRoom(roomName, out id);
        }
    }
}