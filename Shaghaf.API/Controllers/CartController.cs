

using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Repositories.Contract;
using AutoMapper;
using Shaghaf.Core.Entities.Cart_Entities;
using Talabat.APIs.Controllers;
using Talabat.APIs.Errors;

namespace Shaghaf.API.Controllers
{
    public class CartController : BaseApiController
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        [HttpGet] // GET: /api/cart?id=
        public async Task<ActionResult<CustomerCart>> GetCart(string id)
        {
            var cart = await _cartRepository.GetCartAsync(id);
            return Ok(cart ?? new CustomerCart(id));
        }

        [HttpPost] // POST: /api/cart
        public async Task<ActionResult<CustomerCart>> UpdateCart(CustomerCartDto cartDto)
        {
            var mappedCart = _mapper.Map<CustomerCartDto, CustomerCart>(cartDto);
            var createdOrUpdatedCart = await _cartRepository.UpdateCartAsync(mappedCart);

            if (createdOrUpdatedCart is null) return BadRequest("Failed to update cart.");

            return Ok(createdOrUpdatedCart);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart(string id)
        {
            var result = await _cartRepository.DeleteCartAsync(id);
            if (!result)
                return NotFound("Cart not found.");

            return NoContent();
        }
    }
}

