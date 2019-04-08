using GTMFitness.BL.Controller;
using GTMFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CB_GTMFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("CB_GTMFitness.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthdate = ParseDateTime("дата рождения");
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");

                userController.SetNewUserData(gender, birthdate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы ещё хотите сделать?");
                Console.WriteLine("E-ввести приём пищи");
                Console.WriteLine("A-ввести упражнение");
                Console.WriteLine("Q-выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthdate;
            while (true)
            {
                Console.Write($"Введите {value}(DD.MM.YYYY): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {value}");
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
