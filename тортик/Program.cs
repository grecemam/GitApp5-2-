using System.Collections.Generic;
using System.ComponentModel.Design;

namespace тортик
{
    internal class Program
    {
        private static int cost = 0;
        private static string sostav = "";
        private DateTime Date;
        static void Main()
        {
            while (true)
            {
                List<Cakes> zakaz = MakeCakes();
                Console.Clear();
                Menu(zakaz);
                int position = 1;
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        position--;
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        position++;
                    }
                    if (position==6 && key.Key == ConsoleKey.DownArrow)
                    {
                        Soxr();
                    }

                    Console.Clear();
                    Menu(zakaz);
                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("=>");
                    key = Console.ReadKey();
                }

                Console.Clear();
                int pos = 1;
                ConsoleKeyInfo key1 = Console.ReadKey();
                while (true)
                {
                    if (key1.Key == ConsoleKey.UpArrow)
                    {
                        pos--;
                    }
                    if (key1.Key == ConsoleKey.DownArrow)
                    {
                        pos++;
                    }
                    if (key1.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if (key1.Key == ConsoleKey.Enter)
                    {
                        cost += zakaz[position - 1].dops[pos].price;
                        sostav += zakaz[position - 1].dops[pos].dop + zakaz[position - 1].dops[pos].price;
                        break;
                    }

                    Console.Clear();
                    foreach (DopCakes dc in zakaz[position - 1].dops)
                    {
                        Console.WriteLine("  " + dc.dop + dc.price);
                    }
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("=>");
                    key1 = Console.ReadKey();
                }
            }
        }
        static void Menu(List<Cakes> torts)
        {
            Console.WriteLine(" Вы в мазагине тортов, сделайте онлайн заказ");
            foreach (Cakes c in torts)
            {
                Console.WriteLine("  " + c.osn);
            }
            Console.WriteLine("Цена: " + cost);
            Console.WriteLine("Ваш торт:" + sostav + " ");
        }
        static List<Cakes> MakeCakes()
        {
            Cakes c1 = new Cakes("форма");

            DopCakes dopKrug = new DopCakes(" Круг-", 100);
            DopCakes dopKvad = new DopCakes(" Квадрат - ", 200);
            DopCakes dopLove = new DopCakes(" Сердце-", 10000);
            c1.dops = new List<DopCakes>() { dopKrug, dopKvad, dopLove };

            Cakes c2 = new Cakes("размер");
            DopCakes dop1 = new DopCakes(" диаметр 10 см-", 150);
            DopCakes dop2 = new DopCakes(" диаметр 20см-", 250);
            DopCakes dop3 = new DopCakes(" диаметр 30 см-", 10000);
            c2.dops = new List<DopCakes>() { dop1, dop2, dop3 };


            Cakes c3 = new Cakes("декор");
            DopCakes dopKrem = new DopCakes(" Крем-", 75);
            DopCakes dopBezDekora = new DopCakes(" Без декора-", 0);
            DopCakes dopSaxBum = new DopCakes(" Сахараная бумага-", 100);
            c3.dops = new List<DopCakes>() { dopKrem, dopBezDekora, dopSaxBum };


            Cakes c4 = new Cakes("начинка");
            DopCakes dopCherry = new DopCakes(" Вишня-", 100);
            DopCakes dopStraw = new DopCakes(" Клубника-", 120);
            DopCakes dopSnik = new DopCakes(" Сникерс-", 300);
            c4.dops = new List<DopCakes>() { dopCherry, dopStraw, dopSnik };

            Cakes c5 = new Cakes("глазурь");
            DopCakes dopChok = new DopCakes(" Шоколад-", 100);
            DopCakes dopVanil = new DopCakes(" Ваниль-", 120);
            DopCakes dopKaramel = new DopCakes(" Карамель-", 200);
            c5.dops = new List<DopCakes>() { dopChok, dopVanil, dopKaramel };

            Cakes c6 = new Cakes("Конец заказа");
            List<Cakes> list = new List<Cakes>();
            list.Add(c1);
            list.Add(c2);
            list.Add(c3);
            list.Add(c4);
            list.Add(c5);
            list.Add(c6);
            return list;

        }
        static void Soxr()
        {
            DateTime date = DateTime.Now;
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\заказы.txt", "\nДата:" + date);
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\заказы.txt", "\nЦена:" + cost.ToString());
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\заказы.txt", "\nВаш заказ: " + sostav.ToString());
        }
    }
}