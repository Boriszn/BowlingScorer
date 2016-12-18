using System.Collections.Generic;
using System.Web.Mvc;
using BowlingGame.BLL;
using Frame = BowlingGame.Web.Models.Frame;

namespace BowlingGame.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly GameCalculator _gameCalculator;

        public DataController()
        {
           _gameCalculator = new GameCalculator();
        }

        [HttpPost]
        public ActionResult Index(List<Frame> viewModelData)
        {
            var bowlingGameModel = ModelMapper.MapViewModelToGameLogicModel(viewModelData);
            _gameCalculator.BuildScore(bowlingGameModel);
            return Json(ModelMapper.MapGameLogicModelToViewModel(bowlingGameModel));
        }
    }
}
