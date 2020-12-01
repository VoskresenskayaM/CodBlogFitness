using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitnessBL.Model;
using CodeBlogFitnessBL.Controller;

namespace CodeBlogFitnessCMD
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Вас приветствует приложение CodeBlogFitness");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTame();
                var weighr = ParseDouble("Вес");
                var hight = ParseDouble("Рост");
                userController.SetNewUserData(gender, birthDate, weighr, hight);
                
            }
            Console.WriteLine(userController.CurrrentUser);


            Console.WriteLine("Что вы хотите сделать?");

            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();
        

             if (key.Key==ConsoleKey.E)
            {
                EnterEating();
            }
            Console.ReadLine();
        }

        private static void EnterEating()
        {

            Console.WriteLine("Введите имя продукта");
            var food = Console.ReadLine();

            Console.Write("Введите вес порции:");
            var weight = ParseDouble("вес порции");
        }

        private static DateTime ParseDateTame()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату рождения (dd.mm.yy:  )");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
                }
                
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while(true)
            {
                Console.WriteLine($"Введите {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
    }
}