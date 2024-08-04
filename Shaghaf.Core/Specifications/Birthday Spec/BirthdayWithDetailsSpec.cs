using Shaghaf.Core.Entities.BirthdayEntity;
using Shaghaf.Core.Specifications;
using Shaghaf.Core.Specifications.Home_Specs;
using System;
using System.Linq.Expressions;

public class BirthdayWithDetailsSpec : BaseSpecifications<Birthday>
{
    public BirthdayWithDetailsSpec(int id) : base(b => b.Id == id)
    {
        Includes.Add(B => B.Cakes);
        Includes.Add(B => B.Decorations);
      //  Includes.Add(B => B.PhotoSessions);

    }

    public BirthdayWithDetailsSpec()
    {
        Includes.Add(B => B.Cakes);

        Includes.Add(B => B.Decorations);
       // Includes.Add(B => B.PhotoSessions);

    }
}

