using System;
using System.Collections.Generic;
using System.Text;

namespace APress.ProAspNet.Providers.Store
{
    public class SimpleUser
    {
        public Guid UserKey = Guid.Empty;

        public string UserName = "";
        public string Password = "";
        public string PasswordSalt = "";

        public string Email = "";
        public DateTime CreationDate = DateTime.Now;
        public DateTime LastActivityDate = DateTime.MinValue;
        public DateTime LastLoginDate = DateTime.MinValue;
        public DateTime LastPasswordChangeDate = DateTime.MinValue;
        public string PasswordQuestion = "";
        public string PasswordAnswer = "";
        public string Comment;
    }
}
