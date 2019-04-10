using System;

namespace GTMFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }

        /// <summary>
        /// Начало выполнение упражнение
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Конец выполнение упражнение
        /// </summary>
        public DateTime Finish { get; set; }

        public int ActivityId { get; set; }
        /// <summary>
        /// Именование упражнение
        /// </summary>
        public virtual Activity Activity { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Пользователь выполнивший упражнение
        /// </summary>
        public virtual User User { get; set; }

        public Exercise() { }

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
