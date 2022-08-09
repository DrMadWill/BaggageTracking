using BaggageTracking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaggageTracking.Controllers
{
    public class StuffsController : Controller
    {
        private readonly BaggageDbContext _dbContext;

        public StuffsController( BaggageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool BaggageTakeOver(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            var ticket = _dbContext.Tickets
                .Include(x => x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == id.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            ticket.Baggage.LoadingId = 2;
            

            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }


        public bool AirplaneLoading(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            var ticket = _dbContext.Tickets
                .Include(x=>x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == id.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            ticket.Baggage.LoadingId = 3;

            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AirplaneLanded(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            var ticket = _dbContext.Tickets
                .Include(x => x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == id.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            ticket.Baggage.LandedId = 2;

            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AirplaneLandedByUnloaded(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            var ticket = _dbContext.Tickets
                .Include(x => x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == id.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            ticket.Baggage.LandedId = 3;

            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AirplaneIsOut(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            var ticket = _dbContext.Tickets
                .Include(x => x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == id.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            ticket.Baggage.IsOutId = 2;
            
            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }

        public bool AirplaneIsOutByPlatform(int? platformId, string flyCode)
        {
            if (string.IsNullOrEmpty(flyCode) || platformId == null) return false;
            var ticket = _dbContext.Tickets
                .Include(x => x.Baggage)
                .FirstOrDefault(x => x.FlyCode.ToLower() == flyCode.ToLower());
            if (ticket == null || ticket?.Baggage == null) return false;

            var platform = _dbContext.Platforms.FirstOrDefault(p => p.Id == platformId);
            if (platform == null) return false;

            ticket.Baggage.IsOutId = 3;
            ticket.Baggage.OutPlatformId = platform?.Id;

            _dbContext.Update(ticket.Baggage);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Update()
        {
            var tickets = _dbContext.Tickets.Include(x => x.Baggage)
                .ToList();

            foreach (var item in tickets.Take(3))
            {
                item.Baggage.LoadingId = 1;
                item.Baggage.LandedId = 1;
                item.Baggage.OutPlatformId = 1;
                item.FlyDate = DateTime.Now.AddDays(1);
                _dbContext.Update(item);
            }

            foreach (var item in tickets.Skip(3).Take(5))
            {
                item.Baggage.LoadingId = 1;
                item.Baggage.LandedId = 1;
                item.Baggage.OutPlatformId = 1;
                item.FlyDate = DateTime.Now.AddHours(3);
                _dbContext.Update(item);
            }

            _dbContext.SaveChanges();
            return true;
        }


    }
}
