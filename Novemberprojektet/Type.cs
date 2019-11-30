using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Type
    {
        //En egen enum för alla pokemontyper som finns i spelet, 18 st totalt 
        public enum PokemonType
        {
            bug, dark, dragon, electric, fairy, fighting, fire, flying, ghost, grass, ground, ice, normal, poison, psychic, rock, steel, water
        }

        //Ett dictionary som sparar alla typadvantages mellan typerna, typen som är svag mot något är TKeyn och alla typer som är starka är TValuen 
        static Dictionary<PokemonType, PokemonType[]> weaknesses = new Dictionary<PokemonType, PokemonType[]>();

        //Detta dictionary låter programmet taemot strings för alla typer från game och konverterar dem till enumen PokemonType
        static Dictionary<string, PokemonType> translator = new Dictionary<string, PokemonType>(); //eftersom Tkeyn är en string kan man skicka en string som input och få enumen som return då den är värdet.
        public string name;
        public Type() //I konstruktorn av Type läggs alla typeweaknesses till i dictionariet första gången classen körs, även alla typer läggs till i translate.
        {
            
            if (weaknesses.Count == 0)
            {

                AddWeakness();
                
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
            }
        }

        public void AddWeakness() //Här finns alla 18 olika typer med deras weaknesses, med samma mönster kan man göra imunity etc, men det tar bara mycket tid.
        {
            //Tänker bara förklara en typ då alla är samma... 
            //Man lägger till typen till dictionariet som Tkey och sparar alla typer som är supereffectiva som Tvalue till den Tkeyn
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

        public PokemonType Translate(string typeToTranslate)
        {                      
                        
            return translator[typeToTranslate.Trim().ToLower()]; //"Översätter" en string till enumen PokemonType
        }
        public int TypeDmgMod(string attackingType, string defendingType)
        {
                     
                       
            //För att beräkna om det är någon typeadvantage översätter man attackerande och motagande typ från en string till enum
            PokemonType attacking = Translate(attackingType);
            
            PokemonType defending = Translate(defendingType);
            

            if (weaknesses[defending].Contains(attacking)) //Om attackerande pokemonstyp finns i listan av försvarande typens svagheter returneras 2.
            {
                return 2;
            }
            else
            {
                return 0;
            }

            






        }
    }
}
