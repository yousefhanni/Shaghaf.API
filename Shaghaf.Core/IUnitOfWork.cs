using Shaghaf.Core.Entities;
using Shaghaf.Core.Entities.HomeEntities;
using Shaghaf.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        ///Signature for Generic Method 
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        //Method simulate Method that Savechanges that exist at Dbcontext,return Number of Rows that made Row affected  
        Task<int> CompleteAsync();


    }
}
