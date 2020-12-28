using StaffList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaffList
{
    public class PosHandling
    {

        public static void ShowHendlingList()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var positionProcessing = db.PositionProcessings.ToList();
                var user = db.Users.ToList();
                 
                Console.WriteLine("Текущий список обработки:");
                foreach (PositionProcessing p in positionProcessing)
                {
                    Console.WriteLine($"{p.Id}. {p.Momemt}, пользователь - {p.User.Name}, количество {p.Qty}");
                }
                Console.WriteLine();
            }
        }

        public static void ShowHendlingListDay()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var positionProcessing = db.PositionProcessings.ToList();
                var user = db.Users.ToList();
                int currentDay = DateTime.Now.Day;
                var dayNow = DateTime.Now;


                Console.WriteLine($"Текущий список обработки на {dayNow.ToShortDateString()}:");
                Console.WriteLine();
                foreach (User u in user)
                {
                    int sumMonth = db.PositionProcessings.Where(p => p.User == u)
                                                                           .Where(p => p.Momemt.Day == currentDay)
                                                                           .Sum(p => p.Qty);

                    Console.WriteLine($"{u.Id}. Пользователь - {u.Name}, количество {sumMonth}");
                }
                Console.WriteLine();
            }
        }

        public static void ShowHendlingListMonth()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var positionProcessing = db.PositionProcessings.ToList();
                var user = db.Users.ToList();
                int currentMonth = DateTime.Now.Month;
                var monthNow = DateTime.Now;


                Console.WriteLine($"Текущий список обработки на {monthNow.ToString("Y")}:");
                foreach (User u in user)
                {
                    int sumMonth = db.PositionProcessings.Where(p => p.User == u)
                                                                           .Where(p => p.Momemt.Month == currentMonth)
                                                                           .Sum(p => p.Qty);

                    Console.WriteLine($"{u.Id}. Пользователь - {u.Name}, количество {sumMonth}");
                }
                Console.WriteLine();
            }
        }
    }
}
