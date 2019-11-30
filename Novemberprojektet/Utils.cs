using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Utils
    {
        //Lite olika anvädbara utils 
        //En statisk random generator, statisk eftersom om man försöker att slumpa mångagånger på en mycket kort tid blir det inte samma värde på slumpen
        public static Random generator = new Random();        

        public static string ToUpperFirstLetter(string name)//inte min kod. Tack mathias
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            // convert to char array of the string
            char[] letters = name.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
        
        public static string[] pokemonTypeSplitter(string pokemonTypes)//delar på en string till en array, 
        {

           string[] splitTypesPokemon = pokemonTypes.Split(' ');
       
            return splitTypesPokemon;

        }
        public static int MultipleChoiceInput(int range) //en metod som används när användaren ska göra val i spelet, låter bara användaren skriva 1- deklarerat värde. allt annat blir felmedelande till användaren       
        {   string index ="";
            bool choiseCheck = false;
            while (choiseCheck == false)
            {
             index = Console.ReadLine();
            if(index == "1")
            {
                return 1;
                choiseCheck = true;
            }
            else if (index == "2" && range >=2)
            {
                return 2;
                    choiseCheck = true;
            } 
            else if (index == "3" && range >=3)
            {               
                return 3;
                    choiseCheck = true;
            }
            else if (index == "4" && range >=4)
            {
                return 4;
                    choiseCheck = true;
            }
            else            
            {

                    Console.WriteLine("Please write 1-" + range +" to choose");
                    choiseCheck = false;
            }
            
            }         
            
           return 0; 

        }
    }
    
}
