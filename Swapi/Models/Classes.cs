using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Swapi.Models
{
    public class Game
    {
        public Game()
        {
            SetEndpointDefaults();
        }
        private string _baseUrl = "https://swapi.co/api/";

        [Display(Name = "Game")]
        public string SelectedGame { get; set; }
        public SelectList AvailableGames
        {
            get
            {
                return new SelectList(Endpoints, "Key", "Name");
            }
        }
        [Display(Name = "Who Plays First")]
        public int FirstPlayer { get; set; }

        [Display(Name = "Total Cards in Deck")]
        public int TotalCards { get; set; }
        public SelectList AvailableTotals
        {
            get
            {
                var totals = new List<int> { 4, 10, 20, 40 };
                return new SelectList(totals);
            }
        }
        public List<EndpointRoot> Endpoints { get; set; }

        public void SetEndpointDefaults()
        {
            var endpoints = new List<EndpointRoot>()
                {
                    new EndpointRoot(){Key = "films", Name="Films", RootUrl = $"{_baseUrl}films/", GameAttributes = GetGameAttributes("films") },
                    new EndpointRoot(){Key = "people", Name="People", RootUrl = $"{_baseUrl}people/", GameAttributes = GetGameAttributes("people") },
                    new EndpointRoot(){Key = "planets", Name="Planets", RootUrl = $"{_baseUrl}planets/", GameAttributes = GetGameAttributes("planets") },
                    new EndpointRoot(){Key = "species", Name="Species", RootUrl = $"{_baseUrl}species/", GameAttributes = GetGameAttributes("species") },
                    new EndpointRoot(){Key = "starships", Name="Starships", RootUrl = $"{_baseUrl}starships/", GameAttributes = GetGameAttributes("starships") },
                    new EndpointRoot(){Key = "vehicles", Name="Vehicles", RootUrl = $"{_baseUrl}vehicles/", GameAttributes = GetGameAttributes("vehicles") }
                };
            this.Endpoints = endpoints;
        }

        private List<GameAttribute> GetGameAttributes(string key)
        {
            var gameAttributes = new List<GameAttribute>();
            switch (key)
            {
                case "starships":
                {
                    gameAttributes.Add(new GameAttribute { Key = "cost_in_credits", Name = "Cost In Credits", HighestValueWins = true, CountOfObjects = false });
                    gameAttributes.Add(new GameAttribute { Key = "hyperdrive_rating", Name = "Hyperdrive Rating", HighestValueWins = false, CountOfObjects = false });
                    gameAttributes.Add(new GameAttribute { Key = "MGLT", Name = "Top Speed in Megalight", HighestValueWins = true, CountOfObjects = false });
                    gameAttributes.Add(new GameAttribute { Key = "films", Name = "Number of films", HighestValueWins = true, CountOfObjects = true });
                    gameAttributes.Add(new GameAttribute { Key = "crew", Name = "Crew Required", HighestValueWins = false, CountOfObjects = false });
                    break;
                }
                case "films":
                    {
                        gameAttributes.Add(new GameAttribute { Key = "characters", Name = "Number of Characters", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "planets", Name = "Number of Planets", HighestValueWins = false, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "starships", Name = "Number of Starships", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "vehicles", Name = "Number of Vehicles", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "species", Name = "Number of Species", HighestValueWins = false, CountOfObjects = true });
                        break;
                    }
                case "species":
                    {
                        gameAttributes.Add(new GameAttribute { Key = "average_height", Name = "Average Height", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "average_lifespan", Name = "Average Life Span", HighestValueWins = false, CountOfObjects = false});
                        gameAttributes.Add(new GameAttribute { Key = "films", Name = "Number of Films", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "people", Name = "Number of People", HighestValueWins = true, CountOfObjects = true });
                        break;
                    }
                case "planets":
                    {
                        gameAttributes.Add(new GameAttribute { Key = "otation_period", Name = "Average Height", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "orbital_period", Name = "Average Life Span", HighestValueWins = false, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "diameter", Name = "Number of Films", HighestValueWins = true, CountOfObjects = false});
                        gameAttributes.Add(new GameAttribute { Key = "population", Name = "Number of People", HighestValueWins = true, CountOfObjects = false});
                        gameAttributes.Add(new GameAttribute { Key = "surface_water", Name = "Number of People", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "films", Name = "Number of Films", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "residents", Name = "Number of Residents", HighestValueWins = true, CountOfObjects = true });
                        break;
                    }
                case "people":
                    {
                        gameAttributes.Add(new GameAttribute { Key = "height", Name = "Average Height", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "mass", Name = "Average Life Span", HighestValueWins = false, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "species", Name = "Number of Species", HighestValueWins = false, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "starships", Name = "Number of Starships", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "vehicles", Name = "Number of Vehicles", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "films", Name = "Number of Films", HighestValueWins = false, CountOfObjects = true });
                        break;
                    }
                case "vehicles":
                    {
                        gameAttributes.Add(new GameAttribute { Key = "cost_in_credits", Name = "Cost In Credits", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "cargo_capacity", Name = "Cargo Capacity", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "passengers", Name = "Passengers", HighestValueWins = true, CountOfObjects = false });
                        gameAttributes.Add(new GameAttribute { Key = "films", Name = "Number of films", HighestValueWins = true, CountOfObjects = true });
                        gameAttributes.Add(new GameAttribute { Key = "crew", Name = "Crew Required", HighestValueWins = false, CountOfObjects = false });
                        break;
                    }
            }
            return gameAttributes;
        }

        public string JsonGameAttributes
        {
            get
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string json = js.Serialize(this.Endpoints);
                return json;
            }
        }
    }

    public class EndpointRoot
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string RootUrl { get; set; }
        public List<GameAttribute> GameAttributes { get; set; }
    }

    public class GameAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
        public bool HighestValueWins { get; set; }
        public bool CountOfObjects { get; set; }
    }

    public class Play
    {
        public int TotalCards { get; set; }
        public EndpointRoot EndPointRoot { get; set; }
        public int WhoPlaysFirst { get; set; }
        public string JsonEndPointRoot { get; set; }

        public string JsonFullDeck { get; set; }
    }
}