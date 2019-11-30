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

        //Eftersom pokemons kan ha två typer måste de ibland delas på vilket dessa två används till
        public static string[] splitTypesPokemon;
        public static string[] splitRecevingTypesPokemon;

        //I playgame sker spelet huvudsakligen, uppstart, startar combat och avslutar spelet
        public static void PlayGame()
        {
            //Lite olika variabler, listor och olika instanser av klasser
            PokeFactory pokeFactory = new PokeFactory();
            List<Pokemon> starterOptions = new List<Pokemon>();
            List<Pokemon> playerParty = new List<Pokemon>();
            List<int> partyHp = new List<int>();
            Pokemon pokemon = new Pokemon();            
            PhysicalPokemon physicalPokemon = new PhysicalPokemon();

            Console.WriteLine("Please choose your starter!");
            //Spelaren får välja mellan tre olika pokemons att använda i spelet, därför används en for loop
            for (int i = 0; i < 3; i++)
            {
                Pokemon p = pokeFactory.Hatch(); //Se i pokefactory för förklaring av hatch
                starterOptions.Add(p);
                splitTypesPokemon = p.Types.Split(' '); 
                Console.WriteLine("-----------------------------");
                Console.WriteLine(i + 1);
                Console.WriteLine(Utils.ToUpperFirstLetter(p.name));
                for (int a = 0; a < splitTypesPokemon.Length; a++)
                {
                    Console.Write(Utils.ToUpperFirstLetter(splitTypesPokemon[a]) + " ");
                }

                Console.WriteLine("\n-----------------------------");

            }

            
            int choise = Utils.MultipleChoiceInput(3); // se utils för en förklaring
            
            playerParty.Add(starterOptions[choise - 1]); //för vidare utveckling av spelet läggs spelarens pokemon i en lista som kan användas för att byta mellan olika pokemons. inte implimenterat denna funktion
            Console.WriteLine("You chose " + playerParty[0].name + " as your starter pokemon!");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Do you want to boost your pokemons health or strength? ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. More health!");
            Console.WriteLine("2. More strength!");
            Console.WriteLine("-----------------------------");
            int statChange = Utils.MultipleChoiceInput(2);
            //Spelaren får välja om hen vill träna sin pokemon att få fördel i antigen hp eller göra mer skada. 
            if (statChange == 1)
            {
                partyHp.Add(physicalPokemon.Health()); //physicalPokemon ärver pokemons hp och multiplicerar det med en random range
                Console.WriteLine("You increased "+ playerParty[0].name+"s health from 20 to "+ partyHp[0]);
            }
            else
            {
                Console.WriteLine("Your attacks will now be stronger!"); //se i frendlyAttack för mer info 
                partyHp.Add(pokemon.Health());
            }

            Console.ReadLine();
            Console.Clear();

            
            Pokemon enemy = pokeFactory.Hatch(); //fiende skapas
            Console.WriteLine("Aqwus wants to battle!");
            int enemyHp = pokemon.Health();

            Console.WriteLine("Aqwus sent out " + enemy.name + "\n");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(Utils.ToUpperFirstLetter(enemy.name));
            splitTypesPokemon = enemy.Types.Split(' ');
            for (int i = 0; i < splitTypesPokemon.Length; i++)
            {
                Console.Write(Utils.ToUpperFirstLetter(splitTypesPokemon[i] + " "));
            }

            Console.WriteLine("\n-----------------------------");
            Console.ReadLine();
            Combat(playerParty[0].Types, enemy.Types, partyHp[0], enemyHp, playerParty[0].name, enemy.name, statChange); //statchange tages med för att ge mer skada till sin pokemon om spelaren valde det.





        }

        // I kombat fightas pokemonsen med varandra. Spelaren får välja att attackera eller göra inget
        public static void Combat(string alyPokemonType, string enemyType, int alyPokemonHp, int enemyHp, string alyPokemonName, string enemyPokemonName, int statChange)
        {           

            Console.Clear();
            //Kör fighten medan båda pokemons har mer än 0 hp
            while (alyPokemonHp > 0 && enemyHp > 0)
            {
                //Dialog till spelaren
                Console.WriteLine("-----------------------------");
                Console.WriteLine(Utils.ToUpperFirstLetter(alyPokemonName) + "\n HP : " + alyPokemonHp);
                Console.WriteLine("Type : " + alyPokemonType + "\n");
                Console.WriteLine(Utils.ToUpperFirstLetter(enemyPokemonName) + "\n HP : " + enemyHp);
                Console.WriteLine("Type : " + enemyType);
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
                
                //Spelaren väljar att attackera 
                if (action == 1)
                {

                    enemyHp = enemyHp - FriendlyAttack(alyPokemonType, enemyType, statChange); //subtraherar motståndarenshp med spelarens pokemon med type advantage inräknat
                    Console.WriteLine(alyPokemonName + " dealt " + (FriendlyAttack(alyPokemonType, enemyType,statChange)) + " dmg to " + enemyPokemonName); //skriver vad som hände

                }
                else if (action == 2)//Byta pokemon om det implementeras (Det gjorde det inte :) )
                {
                    Console.WriteLine("Nothing happened");
                }

                //fiende attackerar
                alyPokemonHp = alyPokemonHp - EnemyAttack(enemyType, alyPokemonType);
                Console.WriteLine(enemyPokemonName + " dealt " + (EnemyAttack(enemyType, alyPokemonType)) + " dmg to " + alyPokemonName); //display vad som hände

                Console.ReadLine();
                Console.Clear();
                //loopas tills en pokemon dör
            }
            //Medelande vem som vann kampen 
            if (alyPokemonHp > 0 && enemyHp <= 0)
            {
                Console.WriteLine("You Win!");
            }
            else
            {
                Console.WriteLine("Aqwus Wins!");
            }

            //Här går koden tillbaka till program.cs vilket stängerav programmet
            Console.ReadLine();

        }

        //Vad som händer när man attackerar
        public static int FriendlyAttack(string attackingPokemonType, string receivingPokemonType, int statChange)
        {
            Type type = new Type();
            Pokemon pokemon = new Pokemon();
            SpecialPokemon specialPokemon = new SpecialPokemon();
            //delar på statsen för både attackerandes och försvarande pokemon för att beränka typeadvantage nedan
            splitTypesPokemon = attackingPokemonType.Trim().Split(' ');
            splitRecevingTypesPokemon = receivingPokemonType.Trim().Split(' ');
            
            int dmgModifyer = 0;

            //Denna loop kollar alla typer för både attackerande och försvarande pokemon, eftersom pokemons kan ha två typer måste man matcha första typen med både första och andra typen på motståndaren 
            //eller kolla båda sina mot motståndarens enda typ, ELLER så måste man kolla båda typerna med motståndarens båda typer. Detta blev det "snyggaste" sättet att lösa det problemet
            for (int i = 0; i < splitTypesPokemon.Length; i++)
            {
                //För spelarens första typ 
                if (i == 0 )
                {
                    //Här kollar man första typen med motståndarens första typ
                    dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i]); //TypeDmgMod returnerar antigen 0 eller 2 beroende på om en typ är supereffective eller inte
                                                                                                                            //För att utveckla kan man lägga till dissadvantage eller imunity men hann inte det
                    
                    if (splitRecevingTypesPokemon.Length == 2)//Om motståndaren har två typer kollar man den också med spelarens första typ
                    {
                        dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i+1]);
                    }
                    
                }
                //Här gör man samma sak men med andra typen hoss spelaren OM den har en sådan. "I" blir bra 1 om spelaren har två typer
                else if (i == 1)
                {
                    dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i-1]); //i-1 här eftersom i har blivit ==1 och man vill kolla första värdet vilket är 0
                    if (splitRecevingTypesPokemon.Length == 2)
                    {
                        dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i]);
                    }
                }               

            }
            
            if (dmgModifyer == 0) //om ingen av spelarens typer är supereffectiva mot motståndaren ska de fortfarande göra skada vilket är varför man sätter modifyen till 1 då den multipliceras senare
            {
                dmgModifyer = 1;
            }

            if (statChange ==2) //här kommer statchange från början av Game.cs, istället för att öka hp gör man lite mer skada
            {
                return dmgModifyer * specialPokemon.Attack();
            }
            else
            {
                return dmgModifyer * pokemon.Attack();
            }
            

        }

        //Nästan exakt samma kom friendlyAttack men inte med specialPokemon utan bara med vanliga pokemons attack modifyer
        public static int EnemyAttack(string attackingPokemonType, string receivingPokemonType)
        {
            Type type = new Type();
            Pokemon pokemon = new Pokemon();
            splitTypesPokemon = attackingPokemonType.Trim().Split(' ');
            splitRecevingTypesPokemon = receivingPokemonType.Trim().Split(' ');
            
            int dmgModifyer = 0;

            for (int i = 0; i < splitTypesPokemon.Length; i++)
            {

                if (i == 0)
                {
                    dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i]);
                    if (splitRecevingTypesPokemon.Length == 2)
                    {
                        dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i + 1]);
                    }

                }
                else if (i == 1)
                {
                    dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i-1]);
                    if (splitRecevingTypesPokemon.Length == 2)
                    {
                        dmgModifyer = dmgModifyer + type.TypeDmgMod(splitTypesPokemon[i].Trim(), splitRecevingTypesPokemon[i]);
                    }
                }

            }
            
            
            if (dmgModifyer == 0)
            {
                dmgModifyer = 1;
            }
           
            
            return dmgModifyer * pokemon.Attack();
            
        }
    }
}
