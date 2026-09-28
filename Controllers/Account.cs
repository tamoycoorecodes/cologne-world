using Microsoft.AspNetCore.Mvc;
using CologneWorld.Models;
using CologneWorld.Services;
using System.Text.Json;

namespace CologneWorld.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            // If user is already logged in, redirect to home
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Login(email, password);

            if (user != null)
            {
                // Store user info in session
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserName", $"{user.FirstName} {user.LastName}");

                TempData["SuccessMessage"] = $"Welcome back, {user.FirstName}!";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Invalid email or password.";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public IActionResult Register(string email, string password, string confirmPassword, string firstName, string lastName)
        {
            // Basic validation
            if (password != confirmPassword)
            {
                TempData["ErrorMessage"] = "Passwords do not match.";
                return View();
            }

            if (_userService.EmailExists(email))
            {
                TempData["ErrorMessage"] = "Email already exists.";
                return View();
            }

            var newUser = new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            var user = _userService.Register(newUser);

            if (user != null)
            {
                TempData["SuccessMessage"] = "Account created successfully! Please login.";
                return RedirectToAction("Login");
            }

            TempData["ErrorMessage"] = "Registration failed. Please try again.";
            return View();
        }

        // POST: /Account/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "You have been logged out successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}