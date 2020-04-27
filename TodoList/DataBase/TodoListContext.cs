using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace TodoList.DataBase
{
    public class TodoListContext : DbContext
    {
        public TodoListContext() : base("name=TodoListContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<StoryTask> StoryTasks { get; set; }
    }
}