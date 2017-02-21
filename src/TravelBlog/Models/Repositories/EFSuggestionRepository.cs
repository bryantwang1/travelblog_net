using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelBlog.Models
{
    public class EFSuggestionRepository : ISuggestionRepository
    {
        TravelBlogContext db = new TravelBlogContext();

        public EFSuggestionRepository(TravelBlogContext connection = null)
        {
            if (connection == null)
            {
                db = new TravelBlogContext();
            }
            else
            {
                db = connection;
            }
        }

        public IQueryable<Suggestion> Suggestions { get { return db.Suggestions; } }

        public IQueryable<Location> Locations { get { return db.Locations; } }
        public IQueryable<ApplicationUser> Users { get { return db.Users; } }

        public Suggestion Save(Suggestion suggestion)
        {
            db.Suggestions.Add(suggestion);
            db.SaveChanges();
            return suggestion;
        }

        public Location Save(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return location;
        }

        public Suggestion Edit(Suggestion suggestion)
        {
            db.Entry(suggestion).State = EntityState.Modified;
            db.SaveChanges();
            return suggestion;
        }

        public void Remove(Suggestion suggestion)
        {
            db.Remove(suggestion);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            List<Suggestion> allSuggestions = db.Suggestions.ToList();
            db.RemoveRange(allSuggestions);
            db.SaveChanges();
        }
    }
}
