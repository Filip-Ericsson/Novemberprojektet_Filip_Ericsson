using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class Pokemon
    {
        //variabler...
        public string name = "";
        protected int hp = 20;
        protected int dmg = 5;
        public string Types //Api kod om typen som pokemon har

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

        public virtual int Attack() //metod för att pokemon ska göra skada
        {
            return dmg;
        }
        public virtual int Health() //metoden används för att beräkna värde på hälsa 
        {
            return hp;
        }
       
    }
}
