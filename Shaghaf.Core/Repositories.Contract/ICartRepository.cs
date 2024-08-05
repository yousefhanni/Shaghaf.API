using System.Text.Json;
using Shaghaf.Core.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Shaghaf.Core.Entities.Cart_Entities;

namespace Shaghaf.Core.Repositories.Contract
{
    //This special interface Repository that deal with Redis DB Not Store Context //

    public interface ICartRepository
    {
        Task<CustomerCart?> GetCartAsync(string cartId);

        //Create or Update 
        Task<CustomerCart?> UpdateCartAsync(CustomerCart cart);

        Task<bool> DeleteCartAsync(string cartId);
    }
}
