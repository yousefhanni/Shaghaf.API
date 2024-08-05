using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaghaf.Core.Dtos
{
    public class CustomerCartDto
    {
        [Required]
        public string Id { get; set; } // ID of the cart

        [Required]
        public List<CartItemDto> Items { get; set; } // List of cart items

       // public string PaymentIntentId { get; set; } // Payment intent ID for tracking payment intents

       // public string SessionId { get; set; } // Session ID for Stripe session
    }

}
