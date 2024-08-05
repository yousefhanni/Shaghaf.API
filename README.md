## Shaghaf Overview
Shaghaf is a comprehensive application designed for booking and renting various rooms for multiple purposes such as training, meetings, social events, and birthday parties. The application provides user-friendly interfaces to display rooms, book them, manage memberships, and order additional services like food and photo sessions.

## Technical Details
Shaghaf API is a sophisticated .NET 7.0 Web API designed to facilitate the booking and rental of rooms for various events. Leveraging Onion Architecture for scalability and maintainability, it incorporates advanced features like data seeding, error handling, and filtration, alongside secure payment integration via Stripe.

- **.NET 7.0**
- **Entity Framework Core (EF Core)**
- **LINQ (Language Integrated Query)**
- **Stripe Payment Gateway**
- **AutoMapper**
- **RESTful APIs**
- **MS SQL Server**
- **JWT Authentication**
- **Identity for User Management**
  
### Architecture
The API is structured into several layers:
* **Shaghaf.API**: Manages incoming HTTP requests and middleware.
* **Shaghaf.Core**: Houses the core business logic and domain models.
* **Shaghaf.Infrastructure**: Manages data access via EF Core, using patterns like Generic Repository and Unit of Work.
* **Shaghaf.Service**: Provides service layer functionalities.

# Shaghaf API Overview

Shaghaf API is a comprehensive platform for booking and managing spaces and services tailored for various events such as training sessions, meetings, social gatherings, and special celebrations like birthday parties. It not only facilitates room bookings but also manages memberships, photo sessions, and other related services to enhance user experiences.

## System Components

### 1. Rooms
Rooms in Shaghaf are versatile spaces available for a range of activities:
- **Training Rooms**: Equipped with educational tools like whiteboards and projectors.
- **Meeting Rooms**: Set up for corporate meetings with necessary conferencing equipment.
- **Event Rooms**: Ideal for hosting larger gatherings or social events.
- **Birthday Rooms**: Decorated spaces for celebrating birthdays, including party amenities.
- **Workspaces**: Co-working areas designed for professionals and freelancers.
- **Game Rooms**: Entertainment zones equipped with various gaming setups.
- **Conference Rooms**: Large areas suitable for conferences and large scale meetings.

**Attributes**:
- Name, Offer, Rate, Seat Capacity, Description, Location, Available Dates, Pricing Plans, and Room Type.

### 2. Birthdays
Shaghaf allows users to book rooms specifically for birthday events, which can be customized with various options:
- **User Name**: Who is hosting the event.
- **Date and Number of Guests**: Schedule and size of the party.
- **Cakes and Decorations**: Customizable options for cakes and decor.
- **Photo Sessions**: Optional photo sessions can be added.

### 3. Photo Sessions
Available as standalone bookings or part of event packages, photo sessions include:
- **Cost and Duration**: Pricing and time slots available.
- **Date and Location**: Scheduling and places (indoor/outdoor).
- **Associated Room or Event**: Linking to specific rooms or events.

### 4. Memberships
Memberships provide special privileges and discounts for frequent users:
- **Name and Price**: Type of membership and cost.
- **Features**: Benefits such as access to exclusive rooms and events.
- **Duration and Guest Allowance**: Validity period and guest limits.

### 5. Bookings
Central to Shaghaf’s operations, bookings can be made for rooms, services, or special events:
- **Details**: Room or event type, customer information, dates, and financials.
- **Management Features**: Options to view, update, or cancel bookings.

### 6. Account Management
Shaghaf also provides robust account management functionalities, allowing users to register, log in, and manage roles:
- **Register**: Users can create new accounts.
- **Login**: Account holders can log into the system.
- **Add Role**: Admins can assign roles to users, enhancing control over permissions and access.

### 7. Home Data Management
The `HomeController` facilitates retrieval and management of home-related data, essential for displaying dynamic content on the platform:
- **Advertisements**: Manage and retrieve advertisements which enhance user interaction.
- **Categories**: Handle categories which organize the services and rooms into manageable sections.

## Controllers Overview
- **RoomController**: Manages all aspects of room listings and bookings.
- **BirthdayController**: Specialized controller for handling all birthday-related bookings and services.
- **PhotoSessionController**: Manages the booking and scheduling of photo sessions.
- **MembershipController**: Oversees the creation and management of membership services.
- **BookingController**: Central controller for handling all types of bookings and related services.
- **AccountController**: Manages user authentication and role assignments, crucial for system access and administration.
- **HomeController**: Manages retrieval of home data, including advertisements and categories, to support platform operations and user engagement.


