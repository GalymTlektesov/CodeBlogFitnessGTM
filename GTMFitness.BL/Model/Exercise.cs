using System;

namespace GTMFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        /// <summary>
        /// Начало выполнение упражнение
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// Конец выполнение упражнение
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// Именование упражнение
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Пользователь выполнивший упражнение
        /// </summary>
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
