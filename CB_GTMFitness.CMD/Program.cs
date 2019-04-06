using GTMFitness.BL.Controller;
using System;

namespace CB_GTMFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitnessGTM");
            Console.WriteLine("Введите имя пользоветеля");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthdate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthdate, weight, height);
            }


            Console.WriteLine(userController.Currentuser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthdate;
            while (true)
            {
                Console.Write("Введите дату рождения(DD.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Не верный формат даты рождения");
                }
            }

            return birthdate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {name}а");
                }
            }
        }
    }
}
