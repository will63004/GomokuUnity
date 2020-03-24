using NUnit.Framework;
using GameCore.Pair;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Pair.Tests
{
    [TestFixture()]
    public class RoomTests
    {
        private Room room;

        [SetUp]
        public void SetUp()
        {
            room = new Room("Test");
        }

        private static IEnumerable<TestCaseData> AddPlayer()
        {
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true) });
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true), (2, true) });
            yield return new TestCaseData(new List<(ulong player, bool answer)>() { (1, true), (2, true), (3, false) });
        }

        [Test, TestCaseSource("AddPlayer")]
        public void AddPlayerTest(List<(ulong player, bool answer)> playerAndAnswers)
        {
            //Act
            bool[] expecteds = new bool[playerAndAnswers.Count];
            for (int i = 0; i < playerAndAnswers.Count; ++i)
                expecteds[i] = room.AddPlayer(playerAndAnswers[i].player);

            for (int i = 0; i < playerAndAnswers.Count; ++i)
                Assert.AreEqual(expecteds[i], playerAndAnswers[i].answer);
        }
    }
}