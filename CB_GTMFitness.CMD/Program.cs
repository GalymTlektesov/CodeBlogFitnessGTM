using GTMFitness.BL.Controller;
using GTMFitness.BL.Model;
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
            var eatingController = new EatingController(userController.Currentuser);
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

            Console.WriteLine("Что вы ещё хотите сделать?");
            Console.WriteLine("E-ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbohydates = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, proteins, fats, carbohydates);

            return (Food: product, Weight: weight);
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
                    Console.WriteLine($"Не верный формат поля {name}");
                }
            }
        }
    }
}
