## API Documentation

### AccountController

- **Register**
  - **POST /api/account/register**
  - Description: Register a new user account.
  - Request Body: `RegisterModel`
  - Returns: Registration details including token and roles.

- **Login**
  - **POST /api/account/login**
  - Description: Log in an existing user.
  - Request Body: `LoginModel`
  - Returns: Login details including token and roles.

- **Add Role**
  - **POST /api/account/addrole**
  - Description: Adds a role to a user. Admin access required.
  - Request Body: `AddRoleModel`
  - Returns: Confirmation message.

### BirthdayController

- **Create Birthday**
  - **POST /api/birthday**
  - Description: Create a new birthday event.
  - Request Body: `BirthdayToCreateDto`
  - Returns: Details of the created birthday event.

- **Update Birthday**
  - **PUT /api/birthday/{id}**
  - Description: Update details of an existing birthday event.
  - Request Body: `BirthdayDto`
  - Parameters: `id` (integer)
  - Returns: No content.

- **Get Birthday by ID**
  - **GET /api/birthday/{id}**
  - Description: Retrieve details of a specific birthday event by ID.
  - Parameters: `id` (integer)
  - Returns: `BirthdayDto` if found; otherwise, "Not Found".

- **Get All Birthdays**
  - **GET /api/birthday**
  - Description: Retrieve a list of all birthday events.
  - Returns: List of `BirthdayDto`.

- **Delete Birthday**
  - **DELETE /api/birthday/{birthdayId}**
  - Description: Delete a specific birthday event by ID.
  - Parameters: `birthdayId` (integer)
  - Returns: No content.

### BookingController

- **Create Booking**
  - **POST /api/booking**
  - Description: Create a new booking.
  - Request Body: `BookingToCreateDto`
  - Returns: Details of the created booking.

- **Update Booking**
  - **PUT /api/booking/{bookingId}**
  - Description: Update an existing booking.
  - Request Body: `BookingDto`
  - Parameters: `bookingId` (integer)
  - Returns: No content.

- **Create Payment Session**
  - **POST /api/booking/create-payment**
  - Description: Initiates a payment session for a booking.
  - Request Body: `PaymentDto`
  - Returns: URL of the created payment session.

- **Update Payment Intent**
  - **POST /api/booking/update-payment-intent**
  - Description: Update the payment intent ID for a booking.
  - Request Body: `UpdatePaymentIntentDto`
  - Returns: Confirmation message.

- **Check Payment Status**
  - **GET /api/booking/check-payment-status/{bookingId}**
  - Description: Checks the payment status for a specific booking.
  - Parameters: `bookingId` (integer)
  - Returns: Payment status of the booking.

- **Delete Booking**
  - **DELETE /api/booking/{bookingId}**
  - Description: Delete a specific booking by ID.
  - Parameters: `bookingId` (integer)
  - Returns: No content.

### CartController

- **Get Cart**
  - **GET /api/cart?id=**
  - Description: Retrieve the contents of a specific cart.
  - Parameters: `id` (string)
  - Returns: Details of the cart or a new cart if not found.

- **Get All Carts**
  - **GET /api/cart/all**
  - Description: Retrieve a list of all carts.
  - Returns: List of `CustomerCart`.

- **Update Cart**
  - **POST /api/cart**
  - Description: Update or create a cart.
  - Request Body: `CustomerCartDto`
  - Returns: Details of the updated or created cart.

- **Delete Cart**
  - **DELETE /api/cart**
  - Description: Delete a specific cart by ID.
  - Parameters: `id` (string)
  - Returns: No content.

### HomeController

- **Get Menu Items**
  - **GET /api/home/menu-items**
  - Description: Retrieve a list of menu items.
  - Returns: List of `MenuItemDto`.

- **Get Rooms**
  - **GET /api/home/rooms**
  - Description: Retrieve a list of all rooms.
  - Returns: List of `RoomDto`.

- **Get Memberships**
  - **GET /api/home/memberships**
  - Description: Retrieve a list of all memberships.
  - Returns: List of `MembershipDto`.

- **Get Birthdays**
  - **GET /api/home/birthdays**
  - Description: Retrieve a list of all birthdays.
  - Returns: List of `BirthdayDto`.

- **Get Photo Sessions**
  - **GET /api/home/photosessions**
  - Description: Retrieve a list of all photo sessions.
  - Returns: List of `PhotoSessionDto`.

### MembershipController

- **Create Membership**
  - **POST /api/membership**
  - Description: Create a new membership.
  - Request Body: `MembershipToCreateDto`
  - Returns: Details of the created membership.

- **Update Membership**
  - **PUT /api/membership/{id}**
  - Description: Update an existing membership.
  - Request Body: `MembershipDto`
  - Parameters: `id` (integer)
  - Returns: No content.

- **Get Membership by ID**
  - **GET /api/membership/{id}**
  - Description: Retrieve a specific membership by ID.
  - Parameters: `id` (integer)
  - Returns: `MembershipDto` if found; otherwise, "Not Found".

