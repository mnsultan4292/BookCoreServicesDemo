using System;
using System.Collections.Generic;

namespace BookCoreServicesDemo.Models
{
    public partial class CourseTab
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
