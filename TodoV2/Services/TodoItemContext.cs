using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoV2.Models;

namespace TodoV2.Services
{
    public class TodoItemContext : DbContext
    {
        public DbSet<TodoItem> items { get; set; }

        public string DbPath { get; }

        public TodoItemContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "todo.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasKey(k => k.id);

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem { Description = "Test", IsChecked = true,id= 1 },
                new TodoItem { Description = "Test 2", IsChecked = true, id = 2 }
            );
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
