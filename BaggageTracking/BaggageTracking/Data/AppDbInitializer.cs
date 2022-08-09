using BaggageTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace BaggageTracking.Data
{
    public static class AppDbInitializer
    {

        public static void ApplyDbSeedData(ModelBuilder builder)
        {
            builder.Entity<Airport>()
                .HasData(
                    new Airport { Id = 1,Name = "HEYDAR ALIYEV INTERNATIONAL AIRPORT"},
                    new Airport { Id = 2,Name = "Ataturk Airport" },
                    new Airport { Id = 3,Name = "Antalya Airport" }
                );

            builder.Entity<Platform>()
                .HasData(
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
                );

            builder.Entity<Ticket>()
                .HasData(
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
                );

            

            builder.Entity<Status>()
                .HasData(
                    new Status { Id = 1, Name = "Waiting" , ClassName ="btn-secondary", Icon= "fa-solid fa-hand" },
                    new Status { Id = 2, Name= "Expected", ClassName ="btn-warning", Icon= "fa-solid fa-spinner fa-spin" },
                    new Status { Id = 3, Name = "Success", ClassName="btn-success", Icon = "fa-solid fa-circle-check" }
                );

            builder.Entity<Baggage>()
                .HasData(
                    new Baggage { Id = 3, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
                    new Baggage { Id = 4, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
                    new Baggage { Id = 5, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 1 },
                    new Baggage { Id = 6, Weight = 26.56F, IsOutId = 1, LandedId = 1, LoadingId = 2 },
                    new Baggage { Id = 7, Weight = 26.56F, IsOutId = 1, LandedId = 2, LoadingId = 3 },
                    new Baggage { Id = 8, Weight = 26.56F, IsOutId = 1, LandedId = 2, LoadingId = 3 },
                    new Baggage { Id = 9, Weight = 26.56F, IsOutId = 2, LandedId = 3, LoadingId = 3 },
                    new Baggage { Id = 10, Weight = 26.56F, IsOutId = 3, LandedId = 3, LoadingId = 3,OutPlatformId = 7 }
                );



        }



    }
}
