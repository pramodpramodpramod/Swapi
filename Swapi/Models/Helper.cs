using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Swapi.Models
{
    public static class Helper
    {
        internal static dynamic GetArrayFromApi(Play play)
        {
            List<dynamic> cards = new List<dynamic>();
            while (cards.Count < play.TotalCards)
            {
                using (WebClient wc = new WebClient())
                {
                    var jsonStr = wc.DownloadString(play.EndPointRoot.RootUrl);
                    dynamic json = JObject.Parse(jsonStr);
                    foreach (var item in json.results)
                    {
                        if (cards.Count < play.TotalCards)
                            cards.Add(item);
                        else
                            break;
                    }
                }
            }
            return cards.OrderBy(a => Guid.NewGuid()).ToList(); ;
        }
    }
}