﻿using System;

namespace GTMFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Именование продукта
        /// </summary>
        public string Name { get; }
        public double Callories { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        public double Carbohydates { get; }

        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; }


        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double callories, double proteins, double fats, double carbohydates)
        {
            //TODO: Проверка

            Name = name;
            Callories = callories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydates = carbohydates / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
