using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using burulas.Entity;
using Microsoft.EntityFrameworkCore;

namespace burulas.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BurulasContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                 if (!context.Schedules.Any())
                {
                    context.Schedules.AddRange(
                            new Schedule { Id = 1, Day = "Pazartesi", CreatedAt = DateTime.Now},
                            new Schedule { Id = 2, Day = "Salı", CreatedAt = DateTime.Now },
                            new Schedule { Id = 3, Day = "Çarşamba", CreatedAt = DateTime.Now },
                            new Schedule { Id = 4, Day = "Perşembe", CreatedAt = DateTime.Now },
                            new Schedule { Id = 5, Day = "Cuma", CreatedAt = DateTime.Now },
                            new Schedule { Id = 6, Day = "Cumartesi", CreatedAt = DateTime.Now },
                            new Schedule { Id = 7, Day = "Pazar", CreatedAt = DateTime.Now }
                    );
                    context.SaveChanges();
                }
                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                            new Employee
                            {
                                Id = 1,
                                FirstName = "Ahmet",
                                LastName = "Yılmaz",
                                Department = "IT",
                                Position = "Developer",
                                CreatedAt = DateTime.Now,
                            },
                            new Employee
                            {
                                Id = 2,
                                FirstName = "Ayşe",
                                LastName = "Kara",
                                Department = "HR",
                                Position = "Manager",
                                CreatedAt = DateTime.Now,
                            },
                            new Employee
                            {
                                Id = 3,
                                FirstName = "Mehmet",
                                LastName = "Demir",
                                Department = "Finance",
                                Position = "Analyst",
                                CreatedAt = DateTime.Now,
                            },
                                 new Employee
                            {
                                Id = 4,
                                FirstName = "Niyazi",
                                LastName = "Değirmen",
                                Department = "Finance",
                                Position = "Analyst",
                                CreatedAt = DateTime.Now,
                            },
                                 new Employee
                            {
                                Id = 5,
                                FirstName = "Akın",
                                LastName = "Damar",
                                Department = "Finance",
                                Position = "Analyst",
                                CreatedAt = DateTime.Now,
                            },
                                 new Employee
                            {
                                Id = 6,
                                FirstName = "Yusuf",
                                LastName = "Akbudak",
                                Department = "Finance",
                                Position = "Analyst",
                                CreatedAt = DateTime.Now,
                            },
                                 new Employee
                            {
                                Id = 7,
                                FirstName = "Şaban",
                                LastName = "Kayış",
                                Department = "Finance",
                                Position = "Analyst",
                                CreatedAt = DateTime.Now,
                            }
                    );
                    context.SaveChanges();
                }
               
            }
        }
    }
}