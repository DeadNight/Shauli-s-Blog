using Milestone3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Milestone3.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(): base("BlogContext")
        {
        }

        public DbSet<Fan> Fans { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}