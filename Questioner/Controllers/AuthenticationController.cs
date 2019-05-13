using Questioner.Models.Entity;
using Questioner.Models.ViewModels;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using Questioner.Models.Repository;
using System.Web.Security;

namespace Questioner.Controllers
{
    public class AuthenticationController : Controller
    {
        #region [Repository]
        UsersRespository usersRespository = new UsersRespository();
        #endregion

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email,
                    Password = GetHash(model.Password)
                };

                // if user with such email and password exists
                if (usersRespository.UserCheck(user))
                {
                    // set cookie and proceed
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Question", "Home");
                }
                else
                {
                    // if user doesn't exist
                    ModelState.AddModelError("", "Incorrect login or password");
                }
            }
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // пользователя нет базе данных 
                if (usersRespository.UserNotExists(model.Email))
                {
                    // создаем нового пользователя 
                    var user = new User()
                    {
                        UserName = model.Name,
                        Email = model.Email,
                        Password = GetHash(model.Password)
                    };
                    usersRespository.Create(user);

                    // if user is added successfully
                    if (!usersRespository.UserNotExists(model.Email))
                    {
                        // set cookie and proceed
                        FormsAuthentication.SetAuthCookie(model.Email, true);
                        return RedirectToAction("Question", "Home");
                    }
                }
                else
                {
                    // error if user already exists 
                    ModelState.AddModelError("", "User with the same Email is already registered");
                }
            }
            return View();
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}