- **Get All Memberships**
  - **GET /api/membership**
  - Description: Retrieve a list of all memberships.
  - Returns: List of `MembershipDto`.

- **Delete Membership**
  - **DELETE /api/membership/{id}**
  - Description: Delete a specific membership by ID.
  - Parameters: `id` (integer)
  - Returns: No content.

### MenuItemsController

- **Create Menu Item**
  - **POST /api/menuitems**
  - Description: Create a new menu item.
  - Request Body: `MenuItemToCreateDto`
  - Returns: Details of the created menu item.

- **Update Menu Item**
  - **PUT /api/menuitems/{id}**
  - Description: Update an existing menu item.
  - Request Body: `MenuItemToCreateDto`
  - Parameters: `id` (integer)
  - Returns: No content.

- **Get Menu Item by ID**
  - **GET /api/menuitems/{id}**
  - Description: Retrieve a specific menu item by ID.
  - Parameters: `id` (integer)
  - Returns: `MenuItemDto` if found; otherwise, "Menu item not found."

- **Get All Menu Items**
  - **GET /api/menuitems**
  - Description: Retrieve a list of all menu items.
  - Returns: List of `MenuItemDto`.

- **Get Menu Items by Category**
  - **GET /api/menuitems/category/{category}**
  - Description: Retrieve menu items by category.
  - Parameters: `category` (string)
  - Returns: List of `MenuItemDto`.

- **Delete Menu Item**
  - **DELETE /api/menuitems/{id}**
  - Description: Delete a specific menu item by ID.
  - Parameters: `id` (integer)
  - Returns: No content.

### OrdersController

- **Create Order**
  - **POST /api/orders**
  - Description: Create a new order.
  - Request Body: `OrderDto`
  - Returns: Details of the created order and payment session information.

- **Get Orders for User**
  - **GET /api/orders/user-orders**
  - Description: Retrieve all orders for the logged-in user.
  - Returns: List of `OrderDto`.

- **Get Order by ID**
  - **GET /api/orders/{id}**
  - Description: Retrieve a specific order by ID.
  - Parameters: `id` (integer)
  - Returns: `OrderDto` if found; otherwise, "Order not found."

- **Create Payment Session for Order**
  - **POST /api/orders/payment**
  - Description: Initiate a payment session for an order.
  - Request Body: `PaymentDto`
  - Returns: Payment session details including URL.

- **Check Order Payment Status**
  - **GET /api/orders/check-order-payment-status/{orderId}**
  - Description: Check the payment status of a specific order.
  - Parameters: `orderId` (integer)
  - Returns: Payment status of the order.

- **Update Payment Intent**
  - **POST /api/orders/update-payment-intent**
  - Description: Update the payment intent ID for an order.
  - Request Body: `UpdatePaymentIntentDto`
  - Returns: Confirmation message.

- **Delete Order**
  - **DELETE /api/orders/{orderId}**
  - Description: Delete a specific order by ID.
  - Parameters: `orderId` (integer)
  - Returns: No content.

### PhotoSessionController

- **Create Photo Session**
  - **POST /api/photosession**
  - Description: Create a new photo session.
  - Request Body: `PhotoSessionToCreateDto`
  - Returns: Details of the created photo session.

- **Update Photo Session**
  - **PUT /api/photosession/{id}**
  - Description: Update an existing photo session.
  - Request Body: `PhotoSessionDto`
  - Parameters: `id` (integer)
  - Returns: No content.

- **Get Photo Session by ID**
  - **GET /api/photosession/{id}**
  - Description: Retrieve a specific photo session by ID.
  - Parameters: `id` (integer)
  - Returns: `PhotoSessionDto` if found; otherwise, "Photo session not found."

- **Get All Photo Sessions**
  - **GET /api/photosession**
  - Description: Retrieve a list of all photo sessions.
  - Returns: List of `PhotoSessionDto`.

- **Delete Photo Session**
  - **DELETE /api/photosession/{id}**
  - Description: Delete a specific photo session by ID.
  - Parameters: `id` (integer)
  - Returns: No content.

### RoomController

- **Create Room**
  - **POST /api/rooms**
  - Description: Create a new room.
  - Request Body: `RoomToCreateDto`
  - Returns: Details of the created room.

- **Update Room**
  - **PUT /api/rooms/{id}**
  - Description: Update an existing room.
  - Request Body: `RoomDto`
  - Parameters: `id` (integer)
  - Returns: No content.

- **Get Room by ID**
  - **GET /api/rooms/{id}**
  - Description: Retrieve a specific room by ID.
  - Parameters: `id` (integer)
  - Returns: `RoomDto` if found; otherwise, "Room not found."

- **Get All Rooms**
  - **GET /api/rooms**
  - Description: Retrieve a list of all rooms.
  - Returns: List of `RoomDto`.

- **Delete Room**
  - **DELETE /api/rooms/{roomId}**
  - Description: Delete a specific room by ID.
  - Parameters: `roomId` (integer)
  - Returns: No content.
