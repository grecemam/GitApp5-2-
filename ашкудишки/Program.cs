using System.Collections.Generic;
using System.ComponentModel.Design;

namespace тортик
{
    internal class Program
    {
        private static int cost = 0;
        private static string sostav = "";
        static void Main()
        {
            while (true)
            {
                List<hqd> zakaz = MakeCakes();
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
                    foreach (dophqd dc in zakaz[position - 1].dops)
                    {
                        Console.WriteLine("  " + dc.dop + dc.price);
                    }
                    Console.SetCursorPosition(0, pos);
                    Console.WriteLine("=>");
                    key1 = Console.ReadKey();
                }
            }
        }
        static void Menu(List<hqd> hqdd)
        {
            Console.WriteLine(" Вы в табачке от мел, сделайте онлайн заказ");
            foreach (hqd c in hqdd)
            {
                Console.WriteLine("  " + c.osn);
            }
            Console.WriteLine("Цена: " + cost);
            Console.WriteLine("Ваши ашкудишки:" + sostav + " ");
        }
        static List<hqd> MakeCakes()
        {
            hqd c1 = new hqd("Манго");

            dophqd dopMango2 = new dophqd("(Манго)1200 затяжек -", 650);
            dophqd dopMango3 = new dophqd("(Манго)2500 затяжек -", 800);
            dophqd dopMango1 = new dophqd("(Манго)5000 затяжек + перезарядка -", 1250);
            c1.dops = new List<dophqd>() { dopMango1, dopMango2, dopMango3 };

            hqd c2 = new hqd("Персик");
            dophqd dopPers1 = new dophqd("(Персик) 1200 затяжек -", 650);
            dophqd dopPers2 = new dophqd("(Персик) 2500 затяжек -", 800);
            dophqd dopPers3 = new dophqd("(Персик) 5000 затяжек + перезарядка -", 1250);
            c2.dops = new List<dophqd>() { dopPers1, dopPers2, dopPers3 };


            hqd c3 = new hqd("Ананас");
            dophqd dopAnanas1 = new dophqd("(Ананас) 1200 затяжек -", 650);
            dophqd dopAnanas2 = new dophqd("(Ананас) 2500 затяжек -", 800);
            dophqd dopAnanas3 = new dophqd("(Ананас) 5000 затяжек + перезарядка -", 1250);
            c3.dops = new List<dophqd>() { dopAnanas1, dopAnanas2, dopAnanas3 };


            hqd c4 = new hqd("Виноград");
            dophqd dopVin1 = new dophqd("(Виноград) 1200 затяжек -", 650);
            dophqd dopVin2 = new dophqd("(Виноград) 2500 затяжек -", 800);
            dophqd dopVin3 = new dophqd("(Виноград) 5000 затяжек + перезарядка -", 1250);
            c4.dops = new List<dophqd>() { dopVin1, dopVin2, dopVin3 };

            hqd c5 = new hqd("Энергетик");
            dophqd dopEner1 = new dophqd("(Энергетик) 1200 затяжек -", 650);
            dophqd dopEner2 = new dophqd("(Энергетик) 2500 затяжек -", 800);
            dophqd dopEner3 = new dophqd("(Энергетик) 5000 затяжек + перезарядка -", 1250);
            c5.dops = new List<dophqd>() { dopEner1, dopEner2, dopEner3 };

            hqd c6 = new hqd("Конец заказа");
            List<hqd> list = new List<hqd>();
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
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\ашкудишки.txt", "\nДата:" + date);
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\ашкудишки.txt", "\nЦена:" + cost.ToString());
            File.AppendAllText("C:\\Users\\maksi\\OneDrive\\Рабочий стол\\ашкудишки.txt", "\nВаш заказ: " + sostav.ToString());
        }
    }
}