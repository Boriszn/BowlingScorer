using System;
using System.Collections.Generic;
using BowlingGame.BLL.Model;

namespace BowlingGame.BLL
{
    public class GameCalculator
    {
        private const int FrameMaxPins = 10;

        public int BuildScore(BowlingGameModel bowlingGameModel)
        {
            int scoreResult = 0;

            for (int index = 0; index < bowlingGameModel.Frames.Count; index++)
            {
                var frames = bowlingGameModel.Frames;
                var currentFrame = frames[index];

                //Strike check
                if (IsStrike(currentFrame))
                {
                    scoreResult += CalculateScore(
                        //Calculation strategy of Strike case for on Frame 10
                        (currentFrame1) => (FrameMaxPins + currentFrame1.Pins[1] + currentFrame1.Pins[2]),
                        //Calculation strategy of Strike case for all Frames
                        (frames1, currIndex) => (FrameMaxPins + frames1[currIndex + 1].Pins[0] + frames1[currIndex + 1].Pins[1]),
                        currentFrame, frames, index);
                }
                //Spare check
                else if (IsSpare(currentFrame))
                {
                    scoreResult += CalculateScore(
                        //Calculation strategy of Spare case for  on Frame 10
                        (currentFrame1) => (10 + currentFrame.Pins[2]),
                        //Calculation strategy of Spare case for all Frames 
                        (frames1, currIndex) => (10 + frames1[currIndex + 1].Pins[0]),
                        currentFrame, frames, index);
                }
                else
                {
                    scoreResult += currentFrame.Pins[0] + currentFrame.Pins[1];
                }

                currentFrame.Score = scoreResult;
            }

            return scoreResult;
        }

        private static int CalculateScore(Func<Frame, int> calculationStrategyFor10Frame, 
            Func<List<Frame>, int, int> calculationStrategyForAllFrames, 
            Frame currentFrame, List<Frame> frames, int currentIndex)
        {
             return (currentFrame.Pins.Length > 2)
                ?
                (calculationStrategyFor10Frame(currentFrame))
                :
                (calculationStrategyForAllFrames(frames, currentIndex));
        }

        private static bool IsSpare(Frame currentFrame)
        {
            return currentFrame.Pins[0] + currentFrame.Pins[1] == 10;
        }

        private static bool IsStrike(Frame currentFrame)
        {
            return currentFrame.Pins[0] == FrameMaxPins;
        }
    }
}
