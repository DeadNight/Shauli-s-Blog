namespace Milestone5.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Milestone5.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Milestone5.DAL.BlogContext context)
        {
            var posts = new List<Post>
            {
                new Post {
                    Title = "This is the title of a blog post",
                    AuthorName = "Mads Kjaer",
                    AuthorWebsite = "#",
                    PublishDate = DateTime.Parse("2009-06-29"),
                    Text = "Lorem ipsum dolor sit amet, tellus eu orci lacus blandit. Cras enim nibh, sodales ultricies elementum vel, fermentum id tellus. Proin metus odio, ultricies eu pharetra dictum, laoreet id odio. Curabitur in odio augue. Morbi congue auctor interdum. Phasellus sit amet metus justo. Phasellus vitae tellus orci, at elementum ipsum. In in quam eget diam adipiscing condimentum. Maecenas gravida diam vitae nisi convallis vulputate quis sit amet nibh. Nullam ut velit tortor. Curabitur ut elit id nisl volutpat consectetur ac ac lorem. Quisque non elit et elit lacinia lobortis nec a velit. Sed ac nisl sed enim consequat porttitor. Pellentesque ut sapien arcu, egestas mollis massa. Fusce lectus leo, fringilla at aliquet sit amet, volutpat non erat. Aenean molestie nibh vitae turpis venenatis vel accumsan nunc tincidunt. Suspendisse id purus vel felis auctor mattis non ac erat. Pellentesque sodales venenatis condimentum. Aliquam sit amet nibh nisi, ut pulvinar est. Sed ullamcorper nisi vel tortor volutpat eleifend. Vestibulum iaculis ullamcorper diam consectetur sagittis. Quisque vitae mauris ut elit semper condimentum varius nec nisl. Nulla tempus porttitor dolor ac eleifend. Proin vitae purus lectus, a hendrerit ipsum. Aliquam mattis lacinia risus in blandit. Vivamus vitae nulla dolor. Suspendisse eu lacinia justo. Vestibulum a felis ante, non aliquam leo. Aliquam eleifend, est viverra semper luctus, metus purus commodo elit, a elementum nisi lectus vel magna. Praesent faucibus leo sit amet arcu vehicula sed facilisis eros aliquet. Etiam sodales, enim sit amet mollis vestibulum, ipsum sapien accumsan lectus, eget ultricies arcu velit ut diam. Aenean fermentum luctus nulla, eu malesuada urna consequat in. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Pellentesque massa lacus, sodales id facilisis ac, lobortis sed arcu. Donec hendrerit fringilla ligula, ac rutrum nulla bibendum id. Cras sapien ligula, tincidunt eget euismod nec, ultricies eu augue. Nulla vitae velit sollicitudin magna mattis eleifend. Nam enim justo, vulputate vitae pretium ac, rutrum at turpis. Aenean id magna neque. Sed rhoncus aliquet viverra.",
                    ImageUrl = "/Content/images/flower.png",
                    VideoUrl = "/Content/images/shauli.m4v"
                }
            };

            posts.ForEach(post => context.Posts.AddOrUpdate(p => p.PublishDate, post));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment
                {
                    PostID = posts.Single(p => p.PublishDate == DateTime.Parse("2009-06-29")).ID,
                    Title = "Lorem ipsum",
                    AuthorName = "George Washington",
                    AuthorWebsite = "#",
                    PublishDate = DateTime.Parse("2009-06-29 23:35"),
                    Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut."
                },
                new Comment
                {
                    PostID = posts.Single(p => p.PublishDate == DateTime.Parse("2009-06-29")).ID,
                    Title = "Lorem ipsum",
                    AuthorName = "Benjamin Franklin",
                    AuthorWebsite = "#",
                    PublishDate = DateTime.Parse("2009-06-29 23:40"),
                    Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut."
                },
                new Comment
                {
                    PostID = posts.Single(p => p.PublishDate == DateTime.Parse("2009-06-29")).ID,
                    Title = "Lorem ipsum",
                    AuthorName = "Barack Obama",
                    AuthorWebsite = "#",
                    PublishDate = DateTime.Parse("2009-06-29 23:59"),
                    Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut."
                }
            };

            comments.ForEach(comment => context.Comments.AddOrUpdate(c => c.PublishDate, comment));
            context.SaveChanges();
        }
    }
}
