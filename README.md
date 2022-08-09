# Baggage Tracking

## Description
> Find out where your baggage is by searching the `flycode` on the ticket. 
**FlyCode :** A unique `id` associated with each ticket.
> Since I could not find a suitable `Api`, I used static data in the database.
## Usage
### User Uses
> When you enter the `flycode` of the ticket, the following results are returned to you.
- If the flight time of the plane is long, you will be told "Wait for the tickets to be checked." message is displayed.
- Tickets are checked and luggage is handed over 4 hours before the flight.
	-  At this time, you can go to the `Tracking Baggage` section by entering the code of your ticket.All events are pending here.
	- After the luggage is delivered, the status of your luggage is "Expected". After the luggage is loaded on the plane, it becomes "Success".
	- After the plane takes off, it lands and when the luggage is emptied, you will receive information from whichever outlet it is transferred to. And you go to that exit.
### Staff Uses
> The FlyCode of each ticket is pasted on the tickets in the form of a QR code. The QR code is sent to the relevant links through QR code readers.
#### When baggage is checked in.	
- The flight code of the baggage is sent to this link.
	- `https://baggageplane.herokuapp.com/Stuffs/BaggageTakeOver/[FlayCode]`
#### Whenever the baggage is loaded, the baggage flycode is sent here.
- `https://baggageplane.herokuapp.com/Stuffs/AirplaneLoading/[FlayCode]`
#### After the plane lands and approaches the platform, the FlyCode of the ticket is sent here.
- `https://baggageplane.herokuapp.com/Stuffs/AirplaneLanded/[FlayCode]`
#### After the luggage is unloaded from the plane, the FlyCode of the ticket is sent here.
- `https://baggageplane.herokuapp.com/Stuffs/AirplaneLandedByUnloaded/[FlayCode]`
	
#### When baggage is routed to the exit, the FlyCod of the ticket is transmitted to this link.
- `https://baggageplane.herokuapp.com/Stuffs/AirplaneIsOut/[FlayCode]`
#### When the baggage leaves the exit, the FlyCode of the ticket and the Id of the exit platform are transferred to this link.
- `https://baggageplane.herokuapp.com/Stuffs/AirplaneIsOutByPlatform?platformId=[PlatfromId]&flyCode=[FlayCode]`
### Test Data
```cs
// ==================== Airport 
		new Airport { Id = 1,Name = "HEYDAR ALIYEV INTERNATIONAL AIRPORT"},
        new Airport { Id = 2,Name = "Ataturk Airport" },
        new Airport { Id = 3,Name = "Antalya Airport" }
// ==================== Platform 
        new Platform { Id = 1, Name = "A1", BaggageOutPoint = "Comes to A1 platform", AirportId = 1 },
        new Platform { Id = 2, Name = "B1", BaggageOutPoint = "Comes to B1 platform", AirportId = 1 },
        new Platform { Id = 3, Name = "A2", BaggageOutPoint = "Comes to A2 platform", AirportId = 1 },
        new Platform { Id = 4, Name = "B2", BaggageOutPoint = "Comes to B2 platform", AirportId = 1 },
        new Platform { Id = 5, Name = "C1", BaggageOutPoint = "Comes to C1 platform", AirportId = 1 },
        new Platform { Id = 6, Name = "C2", BaggageOutPoint = "Comes to C2 platform", AirportId = 1 },
        new Platform { Id = 7, Name = "A1", BaggageOutPoint = "Comes to A1 platform", AirportId = 2 },
        new Platform { Id = 8, Name = "B1", BaggageOutPoint = "Comes to B1 platform", AirportId = 2 },
        new Platform { Id = 9, Name = "A2", BaggageOutPoint = "Comes to A2 platform", AirportId = 2 },
        new Platform { Id = 10, Name = "B2", BaggageOutPoint = "Comes to B2 platform", AirportId = 2 },
        new Platform { Id = 11, Name = "C1", BaggageOutPoint = "Comes to C1 platform", AirportId = 2 },
        new Platform { Id = 12, Name = "C2", BaggageOutPoint = "Comes to C2 platform", AirportId = 2 },
        new Platform { Id = 13, Name = "A1", BaggageOutPoint = "Comes to A1 platform", AirportId = 3 },
        new Platform { Id = 14, Name = "B1", BaggageOutPoint = "Comes to B1 platform", AirportId = 3 },
        new Platform { Id = 15, Name = "A2", BaggageOutPoint = "Comes to A2 platform", AirportId = 3 },
        new Platform { Id = 16, Name = "B2", BaggageOutPoint = "Comes to B2 platform", AirportId = 3 },
        new Platform { Id = 17, Name = "C1", BaggageOutPoint = "Comes to C1 platform", AirportId = 3 },
        new Platform { Id = 18, Name = "C2", BaggageOutPoint = "Comes to C2 platform", AirportId = 3 }
// ==================== Ticket
        new Ticket
        {
            Id = 1,
            Name = "Orxan Salahov",
            FlyCode = "ASCSDDF11223232",
            FlyDate = DateTime.Now.AddDays(1),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 2,
            Name = "Əli Ocaqverdiyev",
            FlyCode = "ASCSEEF11223232",
            FlyDate = DateTime.Now.AddDays(1),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 3,
            Name = "Ehmed Salahov",
            FlyCode = "DDCSDDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 4,
            Name = "Veli Salahov",
            FlyCode = "VVCSDDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 5,
            Name = "Cavad Salahov",
            FlyCode = "CCCSDDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 6,
            Name = "Mahmud Salahov",
            FlyCode = "MMCSDDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 7,
            Name = "Mahmud Salahov",
            FlyCode = "MMCSFFDDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 8,
            Name = "Mahmud Salahov",
            FlyCode = "MMCSDSSDF11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 9,
            Name = "Vasif Salahov",
            FlyCode = "MMCSDDFDD11223232",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 1,
            ToAirportId = 2
        },
        new Ticket
        {
            Id = 10,
            Name = "Vidadi Salahov",
            FlyCode = "MMCSDDF11223232SS",
            FlyDate = DateTime.Now.AddMinutes(3),
            FromAirportId = 3,
            ToAirportId = 2
        }
// ==================== Baggage
 new Baggage { Id = 3, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
 new Baggage { Id = 4, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
 new Baggage { Id = 5, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
 new Baggage { Id = 6, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 2 },
 new Baggage { Id = 7, Weight = 26.56F, IsOutId = 1, LandedId = 2, LoadingId = 3 },
 new Baggage { Id = 8, Weight = 26.56F, IsOutId = 1, LandedId = 2, LoadingId = 3 },
 new Baggage { Id = 9, Weight = 26.56F, IsOutId = 2, LandedId = 3, LoadingId = 3 },
 new Baggage { Id = 10, Weight = 26.56F, IsOutId = 3, LandedId = 3, LoadingId = 3,OutPlatformId = 7 }

```
### Reset All Data 

- `https://baggageplane.herokuapp.com/Stuffs/Update/`