using StaffList.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaffList
{
    public class AddBase
    {
        public static void AddStartData()
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                

                User user1 = new User { Name = "Albert", Email = "aa@aa.aa", Phone = "123456", Login = "bugaev", Pass = "xherwo",};
                db.Users.Add(user1);

                PositionProcessing positionProcessing1 = new PositionProcessing { Momemt = DateTime.Now, Qty = 4, User = user1};
                db.PositionProcessings.Add(positionProcessing1);

                db.SaveChanges();
            }            
        }
    }
}
