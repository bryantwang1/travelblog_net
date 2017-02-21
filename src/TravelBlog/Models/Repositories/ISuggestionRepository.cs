using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface ISuggestionRepository
    {
        IQueryable<Suggestion> Suggestions { get; }
        IQueryable<Location> Locations { get; }
        IQueryable<ApplicationUser> Users { get; }
        Suggestion Save(Suggestion suggestion);
        Suggestion Edit(Suggestion suggestion);
        void Remove(Suggestion suggestion);
        void DeleteAll();
    }
}
