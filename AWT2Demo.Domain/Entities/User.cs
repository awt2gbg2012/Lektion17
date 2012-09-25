using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWT2Demo.Domain.Entities.Abstract;

namespace AWT2Demo.Domain.Entities
{
    public class User : IEntity
    {
        public int ID { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ClaimedIdentifier { get; set; }

        public string FullName { 
            get 
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return "Anonymous";
                else if (string.IsNullOrEmpty(FirstName))
                    return LastName;
                else if (string.IsNullOrEmpty(LastName))
                    return FirstName;
                else
                    return string.Format("{0} {1}", FirstName, LastName);
            } 
        }

        public string FriendlyIdentifier
        {
            get
            {
                if (!string.IsNullOrEmpty(NickName))
                    return NickName;
                else if (!string.IsNullOrEmpty(FirstName))
                    return FirstName;
                else if (!string.IsNullOrEmpty(LastName))
                    return LastName;
                else if (!string.IsNullOrEmpty(Email))
                    return Email;
                else
                    return FullName;
            }
        }
    }
}
