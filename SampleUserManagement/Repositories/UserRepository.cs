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
            foreach(var user in userList)
            {
                user.userId = user.userId.ToUpper();
            }
            return userList;

        }

        public User GetSingleUser(string userId)
        {
            var json = File.ReadAllText(DataLink);
            var userList = JsonConvert.DeserializeObject<IEnumerable<User>>(json).ToList();

            var desiredUser =
                from user in userList
                where user.userId == userId
                select user;

            return desiredUser.FirstOrDefault();

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
            int userIndex = -1;

            foreach(var userEntry in userList)
            {
                if (userEntry.userId.ToUpper() == user.userId.ToUpper())
                {
                    userIndex = userList.IndexOf(userEntry);
                }
            }
            if(userIndex != -1)
            {
                userList.Insert(userIndex, user);
            }
            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(DataLink, json);
        }

        public void DeleteUser(string userId)
        {
            var userList = GetAllUsers();
            int userIndex = -1;

            foreach (var userEntry in userList)
            {
                if (userEntry.userId.ToUpper() == userId.ToUpper())
                {
                    userIndex = userList.IndexOf(userEntry);
                }
            }
            if (userIndex != -1)
            {
                userList.RemoveAt(userIndex);
            }
            var json = JsonConvert.SerializeObject(userList);
            File.WriteAllText(DataLink, json);
        }
    }
}
