using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Novemberprojektet
{
    class PokeFactory
    {
        RestClient client;

        public PokeFactory()
        {
            client = new RestClient("https://pokeapi.co/api/v2/");

            GenerationPicker.Generation();
            
        }
        
        public Pokemon Hatch()
        {
            client = new RestClient("https://pokeapi.co/api/v2/");

            int pokeID = Utils.generator.Next(GenerationPicker.pokemonLower, GenerationPicker.pokemonHigher);
            
            RestRequest request = new RestRequest("pokemon/" + pokeID);            

            IRestResponse response = client.Get(request);            

            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content);

            return pokemon;
        }

        
        
    }
}
