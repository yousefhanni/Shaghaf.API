

    namespace Shaghaf.Core.Entities.Cart_Entities
    {

    public class CustomerCart
    {
        // The ID of the cart
        public string Id { get; set; }

        // List of items in the cart
        public List<CartItem> Items { get; set; }

      

        // Constructor that initializes the cart with a given ID and an empty list of items
        public CustomerCart(string id)
        {
            Id = id; // Sets the cart ID
            Items = new List<CartItem>(); // Initializes the list of items
        }
    }
}
