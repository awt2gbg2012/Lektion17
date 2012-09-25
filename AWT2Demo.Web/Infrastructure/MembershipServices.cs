using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace AWT2Demo.Web.Infrastructure
{
    public class MembershipServices
    {
        public MembershipUser AddOpenIDUser(string claimedIdentifier)
        {
            // We don't want OpenIDUsers to login using membership - hashing and salting claimedIdentifier and using that as password
            var data = Encoding.Unicode.GetBytes(claimedIdentifier + "AWT2Demo.Web" + DateTime.Now.ToString());
            var hashData = new SHA1Managed().ComputeHash(data);
            return Membership.CreateUser(claimedIdentifier, Convert.ToBase64String(hashData));
        }

        public MembershipUserCollection GetAllUsers()
        {
            return Membership.GetAllUsers();
        }

        public MembershipUser GetUserByName(string name)
        {
            return Membership.GetAllUsers()[name];
        }

        public string[] GetAllRoles()
        {
            return Roles.GetAllRoles();
        }

        public string[] GetRolesForUser(string name)
        {
            return Roles.GetRolesForUser(name);
        }

        public void AddRoleToUser(string username, string rolename)
        {
            Roles.AddUserToRole(username, rolename);
        }

        public void RemoveRoleFromUser(string username, string rolename)
        {
            Roles.RemoveUserFromRole(username, rolename);
        }
    }
}