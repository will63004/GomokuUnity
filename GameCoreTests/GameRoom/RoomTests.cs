using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GameCore.Pair.Tests
{
    [TestClass()]
    public class RoomTests
    {
        private Room room;

        [TestInitialize]
        public void SetUp()
        {
            room = new Room("Test");
        }

        private static IEnumerable<object[]> AddPlayer()
        {
            yield return new object[] { new List<(ulong player, bool answer)>() { (1, true) } };
            yield return new object[] { new List<(ulong player, bool answer)>() { (1, true), (2, true) } };
            yield return new object[] { new List<(ulong player, bool answer)>() { (1, true), (2, true), (3, false) } };
        }

        [DataTestMethod]
        [DynamicData(nameof(AddPlayer), DynamicDataSourceType.Method)]
        public void AddPlayerTest(List<(ulong player, bool answer)> playerAndAnswers)
        {
            //Act
            bool[] expecteds = new bool[playerAndAnswers.Count];
            for (int i = 0; i < playerAndAnswers.Count; ++i)
                expecteds[i] = room.AddPlayer(playerAndAnswers[i].player);

            for (int i = 0; i < playerAndAnswers.Count; ++i)
                Assert.AreEqual(expecteds[i], playerAndAnswers[i].answer);
        }

        private static IEnumerable<object[]> GameStatusData()
        {
            yield return new object[] { new List<ulong>() { 1 } };
            yield return new object[] { new List<ulong>() { 1, 2 } };
        }
        [DataTestMethod]
        [DynamicData(nameof(GameStatusData), DynamicDataSourceType.Method)]
        public void GameStatusIdleTest(List<ulong> players)
        {
            //Act
            foreach (ulong player in players)
                room.AddPlayer(player);

            eGameStatus expected = room.GameStatus;

            Assert.AreEqual(expected, eGameStatus.Idle);
        }

        [DataTestMethod]
        [DynamicData(nameof(GameStatusData), DynamicDataSourceType.Method)]
        public void CanStartGame_GameStatusIdle_Test(List<ulong> players)
        {
            //Act
            foreach (ulong player in players)
                room.AddPlayer(player);

            //Assert
            Assert.AreEqual(room.CanStartGame, true);
        }
    }
}