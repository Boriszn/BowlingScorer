using System;
using System.Collections.Generic;
using BowlingGame.BLL;
using BowlingGame.BLL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGame.Tests
{
    [TestClass]
    public class GameCalculatorTests
    {
        private readonly GameCalculator _gameCalculator;

        public GameCalculatorTests()
        {
            _gameCalculator = new GameCalculator();
        }

        [TestMethod]
        public void BuildScore_LastResult_Test()
        {
            var bowlingGame = new BowlingGameModel
                {
                    Frames = new List<Frame> {
                            new Frame
                                {
                                    Pins = new []{ 1, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 4, 5 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 6, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 5, 5 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 0, 1 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 7, 3 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 6, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 2, 8, 6 }
                                }
                        }
                };

          var scoreResult =  _gameCalculator.BuildScore(bowlingGame);

          Assert.AreEqual(133, scoreResult);
        }

        [TestMethod]
        public void BuildScore_All_Strikes_Test()
        {
            var bowlingGame = new BowlingGameModel
            {
                Frames = new List<Frame>
                        {
                            new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10, 10 }
                                }
                        }
            };

            var scoreResult = _gameCalculator.BuildScore(bowlingGame);

            Assert.AreEqual(300, scoreResult);
        }

        [TestMethod]
        public void BuildScore_FirstValue_Test()
        {
            var bowlingGame = new BowlingGameModel
            {
                Frames = new List<Frame>
                        {
                            new Frame
                                {
                                    Pins = new []{ 1, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 4, 5 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 6, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 5, 5 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 0, 1 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 7, 3 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 6, 4 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 10, 10 }
                                },
                                 new Frame
                                {
                                    Pins = new []{ 2, 8, 6 }
                                }
                        }
            };

            var scoreResult = _gameCalculator.BuildScore(bowlingGame);

            Assert.AreEqual(5, bowlingGame.Frames[0].Score);
        }

        [TestMethod]
        public void BuildScore_AllValues_Success_Test()
        {
            var bowlingGame = new BowlingGameModel
                {
                    Frames = new List<Frame>
                        {
                            new Frame
                                {
                                    Pins = new[] {1, 4}
                                },
                            new Frame
                                {
                                    Pins = new[] {4, 5}
                                },
                            new Frame
                                {
                                    Pins = new[] {6, 4}
                                },
                            new Frame
                                {
                                    Pins = new[] {5, 5}
                                },
                            new Frame
                                {
                                    Pins = new[] {10, 10}
                                },
                            new Frame
                                {
                                    Pins = new[] {0, 1}
                                },
                            new Frame
                                {
                                    Pins = new[] {7, 3}
                                },
                            new Frame
                                {
                                    Pins = new[] {6, 4}
                                },
                            new Frame
                                {
                                    Pins = new[] {10, 10}
                                },
                            new Frame
                                {
                                    Pins = new[] {2, 8, 6}
                                }
                        }
                };

            var scoreResult = _gameCalculator.BuildScore(bowlingGame);

            Assert.AreEqual(5, bowlingGame.Frames[0].Score);

            Assert.AreEqual(14, bowlingGame.Frames[1].Score);

            Assert.AreEqual(29, bowlingGame.Frames[2].Score);

            Assert.AreEqual(49, bowlingGame.Frames[3].Score);

            Assert.AreEqual(60, bowlingGame.Frames[4].Score);

            Assert.AreEqual(61, bowlingGame.Frames[5].Score);

            Assert.AreEqual(77, bowlingGame.Frames[6].Score);

            Assert.AreEqual(97, bowlingGame.Frames[7].Score);

            Assert.AreEqual(117, bowlingGame.Frames[8].Score);

            Assert.AreEqual(133, bowlingGame.Frames[9].Score);

            Assert.AreEqual(133, scoreResult);

        }

    }
}
