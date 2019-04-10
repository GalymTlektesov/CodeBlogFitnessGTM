using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace GTMFitness.BL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GTMFitness.BL.Controller.FitnessContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "GTMFitness.BL.Controller.FitnessContext";
        }

        protected override void Seed(GTMFitness.BL.Controller.FitnessContext context)
        {
    
        }  
    }
}