# Shaghaf Services

## Overview

Shaghaf Services is a comprehensive suite of services designed to manage various aspects of a business, including birthday events, bookings, memberships, payments, and more. These services utilize AutoMapper for object-object mapping and follow best practices for asynchronous programming and dependency injection.

## Table of Contents
- [Birthday Service](#birthday-service)
- [Booking Service](#booking-service)
- [Auth Service](#auth-service)
- [Home Service](#home-service)
- [Membership Service](#membership-service)
- [Payment Service](#payment-service)
- [Photo Session Service](#photo-session-service)
- [Room Service](#room-service)

## Birthday Service

The `BirthdayService` manages birthday events, including creation, updating, retrieval, and listing of birthday details.

### Methods

- **CreateBirthdayAsync**: This method allows for the creation of a new birthday event. It takes in a data transfer object (DTO) that contains the necessary information to create the event and returns the created event as a DTO.
- **UpdateBirthdayAsync**: This method updates an existing birthday event. It requires a DTO with the updated birthday details and updates the corresponding record in the database.
- **GetBirthdayByIdAsync**: This method retrieves a birthday event by its ID. It takes the ID as a parameter and returns the birthday details as a DTO.
- **GetAllBirthdaysAsync**: This method retrieves all birthday events. It returns a list of birthday events as DTOs.

## Booking Service

The `BookingService` handles bookings, including creation, updating, retrieval, and listing of booking details.

### Methods

- **CreateBookingAsync**: This method creates a new booking. It takes a DTO with the booking details and returns the created booking as a DTO.
- **UpdateBookingAsync**: This method updates an existing booking. It requires a DTO with the updated booking details and updates the corresponding record in the database.
- **GetBookingDetailsAsync**: This method retrieves booking details by ID. It takes the booking ID as a parameter and returns the booking details as a DTO.
- **GetAllBookingDetailsAsync**: This method retrieves all booking details. It returns a list of booking details as DTOs.

## Auth Service

The `AuthService` manages user authentication and authorization, including user registration, login, and role management.

### Methods

- **RegisterAsync**: This method registers a new user. It takes a model with the user's registration details and returns an authentication model containing the registration result and a JWT token if successful.
- **LoginAsync**: This method logs in an existing user. It takes a model with the user's login details and returns an authentication model containing the login result and a JWT token if successful.
- **AddRoleAsync**: This method adds a role to a user. It takes a model with the user's ID and the role to be added, and returns a result message.
- **CreateJwtToken**: This method generates a JWT token for a user. It takes a user entity and returns a JWT token containing user claims and roles.

## Home Service

The `HomeService` retrieves home-related data, advertisements, and categories.

### Methods

- **GetHomeDataAsync**: This method retrieves home data. It returns a list of home entities.
- **GetAdvertisementsAsync**: This method retrieves advertisements. It returns a list of advertisement DTOs.
- **GetCategoriesAsync**: This method retrieves categories. It returns a list of category DTOs.

## Membership Service

The `MembershipService` manages memberships, including creation, updating, retrieval, and listing of membership details.

### Methods

- **CreateMembershipAsync**: This method creates a new membership. It takes a DTO with the membership details and returns the created membership as a DTO.
- **UpdateMembershipAsync**: This method updates an existing membership. It requires a DTO with the updated membership details and updates the corresponding record in the database.
- **GetMembershipByIdAsync**: This method retrieves a membership by its ID. It takes the ID as a parameter and returns the membership details as a DTO.
- **GetAllMembershipsAsync**: This method retrieves all memberships. It returns a list of membership DTOs.

## Payment Service

The `PaymentService` handles payment processing, including creating checkout sessions and handling payment status updates.

### Methods

- **CreateCheckoutSession**: This method creates a Stripe checkout session. It takes a DTO with payment details and returns the created checkout session.
- **HandleStripeEvent**: This method handles Stripe events for payment status updates. It takes the event data and updates the payment status accordingly.
- **UpdatePaymentIntentToSucceedOrFail**: This method updates the payment intent status. It takes the payment intent ID and a boolean indicating whether the payment succeeded or failed, and updates the booking status accordingly.
- **CheckPaymentStatusAsync**: This method checks the payment status for a booking. It takes the booking ID and returns the current payment status.

## Photo Session Service

The `PhotoSessionService` manages photo sessions, including creation, updating, retrieval, and listing of photo session details.

### Methods

- **CreatePhotoSessionAsync**: This method creates a new photo session. It takes a DTO with the photo session details and returns the created photo session as a DTO.
- **UpdatePhotoSessionAsync**: This method updates an existing photo session. It requires a DTO with the updated photo session details and updates the corresponding record in the database.
- **GetPhotoSessionByIdAsync**: This method retrieves a photo session by its ID. It takes the ID as a parameter and returns the photo session details as a DTO.
- **GetAllPhotoSessionsAsync**: This method retrieves all photo sessions. It returns a list of photo session DTOs.

## Room Service

The `RoomService` manages rooms, including creation, updating, retrieval, and listing of room details.

### Methods

- **CreateRoomAsync**: This method creates a new room. It takes a DTO with the room details and returns the created room as a DTO.
- **UpdateRoomAsync**: This method updates an existing room. It requires a DTO with the updated room details and updates the corresponding record in the database.
- **GetRoomByIdAsync**: This method retrieves a room by its ID. It takes the ID as a parameter and returns the room details as a DTO.
- **GetAllRoomsAsync**: This method retrieves all rooms. It returns a list of room DTOs.
- **GetRoomsWithSpecAsync**: This method retrieves rooms based on specific criteria. It takes a specification object and returns a list of room DTOs matching the criteria.



### Entities

Entities are models representing the core components of the system. They include:

- **HomeEntities**:
  - **Home**: Represents home-related data.
    - Fields: `Id`, `Name`, `Description`, `Location`, `CreatedDate`, etc.
  - **Advertisement**: Represents advertisements related to homes.
    - Fields: `Id`, `Title`, `Content`, `CreatedDate`, etc.
  - **Category**: Represents categories related to homes.
    - Fields: `Id`, `Name`, `Description`, etc.
  - **Location**: Represents the location details.
    - Fields: `Id`, `Address`, `City`, `State`, `Country`, `ZipCode`, etc.

- **RoomEntities**:
  - **Room**: Represents room details for booking and management.
    - Fields: `Id`, `Name`, `Description`, `Capacity`, `Price`, `CreatedDate`, etc.
  - **RoomPlan**: Represents the plan of the room.
    - Fields: `Id`, `RoomId`, `PlanDetails`, etc.
  - **RoomType**: Represents the type of the room.
    - Fields: `Id`, `TypeName`, `Description`, etc.

- **BookingEntities**:
  - **Booking**: Represents booking details for rooms and events.
    - Fields: `Id`, `RoomId`, `CustomerName`, `StartDate`, `EndDate`, `Status`, `CreatedDate`, etc.
  - **BookingStatus**: Represents the status of the booking.
    - Fields: `Id`, `StatusName`, `Description`, etc.
  - **AdditionalItem**: Represents additional items for the booking.
    - Fields: `Id`, `BookingId`, `ItemName`, `Quantity`, `Price`, etc.

- **BirthdayEntity**:
  - **Birthday**: Represents birthday event details.
    - Fields: `Id`, `Title`, `Description`, `Date`, `Location`, `Organizer`, etc.
  - **Cake**: Represents details about the cake for the birthday.
    - Fields: `Id`, `BirthdayId`, `CakeType`, `Flavor`, `Size`, etc.
  - **Decoration**: Represents decoration details for the birthday.
    - Fields: `Id`, `BirthdayId`, `DecorationType`, `Description`, etc.

- **IdentityEntities**:
  - **AppUser**: Represents the application user.
    - Fields: `Id`, `UserName`, `PhoneNumber`, `PasswordHash`, etc.
  - **AddRoleModel**: Represents a model to add roles to users.
    - Fields: `UserId`, `Role`, etc.
  - **AuthModel**: Represents authentication details.
    - Fields: `UserName`, `Token`, `ExpiresOn`, `Roles`, etc.
  - **LoginModel**: Represents login details.
    - Fields: `PhoneNumber`, `Password`, etc.
  - **RegisterModel**: Represents registration details.
    - Fields: `UserName`, `PhoneNumber`, `Password`, etc.

- **MembershipEntity**:
  - **Membership**: Represents membership details.
    - Fields: `Id`, `Type`, `Cost`, `Duration`, `Benefits`, etc.

- **PhotoSessionEntity**:
  - **PhotoSession**: Represents photo session details.
    - Fields: `Id`, `Title`, `Description`, `Date`, `Location`, etc.

### DTOs

DTOs (Data Transfer Objects) are used for efficient data transfer across different layers of the application.

## API Documentation

For detailed API documentation, please refer to [API_Documentation.md](./API_Documentation.md).


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




