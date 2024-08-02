## Shaghaf Overview
Shaghaf is a comprehensive application designed for booking and renting various rooms for multiple purposes such as training, meetings, social events, and birthday parties. The application provides user-friendly interfaces to display rooms, book them, manage memberships, and order additional services like food and photo sessions.

## Technical Details
Shaghaf API is a sophisticated .NET 7.0 Web API designed to facilitate the booking and rental of rooms for various events. Leveraging Onion Architecture for scalability and maintainability, it incorporates advanced features like data seeding, error handling, and filtration, alongside secure payment integration via Stripe.

### Technologies
* **.NET 7.0**
* **Entity Framework Core (EF Core)**
* **LINQ (Language Integrated Query)**
* **Stripe Payment Gateway**
* **AutoMapper**

### Architecture
The API is structured into several layers:
* **Shaghaf.API**: Manages incoming HTTP requests and middleware.
* **Shaghaf.Core**: Houses the core business logic and domain models.
* **Shaghaf.Infrastructure**: Manages data access via EF Core, using patterns like Generic Repository and Unit of Work.
* **Shaghaf.Service**: Provides service layer functionalities.

### Controllers
* **HomeController**: Handles retrieval of home data, memberships, birthdays, photo sessions, advertisements, and categories.
* **RoomsController**: Manages room listings, room details by ID, and new room creation.
* **BookingController**: Manages all booking operations including creation, detail retrieval, payment sessions, and payment status checks.

### Services
* **HomeService**: Manages retrieval and manipulation of home-related data.
* **RoomService**: Handles operations related to room management.
* **BookingService**: Oversees booking functionalities.
* **PaymentService**: Manages Stripe payment sessions and status updates.

### Entities and DTOs
* **Entities**: Include models for Home, Room, and Booking, each with specific fields.
* **DTOs**: Used for efficient data transfer across different layers.

### Configuration
Ensure `appsettings.json` is properly configured:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YourConnectionStringHere"
  },
  "Stripe": {
    "PublicKey": "YourStripePublicKey",
    "SecretKey": "YourStripeSecretKey"
  }
}




