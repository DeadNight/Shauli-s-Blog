using Milestone2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Milestone2.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(): base("BlogContext")
        {
        }

        public DbSet<Fan> Fans { get; set; }
    }
}