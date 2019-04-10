using System.Collections.Generic;

namespace GTMFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDateSaver manager = new DatabaseDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        } 
    }
}
