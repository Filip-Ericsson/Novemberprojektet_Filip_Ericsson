using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class PhysicalPokemon :Pokemon
    {

        public override int Health() //då en fysisk pokemon har mer hp overridas det tidigare värdet på hp
        {
            return base.Health() + Utils.generator.Next(5,20);
        }
    }
}
