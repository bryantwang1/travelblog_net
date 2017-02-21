using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        public int Votes { get; set; }
        public string Description { get; set; }
        public bool HasBeenVisited { get; set; }
        public bool Approved { get; set; }
        public DateTime DateSuggested { get; set; }
        public virtual Location Location { get; set; }

    }
}