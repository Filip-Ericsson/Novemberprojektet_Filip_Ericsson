using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class GenerationPicker
    {
        public static int pokemonLower = 0;
        public static int pokemonHigher = 0;
        public static void Generation()
        {
            int genration = Utils.generator.Next(1, 4);

            Console.WriteLine("This session will be played with gen "+ genration + " pokemon");

            if (genration == 1)
            {
                pokemonLower = 1;
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
