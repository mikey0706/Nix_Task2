using AutoMapper;
using BusinessLayer;
using BusinessLayer.DTO;
using Nix_Task2.Controllers;
using Nix_Task2.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Nix_Task2
{
    class Program
    {
        private static HomePageController home;
        private static VisitorController visitor;
        private static RoomController room;

        
        static void Main(string[] args)
        {

            HomePage();

            Console.ReadLine();
        }

        //Создаём строку с Датой
        private static string DateStringCreator() 
        { 
            string st = string.Empty;
            StringBuilder sb = new StringBuilder(st);
            string[] values = { "Месяц(мм): ", "День(дд): ", "Год(гггг): "};

            for (int i = 0; i< values.Length; ++i) 
            {
                Console.Write(values[i]);
                string s = $"{Console.ReadLine()}.";

                sb.Append(s);
            }
            return DateTime.ParseExact(sb.ToString().Substring(0, 10), "MM.dd.yyyy", CultureInfo.InvariantCulture).ToShortDateString();

        }

        //Главная
        public static void HomePage() 
        {
            home = new HomePageController();
            Console.WriteLine("Заселения: ");
            home.RoomsVisitorsInfo();

            int opt = 10;

            while (opt!=0)
            {
                
                Console.WriteLine("Выберите номер действия");
                Console.WriteLine("1) Просмотреть информацию о постояльцах.");
                Console.WriteLine("2) Просмотреть информацию о номерах.");
                Console.WriteLine("3) Поиск свободного номера.");
                Console.WriteLine("4) Забронировать номер");
                Console.WriteLine("Нажмите 0 для выхода");

                opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    AllVisitors();
                }
                else
                if (opt == 2)
                {
                    AllRooms();
                }
                else
                if (opt == 3)
                {
                    string date = DateStringCreator();
                    FindRoom(date);
                }
                else
                if (opt == 4)
                {
                    BookRoom();
                }
                else 
                if(opt == 0)
                {
                    Environment.Exit(0);
                }
            }
        }

        //Пользователи
        public static void AllVisitors() 
        {
            visitor = new VisitorController();

            List<VisitorView> vstr = visitor.VisitorsInfo;

            foreach (var v in vstr)
            {
                Console.WriteLine($"ID: {v.Id} - Имя: {v.Name} - Пасспорт: {v.Passport} - Дата рождения: {v.DateOfBirth}");
            }

            int opt = 10;

            while (opt!= 0) 
            {
                Console.WriteLine("Выберите номер операции:");
                Console.WriteLine("1) Добавить посетителя.");
                Console.WriteLine("2) Удалить посетителя.");
                Console.WriteLine("3) Найти посетителя.");
                Console.WriteLine("Нажмите 0 для выхода");

                opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    CreateVisitor(visitor);
                }
                else
                if (opt == 2)
                {
                    RemoveVisitor(visitor);
                }
                else
                if(opt==3)
                {
                    Console.Write("Введите имя пользователя. ");
                    var vis = visitor.FindVisitor(Console.ReadLine());
                    Console.WriteLine($"Имя: {vis.Name}\nПаспорт: {vis.Passport}\nДата рождения: {vis.DateOfBirth}");
                    opt = 10;
                }

            }
            HomePage();
        }

        //Создаём пользователя
        public static void CreateVisitor(VisitorController vis)
        {
            Console.Write("Укажите имя посетителя: ");
            string name = Console.ReadLine();
            Console.Write("Укажите паспорт: ");
            string passport = Console.ReadLine();
            Console.Write("Укажите дату рождения: ");
            string date = DateStringCreator();

            var v = new VisitorView
            {
                Name = name,
                Passport = passport,
                DateOfBirth = date
            };

            vis.AddVisitor(v);

            AllVisitors();
        }

        //Удаляем пользователя
        public static void RemoveVisitor(VisitorController vis)
        {
            Console.Write("Введите ID пользователя которго хотите удалить: ");
            vis.DeleteVisitor(Convert.ToInt32(Console.ReadLine()));

            AllVisitors();
        }


        //Комнаты
        public static void AllRooms() 
        {
            room = new RoomController();

            room.RoomsInfo();

            int opt = 10;

            while (opt != 0)
            {
                Console.WriteLine("Выберите номер операции:");
                Console.WriteLine("1) Добавить комнату.");
                Console.WriteLine("2) Удалить комнату.");
                Console.WriteLine("Нажмите 0 для выхода");

                opt = Convert.ToInt32(Console.ReadLine());

                if (opt == 1)
                {
                    CreateRoom(room);
                }
                else
                if (opt == 2)
                {
                    RemoveRoom(room);
                }
            }

            HomePage();
        }
        //Создаём комнату
        public static void CreateRoom(RoomController room) 
        {
            Console.Write("Укажите тип комнаты ");
            string type = Console.ReadLine();
            Console.Write("Укажите цену комнаты ");
            int price = Convert.ToInt32(Console.ReadLine());
            var r = new RoomView
            {
                RoomType = type,
                PricePerNight = price
            };

            room.AddRoom(r);

            AllRooms();
        }

        //Удаляем комнату
        public static void RemoveRoom(RoomController rm) 
        {
            Console.Write("Введите номер комнаты которую хотите удалить: ");
            rm.DeleteRoom(Convert.ToInt32(Console.ReadLine()));
            AllRooms();
        }

        //Находим комнату по дате
        public static void FindRoom(string date)
        {
            room = new RoomController();
            Console.WriteLine($"Свободные комнаты на дату: {date}");

            List<RoomView> rooms = room.VacantRoom(date);

            if (rooms.Count<1)
            {
                Console.WriteLine("Свободных номеров нет!");
                HomePage();
            }
            else
            {
                foreach (var r in rooms)
                {
                    Console.WriteLine($"Номер комнаты: {r.RoomNumber} - Тип комнаты: {r.RoomType} - Цена за ночь: {r.PricePerNight}");
                }

                HomePage();

            }
            
        }

        //Бронирование свободной комнаты
        public static void BookRoom() //4
        {
            home = new HomePageController();
            room = new RoomController();
            visitor = new VisitorController();

            Console.WriteLine("Бронирование номера: ");

            var vst = visitor.VisitorsInfo.FindAll(v=>v.MyRoomId==0);

            if (vst.Count<1) 
            {
                Console.WriteLine("Нет пользователей без номера.");

                HomePage();
            }
            foreach (var v in vst) 
            {
               
                    Console.WriteLine($"ID: {v.Id} - Имя: {v.Name}");
            }

            Console.Write("Выберите ID пользователя");

            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Свободные комнаты на дату: {DateTime.Now.Date.ToShortDateString()}");
            
            var rooms = room.VacantRoom(DateTime.Now.ToShortDateString());

            if (rooms.Count < 1)
            {
                Console.WriteLine("Свободных мест нет.");
            }
            else
            {

                foreach (var r in rooms)
                {
                    Console.WriteLine($"Номер комнаты: {r.RoomNumber} - Тип комнаты: {r.RoomType} - Цена за ночь: {r.PricePerNight}");
                }

                Console.Write("Выберите номер комнаты");

                int rNum = Convert.ToInt32(Console.ReadLine());


                Console.Write("Укажите дату заселения: ");

                string checkIn = DateStringCreator();


                Console.Write("Укажите дату выселения: ");

                string checkOut = DateStringCreator();


                home.BookRoom(id, rNum, checkIn, checkOut);
            }

            HomePage();
        }
    }
}
