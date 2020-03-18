using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleUserManagement.Models;
using SampleUserManagement.Repositories;

namespace SampleUserManagement.Views.UserList
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var userRepo = new UserRepository();
            var userList = userRepo.GetAllUsers();
            return View(userList);
        }

        // GET: User/Details/5
        public ActionResult Details(string userId)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetSingleUser(userId);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                var userRepo = new UserRepository();
                userRepo.CreateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string userId)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetSingleUser(userId);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            try
            {
                var userRepo = new UserRepository();
                userRepo.UpdateUser(user);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(string userId)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetSingleUser(userId);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            try
            {
                var userRepo = new UserRepository();
                userRepo.DeleteUser(user.userId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}