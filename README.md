# Async Inn
## Author

JP Jones
## Date

1/25/21

![Lab-11 ERD](./assets/ERD_11.png)

## Tables

### Location

This is the table with all the data associated with one of the Async Hotels

This table is also liked with a 1:1 with location Room.
Location provides it's data with One LocationRoom

### Location Room

Is the Joint Entity Table with a Payload.
Take data from the Location Table and the Room Table for use in providing a price

It has a Many:1 with Location. Many rooms can be at one location.
It also has a 1:1 with Room, only one room type can be tied to the location


### Room

Table that will house all the pertinent data for the room.
It has a Many:Many with RoomLayout.  Many different room id's can have room layouts.
Has a 1:1 with LocationRoom due to the room can only have one Location
Contains a NickName Enum to allow only one selection of layout type.
Bool for petFriendly to determine if the room is "pet friendly"


###  RoomLayout

The table is a Pure Join Table.  Able to provide Room ID with nickName ID
The connections to Room and Layout By Nickname are Many:Many as many different rooms can have many different nicknames

### Layout By Nickname

This is a table that will house
+ Floor plans
+ Name
+ Amenities

It is a Many:Many with RoomLayout as many rooms can have many different layouts.




