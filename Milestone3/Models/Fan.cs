using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Milestone3.Models
{
    public enum Gender
    {
        Male, Female
    }

    public class Fan
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }

        public int ClubSeniority
        {
            get
            {
                DateTime now = DateTime.Now;
                int years = now.Year - JoinDate.Year;

                if (now.Month > JoinDate.Month)
                    return years;
                if (now.Month < JoinDate.Month)
                    return years - 1;
                if (now.Day < JoinDate.Day)
                    return years - 1;
                return years;
            }
        }
    }
}