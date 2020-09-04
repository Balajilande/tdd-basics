using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameTest
    {
        private Game g;

        public GameTest()
        {
            g = new Game();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        private void rollSpare()
        {
            g.Roll(6);
            g.Roll(4);
        }
        
        [Fact]
        public void Test_GutterGame()
        {
            rollMany(20, 0);
            Assert.Equal(0, g.GetScore());
        }

        [Fact]
        public void Test_AllOnes()
        {
            rollMany(20, 1);
            Assert.Equal(20, g.GetScore());
        }

        [Fact]
        public void Test_OneSpare()
        {
            rollSpare();
            g.Roll(4);
            rollMany(17, 0);
            Assert.Equal(18, g.GetScore());
        }

        [Fact]
        public void Test_OneStrike()
        {
            g.Roll(10);
            g.Roll(4);
            g.Roll(5);
            rollMany(17, 0);
            Assert.Equal(28, g.GetScore());
        }

        [Fact]
        public void Test_PerfectGame()
        {
            rollMany(12, 10);
            Assert.Equal(300, g.GetScore());
        }

        [Fact]
        public void Test_RandomGameWithThreeStrikesAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 10, 10, 10 });
            Assert.Equal(163, g.GetScore());
        }

        [Fact]
        public void Test_RandomGameWithSpareThenStrikeAtEnd()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 1, 10 });
            Assert.Equal(143, g.GetScore());
        }

        [Fact]
        public void Test_RandomGameNoExtraRoll()
        {
            g.Roll(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Assert.Equal(131, g.GetScore());
        }

        [Fact]
        public void Test_BowlingGameClass()
        {
            Assert.IsType<Game>(g);
        }
    }
}
