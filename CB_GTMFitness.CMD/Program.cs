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

            Console.WriteLine("Введите пол");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            var birthdata = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите Рост");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdata, weight, height);
            userController.Save();

        }
    }
}
