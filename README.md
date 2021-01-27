# Async Inn

## Author

JP Jones
## Date

1/26/21

![Lab-11 ERD](./assets/ERD_11.png)

## Tables

### Room - Table
(Hotel/Room) 1:Many  - Many Hotels can have this room
(Room/Amenities) 1:Many - One room can have many Amenities

### HotelRoom - Pure Join Table

(Room) Many:1 - A Hotel can have many rooms
(Hotel) Many:1 - One hotel can have many rooms

###  Hotel - Table

(Hotel/Room) 1:Many - A Hotel can have many rooms

### RoomAmenities - Pure Join Table

(Room) Many:1 - 1 Room can have many amenities
(Amenities) Many:1 - Many Amenities can be in one room

### Amenities - Table

(Room/Amenities) 1:Many - Many Rooms can have and amenity






