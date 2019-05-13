using Questioner.Models.Context;
using Questioner.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questioner.Models.Repository
{
    public class UsersRespository : IRepository<User>
    {
        private readonly QuestionerContext _context = new QuestionerContext();

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public int GetId(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault().Id;
        }

        public bool UserCheck(User user)
        {
            return _context.Users.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault() != null;
        }

        public bool UserNotExists(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault() == null;
        }

        public User FirstOrDefault(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User FirstOrDefault()
        {
            return _context.Users.FirstOrDefault();
        }

        public User Find(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }
    }
}