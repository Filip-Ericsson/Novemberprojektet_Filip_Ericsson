using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Novemberprojektet
{
    class Program
    {
        static void Main(string[] args)
        {
            PokeFactory pokeFactory = new PokeFactory();
            List <Pokemon> starterOptions = new List <Pokemon>();
            List <Pokemon> playerParty = new List<Pokemon>();

            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokeFactory.Hatch();
                starterOptions.Add(p);
                Console.WriteLine("-----------------------------");
                Console.WriteLine(i+1);
                Console.WriteLine(Utils.ToUpperFirstLetter(p.name));                
                Console.WriteLine(Utils.ToUpperFirstLetter(p.Types));
                Console.WriteLine("-----------------------------");

            }

            Console.WriteLine("Please choose your starter!");

            Console.WriteLine();
            Console.WriteLine(starterOptions[2].name);

            playerParty.Add(starterOptions[1]);
            Console.WriteLine(playerParty[0].name);
            Console.ReadLine();
        }

        
    }
}
