using StaffList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffList
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public List<PositionProcessing> positionProcessings { get; set; }
    }    
}
