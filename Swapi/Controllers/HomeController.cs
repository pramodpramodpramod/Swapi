using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swapi.Models;

namespace Swapi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Game();
            return View(model);
        }

        [HttpPost]
        public ActionResult Play(Game gameOptions)
        {
            var playModel = new Play()
            {
                EndPointRoot = gameOptions.Endpoints.Single(e => e.Key == gameOptions.SelectedGame),
                TotalCards = gameOptions.TotalCards,
                WhoPlaysFirst = gameOptions.FirstPlayer
            };
            var cards = Helper.GetArrayFromApi(playModel);
            JavaScriptSerializer js = new JavaScriptSerializer();
            playModel.JsonEndPointRoot = js.Serialize(playModel.EndPointRoot);
            playModel.JsonFullDeck = JsonConvert.SerializeObject(cards);
            return View(playModel);
        }




    }
}