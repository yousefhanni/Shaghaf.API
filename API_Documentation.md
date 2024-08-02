## API Documentation

### BookingController
- **Create Booking**
  - **POST /api/booking**
  - Description: Create a new booking.
  - Request Body: `BookingDto`
  - Returns: Details of the created booking.

- **Get Booking Details**
  - **GET /api/booking/{bookingId}**
  - Description: Retrieves the details of a specific booking by ID.
  - Parameters: `bookingId` (integer)
  - Returns: Booking details if found; otherwise, returns "Booking Not Found !!"

- **Get All Bookings**
  - **GET /api/booking**
  - Description: Retrieves all bookings.
  - Returns: List of all booking details.

- **Create Payment Session**
  - **POST /api/booking/payment**
  - Description: Initiates a payment session for a booking.
  - Request Body: `PaymentDto`
  - Returns: URL of the created payment session.

- **Check Payment Status**
  - **GET /api/booking/payment/check-status/{bookingId}**
  - Description: Checks the payment status for a specific booking.
  - Parameters: `bookingId` (integer)
  - Returns: Payment status of the booking.

### HomeController
- **Get Home Data**
  - **GET /api/home**
  - Description: Retrieves general home data.

- **Get Memberships**
  - **GET /api/home/memberships**
  - Description: Retrieves membership information.

- **Get Birthdays**
  - **GET /api/home/birthdays**
  - Description: Retrieves birthday details.

- **Get Photo Sessions**
  - **GET /api/home/photosessions**
  - Description: Retrieves details of photo sessions.

- **Get Advertisements**
  - **GET /api/home/advertisements**
  - Description: Retrieves advertisement information.

- **Get Categories**
  - **GET /api/home/categories**
  - Description: Retrieves list of categories.

### RoomsController
- **Get All Rooms**
  - **GET /api/rooms**
  - Description: Retrieves a list of all rooms.
  - Returns: List of `RoomDto`

- **Get Room by ID**
  - **GET /api/rooms/{id}**
  - Description: Retrieves details of a specific room by ID.
  - Parameters: `id` (integer)
  - Returns: `RoomDto` if found; otherwise, "This Room Does not exist!!"

- **Create Room**
  - **POST /api/rooms**
  - Description: Creates a new room with details provided.
  - Request Body: `RoomToCreateDto`
  - Returns: Details of the created room if successful; otherwise, "Invalid Create!!"
