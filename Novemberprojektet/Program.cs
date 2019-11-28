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

            Game.PlayGame();

            //Att göra!

            //Det som behövs ur PlayGame:
            //Välja vilken pokemon från sitt party
            //Börja med fler pokemons? 
            //Får välja flera gånger eller två slumpade
            //Dialog till user om vad som händer i spelet
            //Välja vilken typ av attack
            //Enemy attack slumpas mellan basic(physical dmg) eller special(special dmg)
            //Tre fighter totalt 
            //Om en pokemon faintar måste man byta, om alla dör man förlorar 
            //Kan byta pokemon? Breaka while loopen och returna alyPokemonHp och lägga i rätt del av listan



            //Det som behövs i Type:
            //Type advantage i attack 
            //Bara super effective????

            //Pokemon:
            //Importera stats? Kolla på typer som i gen 1 med vilka som är starka fysiskt och vilka special, fighting vs psychic. 
            //Special mer dmg och fysical mer hp?


        }
    }
}
