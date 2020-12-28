using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StaffList
{
    public class Validation
    {
        public Validation()
        {
                
        }
       
        public static int Check()
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Введите имя пользователя:");

                var userName = Console.ReadLine();

                Console.WriteLine("");
                Console.WriteLine("Введите пароль:");

                var userPass = Console.ReadLine();

                using (ApplicationContext db = new ApplicationContext())
                {
                    User user = db.Users.Where(u => u.Login == userName).FirstOrDefault();
                    var currentUser = db.Users.SingleOrDefault(u => u.Name == userName);


                    if (user != null)
                    {
                        if(user.Pass == userPass)
                        {
                            Console.Clear();
                            Console.WriteLine("Go!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            var userId = user.Id;
                            return userId;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Неверное имя пользователя или пароль");
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Неверное имя пользователя или пароль");
                    }
                }
                
            }
            
        }

        

        
    }
}
