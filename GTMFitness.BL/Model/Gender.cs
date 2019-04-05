using System;

namespace GTMFitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name"> Имя пола</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или Null", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Принадлежность к полу
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
