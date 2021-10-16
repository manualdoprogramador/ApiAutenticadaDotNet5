using System.Collections.Generic;
using System.Linq;
using ApiAutenticadaDotNet5.Models;

namespace ApiAutenticadaDotNet5.Repositorio
{
    public class UserRepository
    {
        public static User Get(string name, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Name = "Pedro", Password = "12345", Role = "gerente" });
            users.Add(new User { Id = 2, Name = "Paulo", Password = "12345", Role = "funcionario" });
            return users.FirstOrDefault(x => x.Name.ToLower() == name.ToLower() && x.Password == password);
        }
    }
}