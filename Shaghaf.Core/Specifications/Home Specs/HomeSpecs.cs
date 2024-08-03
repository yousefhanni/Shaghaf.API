using Shaghaf.Core.Entities.HomeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Specifications.Home_Specs
{
    public class HomeSpecs : BaseSpecifications<Home>
    {
        public HomeSpecs() 
            : base()
        {
            Includes.Add(H => H.Advertisements);
           // Includes.Add(H => H.Memberships);
         //   Includes.Add(H => H.Birthdays);
            //Includes.Add(H => H.Birthdays).ThenInclude(B => B.Cakes);

            //Includes.Add(H => H.Birthdays).ThenInclude(B => B.Decorations);

           // Includes.Add(H => H.PhotoSessions);
            Includes.Add(H => H.Categories);
            Includes.Add(H => H.Location);
        }
    }
}
