using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Utils
    {

        public static Random generator = new Random();


        public static string ToUpperFirstLetter(string name)
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

        /*public static int MultipleChoiceInput(string input)        
        {

        }*/
    }
    
}
