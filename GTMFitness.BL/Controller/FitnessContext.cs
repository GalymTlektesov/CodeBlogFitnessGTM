using GTMFitness.BL.Model;
using System;
using System.Data.Entity;

namespace GTMFitness.BL.Controller
{
    public class FitnessContext : DbContext
    {
        public FitnessContext() : base("DBConnnection") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
