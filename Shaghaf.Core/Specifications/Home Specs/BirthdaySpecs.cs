using Shaghaf.Core.Entities.HomeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Specifications.Home_Specs
{
    public class BirthdaySpecs : BaseSpecifications<Birthday>
    {
        public BirthdaySpecs() : base()
        {
            Includes.Add(B => B.Cakes);
            Includes.Add(B => B.Decorations);
      
        }
        
    }
}
