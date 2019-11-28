using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Novemberprojektet
{
    class Game
    {
        public static void PlayGame()
        {
            PokeFactory pokeFactory = new PokeFactory();
            List<Pokemon> starterOptions = new List<Pokemon>();
            List<Pokemon> playerParty = new List<Pokemon>();
            List<int> partyHp = new List<int>();            
            Pokemon pokemon = new Pokemon();
            string[] splitTypesPokemon;

            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokeFactory.Hatch();
                starterOptions.Add(p);
                splitTypesPokemon = p.Types.Split(' ');
                Console.WriteLine("-----------------------------");
                Console.WriteLine(i + 1);
                Console.WriteLine(Utils.ToUpperFirstLetter(p.name));
                for (int a = 0; a < splitTypesPokemon.Length; a++)
                {
                    Console.Write(Utils.ToUpperFirstLetter(splitTypesPokemon[a])+ " ");
                }
                
                Console.WriteLine("\n-----------------------------");

            }

            Console.WriteLine("Please choose your starter!");
            int choise = Utils.MultipleChoiceInput(3);

            // Console.WriteLine(starterOptions[Utils.MultipleChoiceInput(Console.ReadLine())].name);
            //Console.WriteLine(choise);
            playerParty.Add(starterOptions[choise - 1]);
            partyHp.Add(pokemon.hp);
            Console.WriteLine("You chose "+playerParty[0].name+" as your starter pokemon");
            

            Pokemon enemy = pokeFactory.Hatch();
            Console.WriteLine("Aqwus wants to battle!");
            int enemyHp = pokemon.hp;

            Console.WriteLine("Aqwus sent out "+ enemy.name +"\n");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(Utils.ToUpperFirstLetter(enemy.name));
            splitTypesPokemon = enemy.Types.Split(' ');
            for (int i = 0; i < splitTypesPokemon.Length; i++)
            {
                Console.Write(Utils.ToUpperFirstLetter(splitTypesPokemon[i]+ " "));
            }
            
            Console.WriteLine("\n-----------------------------");
            Console.ReadLine();
            Combat(playerParty[0].Types, enemy.Types, partyHp[0], enemyHp, playerParty[0].name, enemy.name);

          
            

            
        }
        

        public static void Combat(string alyPokemonType, string enemyType, int alyPokemonHp, int enemyHp, string alyPokemonName, string enemyPokemonName)
        {
            Pokemon pokemon = new Pokemon();

            Console.Clear();
            while (alyPokemonHp > 0 && enemyHp > 0)
            {

                Console.WriteLine("-----------------------------");
                Console.WriteLine(Utils.ToUpperFirstLetter(alyPokemonName) + "\n HP : " + alyPokemonHp);
                Console.WriteLine("Type : "+alyPokemonType+ "\n");
                Console.WriteLine(Utils.ToUpperFirstLetter(enemyPokemonName)+"\n HP : "+enemyHp);
                Console.WriteLine("Type : "+enemyType);
                Console.WriteLine("-----------------------------\n\n");
                Console.WriteLine("1. Attack \n2. Do nothing");
                int action = Utils.MultipleChoiceInput(2);
                Console.Clear();
                Console.WriteLine("-----------------------------");
                Console.WriteLine(Utils.ToUpperFirstLetter(alyPokemonName) + "\n HP : " + alyPokemonHp);
                Console.WriteLine("Type : " + alyPokemonType + "\n");
                Console.WriteLine(Utils.ToUpperFirstLetter(enemyPokemonName) + "\n HP : " + enemyHp);
                Console.WriteLine("Type : " + enemyType);
                Console.WriteLine("-----------------------------\n\n");
                if (action == 1)
                {
                    
                    enemyHp = enemyHp - Attack(alyPokemonType, enemyType);
                    Console.WriteLine( alyPokemonName +" dealt " + (Attack(alyPokemonType, enemyType))+ " dmg to "+enemyPokemonName);

                }
                else if (action == 2)//Byta pokemon om det implementeras 
                {
                    Console.WriteLine("Nothing happened");
                }

                alyPokemonHp = alyPokemonHp - Attack(enemyType, alyPokemonType);
                Console.WriteLine(enemyPokemonName + " dealt " + (Attack(enemyType, alyPokemonType)) + " dmg to "+ alyPokemonName);

                Console.ReadLine();
                Console.Clear();

            }

            if (alyPokemonHp > 0)
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("Aqwus Wins!");
            }

            

        }
        public static int Attack(string attackingPokemonType, string receivingPokemonType)
        {
            Type type = new Type();
            Pokemon pokemon = new Pokemon();

            int attackDmg = pokemon.dmg;
           
            attackDmg = attackDmg * type.TypeDmgMod(attackingPokemonType.Trim(), receivingPokemonType.Trim());
            
            return attackDmg;
            
        }
    }
}
