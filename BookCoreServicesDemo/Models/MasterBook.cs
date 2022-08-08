using System;
using System.Collections.Generic;

namespace BookCoreServicesDemo.Models
{
    public partial class MasterBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public string BookAuthor { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public DateTime PurchaseDate { get; set; }
    }
}
