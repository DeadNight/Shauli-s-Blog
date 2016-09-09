using Milestone3.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Milestone3.Models
{
    public class Post
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Author Website")]
        public string AuthorWebsite { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PublishDate { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [DataType(DataType.ImageUrl)]
        public string VideoUrl { get; set; }

        public string FormattedPublishDate
        {
            get
            {
                return PublishDate.ToString("MMMM ") + PublishDate.Day.ToOrdinalString() + PublishDate.ToString(" yyyy");
            }
        }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}