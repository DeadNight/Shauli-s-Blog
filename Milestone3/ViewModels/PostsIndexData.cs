using Milestone3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Milestone3.ViewModels
{
    public class PostsIndexData
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}