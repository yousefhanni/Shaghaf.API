using Microsoft.AspNetCore.Mvc;
using Shaghaf.Core.Dtos;
using Shaghaf.Core.Repositories.Contract;
using AutoMapper;
using Shaghaf.Core.Entities.Cart_Entities;
using Talabat.APIs.Controllers;
using Talabat.APIs.Errors;

namespace Shaghaf.API.Controllers
{
    // Controller for handling cart-related API requests
    public class CartController : BaseApiController
    {
        private readonly ICartRepository _cartRepository; // Repository for cart operations
        private readonly IMapper _mapper; // Mapper for converting between DTOs and entities

        // Constructor that initializes the repository and mapper
        public CartController(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        // Endpoint to retrieve a cart by ID
        [HttpGet] // GET: /api/cart?id=
        public async Task<ActionResult<CustomerCart>> GetCart(string id)
        {
            var cart = await _cartRepository.GetCartAsync(id); // Fetch the cart from the repository
            return Ok(cart ?? new CustomerCart(id)); // Return the cart or a new empty cart if not found
        }

        // Endpoint to update or create a cart
        [HttpPost] // POST: /api/cart
        public async Task<ActionResult<CustomerCart>> UpdateCart(CustomerCartDto cartDto)
        {
            var mappedCart = _mapper.Map<CustomerCartDto, CustomerCart>(cartDto); // Map the DTO to the entity
            var createdOrUpdatedCart = await _cartRepository.UpdateCartAsync(mappedCart); // Update or create the cart in the repository

            if (createdOrUpdatedCart is null) return BadRequest(new ApiResponse(400)); // Return 400 if the operation fails

            return Ok(createdOrUpdatedCart); // Return the created or updated cart
        }

        // Endpoint to delete a cart by ID
        [HttpDelete] // DELETE: /api/cart?id=
        public async Task DeleteCart(string id)
        {
            await _cartRepository.DeleteCartAsync(id); // Delete the cart from the repository
        }
    }
}
