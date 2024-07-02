using MultitrabajosSecurity.Repositories;
using System;
using System.Linq;

namespace MultitrabajosSecurity.Data
{
    public class Dbinitial
    {
        public static void Initialize(Contexto context)
        {
            context.Database.EnsureCreated();

            if (context.Usuario.Any())
            {
                return; 
            }

            var roles = new Models.Rol[]
            {
                new Models.Rol
                {
                    Id = 1,
                    Description = "Administrator",
                    Status = "A",
                    Add = DateTime.UtcNow 
                },
                new Models.Rol
                {
                    Id = 2,
                    Description = "Student",
                    Status = "A",
                    Add = DateTime.UtcNow 
                }
            };


            foreach (var role in roles)
            {
                context.Rol.Add(role);
            }

            context.SaveChanges(); 

            // Crear usuarios
            var users = new Models.User[]
            {
                new Models.User
                {
                    Id = 1,
                    Name = "Stalin",
                    LastName = "Mejia",
                    Email = "smejia@gmail.com",
                    Password = "123456",
                    Phone = "2222222",
                    Estado = "A",
                    FechaAdd = DateTime.UtcNow, 
                    RolId = 1
                },
                new Models.User
                {
                    Id = 2,
                    Name = "Juan",
                    LastName = "Perez",
                    Email = "mateito.dominic@gmail.com",
                    Password = "123456",
                    Phone = "2222222",
                    Estado = "A",
                    FechaAdd = DateTime.UtcNow, 
                    RolId = 2
                }
            };

     
            foreach (var user in users)
            {
                context.Usuario.Add(user);
            }

            context.SaveChanges(); 
        }
    }
}
