using System.Collections.Generic;
using System.Linq;
using BowlingGame.BLL.Model;
using Frame = BowlingGame.Web.Models.Frame;

namespace BowlingGame.Web.Controllers
{
    public class ModelMapper
    {
        public static IEnumerable<Frame> MapGameLogicModelToViewModel(BowlingGameModel bowlingGameModel)
        {
            var resultGameView = bowlingGameModel.Frames.Select(r => new Frame
                {
                    PinFirst = r.Pins[0],
                    PinSecond = r.Pins[1],
                    PinExtra = (r.Pins.Count() > 2 ? r.Pins[2] : (int?) null),
                    Score = r.Score
                });
            return resultGameView;
        }

        public static BowlingGameModel MapViewModelToGameLogicModel(IEnumerable<Frame> data)
        {
            var bowlingGameModel = new BowlingGameModel
                {
                    Frames = data.Select(e => new BLL.Model.Frame {
                            Pins = MapPinArray(e),
                        }).ToList()
                };

            return bowlingGameModel;
        }

        private static int[] MapPinArray(Frame e)
        {
            int[] pinsArray;

            if (e.PinExtra != null)
            {
                pinsArray = new[]
                    {
                        (e.PinFirst.HasValue ? e.PinFirst.Value : 0),
                        (e.PinSecond.HasValue ? e.PinSecond.Value : 0),
                        (e.PinExtra.Value)
                    };
            }
            else
            {
                pinsArray = new[]
                    {
                        (e.PinFirst.HasValue ? e.PinFirst.Value : 0),
                        (e.PinSecond.HasValue ? e.PinSecond.Value : 0)
                    };
            }

            return pinsArray;
        }
    }
}