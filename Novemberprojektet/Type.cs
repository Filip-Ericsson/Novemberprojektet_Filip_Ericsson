using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Type
    {
        public enum PokemonType
        {
            bug, dark, dragon, electric, fairy, fighting, fire, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel, water
        }

        static Dictionary<PokemonType, PokemonType[]> weaknesses = new Dictionary<PokemonType, PokemonType[]>();
        public string name;
        public Type()
        {

            if (weaknesses.Count==0)
            {

                AddWeakness();
            }
        }

        public void AddWeakness()
        {
            Console.WriteLine("Add count");
            weaknesses.Add(PokemonType.bug, new PokemonType[] {
                PokemonType.fire,
                PokemonType.flying,
                PokemonType.rock
            });
            weaknesses.Add(PokemonType.dark, new PokemonType[]{

                PokemonType.bug,
                PokemonType.fairy,
                PokemonType.fighting,

            });
            weaknesses.Add(PokemonType.dragon, new PokemonType[]{

                PokemonType.dragon,
                PokemonType.fairy,
                PokemonType.ice
            });
            weaknesses.Add(PokemonType.electric, new PokemonType[]{
                PokemonType.ground

            });
            weaknesses.Add(PokemonType.fairy, new PokemonType[]{

                PokemonType.poison,
                PokemonType.steel
            });
            weaknesses.Add(PokemonType.fighting, new PokemonType[]{

                PokemonType.fairy,
                PokemonType.flying,
                PokemonType.psychic
            });
            weaknesses.Add(PokemonType.fire, new PokemonType[]{

                PokemonType.ground,
                PokemonType.rock,
                PokemonType.water
            });
            weaknesses.Add(PokemonType.flying, new PokemonType[]{

                PokemonType.electric,
                PokemonType.ice,
                PokemonType.rock
            });
            weaknesses.Add(PokemonType.ghost, new PokemonType[]{

                PokemonType.dark,
                PokemonType.ghost,

            });
            weaknesses.Add(PokemonType.grass, new PokemonType[]{
                PokemonType.bug,
                PokemonType.fire,
                PokemonType.flying,
                PokemonType.ice,
                PokemonType.poison

            });
            weaknesses.Add(PokemonType.ground, new PokemonType[]{

                PokemonType.grass,
                PokemonType.ice,
                PokemonType.water
            });
            weaknesses.Add(PokemonType.ice, new PokemonType[]{

                PokemonType.fighting,
                PokemonType.fire,
                PokemonType.rock,
                PokemonType.steel
            });
            weaknesses.Add(PokemonType.normal, new PokemonType[]{

                PokemonType.fighting
            });
            weaknesses.Add(PokemonType.poison, new PokemonType[]{

                PokemonType.ground,
                PokemonType.psychic
            });
            weaknesses.Add(PokemonType.psychic, new PokemonType[]{

                PokemonType.bug,
                PokemonType.dark,
                PokemonType.ghost
            });
            weaknesses.Add(PokemonType.rock, new PokemonType[]{

                PokemonType.fighting,
                PokemonType.ground,
                PokemonType.ground,
                PokemonType.steel,
                PokemonType.water
            });
            weaknesses.Add(PokemonType.steel, new PokemonType[]{

                PokemonType.fighting,
                PokemonType.fire,
                PokemonType.ground
            });
            weaknesses.Add(PokemonType.water, new PokemonType[]{

                PokemonType.electric,
                PokemonType.water
            });
        }


        public int TypeDmgMod(string attackingType, string defendingType)
        {

            Dictionary<string, PokemonType> translator = new Dictionary<string, PokemonType>();

            List<string> pokemonTypes = new List<string> { "bug", "dark", "dragon", "electric", "fairy", "fighting", "fire", "flying", "ghost", "grass", "ground", "ice", "normal", "poison", "psychic", "rock", "steel", "water" };

            for (int i = 0; i < pokemonTypes.Count; i++)
            {
                string tTypes = pokemonTypes[i];

                PokemonType cl;

                if (Enum.TryParse<PokemonType>(tTypes, out cl))
                {
                    translator.Add(tTypes, cl);
                }
            }
            
            
            PokemonType attacking = translator[attackingType];
            PokemonType defending = translator[defendingType];    
                      

            if (weaknesses[defending].Contains(attacking))
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
