using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Type
    {

        public string name;

        public int TypeDmgMod(string attackingType, string defendingType)
        {
            List<string> pokemonTypes = new List<string> { "bug", "dark", "dragon", "electric", "fairy", "fighting", "fire", "flying", "ghost", "grass", "ground", "ice", "normal", "poison", "psychic", "rock", "steel", "water" };


            if (attackingType == pokemonTypes[5] && (defendingType == pokemonTypes[1] || defendingType == pokemonTypes[5]))
            {
                return 2;
            }
            else
            {
                return 1;
            }


        }
    }
}
