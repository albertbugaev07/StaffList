using StaffList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace StaffList
{
    public class ProgMenu
    {
        
        public static void Chois()
        {
            Validation v = new Validation();
            int currentUserId = Validation.Check();
            Console.Clear();
            Menu:
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("P - работать с кодировкой");
                Console.WriteLine("U - работать с базой пользователей");
                Console.WriteLine("C - очистить консоль");
                Console.WriteLine("Q - выйти из приложения");
                Console.WriteLine();
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    //очистить консоль
                    case ConsoleKey.C:
                        Console.Clear();
                        break;

                    //работа с кодировкой
                    case ConsoleKey.P:
                        
                        while (true)
                        {
                            Console.WriteLine("Что вы хотите сделать?");
                            Console.WriteLine("A - добавить позиции");
                            Console.WriteLine("C - очистить консоль");
                            Console.WriteLine("D - показать суммарное количество за день по пользователям.");
                            Console.WriteLine("M - показать суммарное количество за месяц по пользователям.");
                            Console.WriteLine("S - показать текущие записи в БД");
                            Console.WriteLine("Q - выйти в меню");
                            Console.WriteLine();
                            int currentMonth = DateTime.Now.Month;
                            int currentDay = DateTime.Now.Day;

                            var pKey = Console.ReadKey();
                            Console.WriteLine();

                            switch (pKey.Key) 
                            {
                                //очистить консоль
                                case ConsoleKey.C:
                                    Console.Clear();
                                    break;

                                //суммарное количество за день по пользователям
                                case ConsoleKey.D:
                                    PosHandling.ShowHendlingListDay();
                                    break;

                                //суммарное количество за месяц по пользователям
                                case ConsoleKey.M:
                                    PosHandling.ShowHendlingListMonth();
                                    break;

                                //выйти в меню
                                case ConsoleKey.Q:
                                    goto Menu;
                                    

                                //добавить позиции
                                case ConsoleKey.A:
                                    using (ApplicationContext db = new ApplicationContext())
                                    {

                                        Console.WriteLine("Введите количество позиций");
                                        var qty = Convert.ToInt32(Console.ReadLine());

                                        PositionProcessing positionProcessing = new PositionProcessing { Momemt = DateTime.Now, Qty = qty, UserId = currentUserId };

                                        db.PositionProcessings.Add(positionProcessing);
                                        db.SaveChanges();

                                        Console.WriteLine();
                                        Console.WriteLine("Запись добавлена в БД");
                                        Console.WriteLine();
                                    }
                                    break;

                                //показать текущие записи в БД
                                case ConsoleKey.S:
                                    PosHandling.ShowHendlingList();
                                    break;

                                default:
                                    Console.WriteLine("Данное действие не найдено");
                                    Console.WriteLine();
                                    break;
                            }
                        }

                    //работа с базой пользователей
                    case ConsoleKey.U:
                        Console.Clear();
                        while (true)
                        {


                            Console.WriteLine("Введите действие для работы с БД пользователей:");
                            Console.WriteLine("L - вывести список пользователей");
                            Console.WriteLine("A - добавить пользователя");
                            Console.WriteLine("E - редактировать данные пользователя");
                            Console.WriteLine("D - удалить пользователя");
                            Console.WriteLine("C - очистить консоль");
                            Console.WriteLine("Q - выйти в меню");
                            Console.WriteLine();

                            var uKey = Console.ReadKey();
                            Console.WriteLine();
                            switch (uKey.Key)
                            {
                                case ConsoleKey.C:
                                    Console.Clear();
                                    break;
                                //List of Users
                                case ConsoleKey.L:
                                    using (ApplicationContext db = new ApplicationContext())
                                    {
                                        var users = db.Users.ToList();
                                        Console.WriteLine("Текущий список пользователей:");
                                        foreach (User u in users)
                                        {
                                            Console.WriteLine($"{u.Id}. {u.Name}, телефон {u.Phone}, почта {u.Email}");
                                        }
                                        Console.WriteLine();
                                    }
                                    break;

                                //Add new User
                                case ConsoleKey.A:
                                    using (ApplicationContext db = new ApplicationContext())
                                    {
                                        Console.WriteLine("Введите имя нового пользователя:");
                                        var name = Console.ReadLine();

                                        Console.WriteLine("Введите номер телефона:");
                                        var phone = Console.ReadLine();

                                        Console.WriteLine("Введите email:");
                                        var email = Console.ReadLine();

                                        Console.WriteLine("Введите login:");
                                        var login = Console.ReadLine();

                                        Console.WriteLine("Введите password:");
                                        var pass = Console.ReadLine();


                                        User user = new User { Name = name, Phone = phone, Email = email, Login = login, Pass = pass };

                                        db.Users.Add(user);
                                        db.SaveChanges();

                                        Console.WriteLine();
                                        Console.WriteLine("Пользователь добавлен.");

                                    }
                                    break;

                                //Delete User 
                                case ConsoleKey.D:
                                    using (ApplicationContext db = new ApplicationContext())
                                    {
                                        Console.WriteLine("Введите имя пользователя для удаления:");

                                        var nameDel = Console.ReadLine();

                                        User user = db.Users.Where(u => u.Name == nameDel).FirstOrDefault();
                                        if (user != null)
                                        {
                                            db.Users.Remove(user);
                                            db.SaveChanges();
                                        }

                                        Console.WriteLine();
                                        Console.WriteLine("Пользователь удалён.");
                                    }
                                    break;

                                //Edit User
                                case ConsoleKey.E:
                                    using (ApplicationContext db = new ApplicationContext())
                                    {
                                        Console.WriteLine("Введите имя пользователя для редактирования:");
                                        var name = Console.ReadLine();

                                        User user = db.Users.Where(u => u.Name == name).FirstOrDefault();

                                        while (true)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Какой параметр Вы хотите изменить?");
                                            Console.WriteLine("N - имя пользователя");
                                            Console.WriteLine("T - номер телефона");
                                            Console.WriteLine("E - email");
                                            Console.WriteLine("L - login");
                                            Console.WriteLine("P - password");

                                            var editKey = Console.ReadKey();
                                            Console.WriteLine();
                                            switch (editKey.Key)
                                            {
                                                case ConsoleKey.N:
                                                    if (user != null)
                                                    {
                                                        Console.WriteLine("Введите новое имя пользователя:");
                                                        user.Name = Console.ReadLine();
                                                    }
                                                    break;

                                                case ConsoleKey.T:
                                                    if (user != null)
                                                    {
                                                        Console.WriteLine("Введите новый номер телефона:");
                                                        user.Phone = Console.ReadLine();
                                                    }
                                                    break;

                                                case ConsoleKey.E:
                                                    if (user != null)
                                                    {
                                                        Console.WriteLine("Введите новый email:");
                                                        user.Email = Console.ReadLine();
                                                    }
                                                    break;

                                                case ConsoleKey.L:
                                                    if (user != null)
                                                    {
                                                        Console.WriteLine("Введите новый login:");
                                                        user.Login = Console.ReadLine();
                                                    }
                                                    break;

                                                case ConsoleKey.P:
                                                    if (user != null)
                                                    {
                                                        Console.WriteLine("Введите новый password:");
                                                        user.Pass = Console.ReadLine();
                                                    }
                                                    break;

                                                default:
                                                    Console.WriteLine();
                                                    Console.WriteLine("Данный параметр не найден");
                                                    break;
                                            }
                                            Console.WriteLine("");
                                            Console.WriteLine("Редактирование пользователя завершено? да / нет");

                                            var answ = Console.ReadLine();

                                            if (answ == "да")
                                            {
                                                break;
                                            }
                                            else if (answ != "нет")
                                            {
                                                Console.WriteLine("");
                                                Console.WriteLine("Ответ не распознан");
                                            }
                                        }


                                        db.Users.Update(user);
                                        db.SaveChanges();

                                        Console.WriteLine("");
                                        Console.WriteLine("Пользователь обновлён.");
                                    }
                                    break;

                                //выйти в меню
                                case ConsoleKey.Q:
                                    goto Menu;

                                default:
                                    Console.WriteLine("");
                                    Console.WriteLine("Действие не опознано. Повторите ввод.");

                                    break;

                            }
                        }
                        

                    //выход из приложения
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:                        
                        Console.WriteLine("Данное действие не найдено");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
