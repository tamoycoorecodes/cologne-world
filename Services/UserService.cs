using CologneWorld.Models;

namespace CologneWorld.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();
        private int _nextId = 1;

        public UserService()
        {
            // Add a sample user for testing
            _users.Add(new User
            {
                Id = _nextId++,
                Email = "demo@cologneworld.com",
                Password = "password123",
                FirstName = "Demo",
                LastName = "User"
            });
        }

        public User? Register(User user)
        {
            // Check if email already exists
            if (_users.Any(u => u.Email == user.Email))
            {
                return null;
            }

            user.Id = _nextId++;
            user.CreatedAt = DateTime.Now;
            _users.Add(user);

            return user;
        }

        public User? Login(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User? GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public bool EmailExists(string email)
        {
            return _users.Any(u => u.Email == email);
        }
    }
}