using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class GenerationPicker
    {
        //Slumpar vilken generation av pokemon man kommer att få pokemons från, gen 1-4 är det skivet för. 
        public static int pokemonLower = 0;//pokemon med lägst nummer i en generation
        public static int pokemonHigher = 0;//högst nummer i en generation
        public static void Generation()
        {
            int genration = Utils.generator.Next(1, 4); //blir det gen 1 eller 2 eller 3 eller kanske 4?

            Console.WriteLine("This session will be played with gen "+ genration + " pokemon");

            if (genration == 1)
            {
                pokemonLower = 1;//värden på pokedex för gen 1, från pokemon nummer 1 till pokemon nummer 151 
                pokemonHigher = 151;

                
            }
            else if (genration == 2)
            {
                pokemonLower = 152;
                pokemonHigher = 251;
                
            }
            else if (genration == 3)
            {
                pokemonLower = 252;
                pokemonHigher = 386;
            }
            else if (genration == 4)
            {
                pokemonLower = 387;
                pokemonHigher = 493;
            }

        }
    }
}
