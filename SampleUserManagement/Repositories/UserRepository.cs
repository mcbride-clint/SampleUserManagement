using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SampleUserManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleUserManagement.Repositories
{
    public class UserRepository
    {
        private string DataLink = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "/SampleUserManagement/MOCK_DATA.json";

        public List<User> GetAllUsers()
        {
            var json = File.ReadAllText(DataLink);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();
            foreach (var user in userList)
            {
                user.userId = user.userId.ToUpper();
            }
            return userList;

        }

        public User GetSingleUser(string userId)
        {
            var json = File.ReadAllText(DataLink);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();

            return userList.Single(u => u.userId.Equals(userId, StringComparison.OrdinalIgnoreCase));
        }

        public void CreateUser(User user)
        {
            var userList = GetAllUsers();
            userList.Add(user);
            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(DataLink, json);
        }

        public void UpdateUser(User user)
        {
            var userList = GetAllUsers();

            var existingUser = GetSingleUser(user.userId);

            existingUser.department = user.department;
            existingUser.firstName = user.firstName;
            existingUser.lastName = user.lastName;
            existingUser.phoneNumber = user.phoneNumber;
            existingUser.userId = user.userId;

            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(DataLink, json);
        }

        public void DeleteUser(string userId)
        {
            var userList = GetAllUsers();

            var existingUser = GetSingleUser(userId);
            userList.Remove(existingUser);

            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(DataLink, json);
        }
    }
}
