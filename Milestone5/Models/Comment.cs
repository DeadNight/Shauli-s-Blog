using Milestone5.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Milestone5.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Author Website")]
        public string AuthorWebsite { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public string FormattedPublishDate
        {
            get
            {
                return PublishDate.ToString("MMMM ") + PublishDate.Day.ToOrdinalString() + PublishDate.ToString(" yyyy 'at' HH:mm");
            }
        }

        public virtual Post Post { get; set; }
    }
}