using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class OrganizationData
    {
        public string name { get; set; }
        public List<DepartmentOrgData> children;
    }

    public class DepartmentOrgData
    {
        public string name { get; set; }
        public List<CourseOrgData> children { get; set; }
    }

    public class CourseOrgData
    {
        public string name { get; set; }
        public List<InstructorOrgData> children { get; set; }
    }

    public class InstructorOrgData
    {
        public string name { get; set; }
    }
}