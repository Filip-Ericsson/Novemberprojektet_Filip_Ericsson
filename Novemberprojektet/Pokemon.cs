using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Pokemon
    {
        public string name = "";
        public int hp = 20;
        public int dmg = 5;
        public string Types
        {
            get
            {
                string s = "";
                for (int i = 0; i < types.Length; i++)
                {
                    s += types[i].type.name + " ";
                }
                return s;
            }
            private set
            {

            }
        }

        public TypeSlot[] types;

        public void PrintTypes()
        {
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine(types[i].type.name);
            }
        }
    }
}
