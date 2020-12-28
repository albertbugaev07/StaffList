using System;
using System.Collections.Generic;
using System.Text;

namespace StaffList.Models
{
    public class PositionProcessing
    {
        public int Id { get; set; }

        public DateTime Momemt { get; set; }
        public int Qty { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


    }
}
