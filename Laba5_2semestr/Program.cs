using System.Net.Mail;
using System.Threading.Channels;
using System.Xml.Linq;
using System;
using Laba5_2semestr.klym;
using Laba5_2semestr.Shab;

namespace Laba5_2semestr
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Клименко 1 - 1");
                Console.WriteLine("Шаблiй   2 - 2");
                Console.Write("Введiть варiант: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Задача 1 - 1");
                        Console.WriteLine("Задача 2 - 2");
                        Console.Write("Введiть варiант: ");
                        choice = int.Parse(Console.ReadLine());
                        Console.Clear();
                        switch (choice)
                        {
                            case 1:
                                Task1 task1 = new Task1();
                                task1.Main();
                                break;
                            case 2:
                                Task2 task2 = new Task2();
                                task2.Main();
                                break;
                        }
                        break;
                    case 2:

                        Shab.Shab task1_shab = new Shab.Shab();
                                task1_shab.Main();
                     
                        break;
                }
            } while (choice != 0);
        }
    }
}