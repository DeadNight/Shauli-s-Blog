using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public int? EnrollmentYear { get; set; }

        public int StudentCount { get; set; }
    }
}