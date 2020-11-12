using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class NewUser
    {
        public NewUser(string userName, string password, DateTime? dateOfBirth = default)
        {
            if (userName == null)
                throw new ArgumentNullException(nameof(userName));
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            UserName = userName;
            Password = password;
            DateOfBirth = dateOfBirth;
        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
    }
}
