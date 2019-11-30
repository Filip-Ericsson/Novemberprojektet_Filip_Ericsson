using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Novemberprojektet
{
    class PokeFactory //kod för att hämta pokeapi 
    {
        RestClient client;

        public PokeFactory()
        {
            client = new RestClient("https://pokeapi.co/api/v2/"); //skapar vi klienten 

            GenerationPicker.Generation(); //slumpas vilken generation som vi kör med under en playthrough
            
        }
        
        public Pokemon Hatch() //hatch kläcker en ny pokemon till världen
        {            

            int pokeID = Utils.generator.Next(GenerationPicker.pokemonLower, GenerationPicker.pokemonHigher); //pokeID vilket representerar en pokemon med respektive värde i pokedexet, värde beroende vilken generation
            
            RestRequest request = new RestRequest("pokemon/" + pokeID);            //Här önskas/förfrågas api:n att skicka en pokemon

            IRestResponse response = client.Get(request);            //svar från api:n

            Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(response.Content); //översätts informationen från sidan till något användbart

            return pokemon;
        }

        
        
    }
}
