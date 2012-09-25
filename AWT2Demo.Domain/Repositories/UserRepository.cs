using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWT2Demo.Domain.Repositories.Abstract;
using AWT2Demo.Domain.Entities;

namespace AWT2Demo.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUserByClaimedIdentifier(string claimedIdentifier);
        User AddUserForClaimedIdentifier(string claimedIdentifier,
                                         string email,
                                         string firsName,
                                         string lastName);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository() : base() { }

        public User FindUserByClaimedIdentifier(string claimedIdentifier)
        {
            return _dbSet.FirstOrDefault(u => u.ClaimedIdentifier == claimedIdentifier);
        }

        public User AddUserForClaimedIdentifier(string claimedIdentifier,
                                         string email,
                                         string firsName,
                                         string lastName)
        {
            var addedUser = new User
            {
                ClaimedIdentifier = claimedIdentifier,
                Email = email,
                FirstName = firsName,
                LastName = lastName
            };
            _dbSet.Add(addedUser);
            _context.SaveChanges();

            return addedUser;
        }
    }
}
