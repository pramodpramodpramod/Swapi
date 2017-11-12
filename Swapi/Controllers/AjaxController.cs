using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Swapi.Models;

namespace Swapi.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ContentResult Shuffle(int totalCards, string key)
        {
            var gameOptions = new Game();
            var playModel = new Play()
            {
                EndPointRoot = gameOptions.Endpoints.Single(e => e.Key == key),
                TotalCards = totalCards
            };
            var cards = Helper.GetArrayFromApi(playModel);
            var jsonString = JsonConvert.SerializeObject(cards);
            return new ContentResult { Content = jsonString, ContentType = "application/json" };
        }
    }
}