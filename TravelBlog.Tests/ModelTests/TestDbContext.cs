using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBlog.Models;

namespace TravelBlog.Tests.ModelTests
{
    public class TestDbContext : TravelBlogContext
    {
        public override DbSet<Suggestion> Suggestions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TravelBlogTest;integrated security = True");
        }
    }
}
