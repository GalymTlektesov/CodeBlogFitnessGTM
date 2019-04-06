using GTMFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace GTMFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользоваетеля.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Рользователь приложения.
        /// </summary>
        public List<User> Users { get; }

        public User Currentuser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не моедт быть пустым", nameof(userName));
            }

            Users = GetUsersData();

            Currentuser = Users.SingleOrDefault(u => u.Name == userName);

            if(Currentuser == null)
            {
                Currentuser = new User(userName);
                Users.Add(Currentuser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненый список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }


        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 60, double height = 170)
        {
            // Проверка

            Currentuser.Gender = new Gender(genderName);
            Currentuser.BirthDate = birthDate;
            Currentuser.Weight = weight;
            Currentuser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns>Пользоветель приложения.</returns>
    }
}
