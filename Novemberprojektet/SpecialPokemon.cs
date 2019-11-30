using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novemberprojektet
{
    class SpecialPokemon:Pokemon
    {

        public override int Attack()//en special pokemon gör dubbel skada :)
        {
            return base.Attack()*2;
        }
    }
}
