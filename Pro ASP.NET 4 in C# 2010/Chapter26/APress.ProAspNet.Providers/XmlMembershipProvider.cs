using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Security.Cryptography;
using APress.ProAspNet.Providers.Store;

namespace APress.ProAspNet.Providers
{
    public class XmlMembershipProvider : MembershipProvider
    {
        private string _Name;
        private string _FileName;
        private UserStore _CurrentStore = null;
        private string _ApplicationName;
        private bool _EnablePasswordReset;
        private bool _RequiresQuestionAndAnswer;
        private string _PasswordStrengthRegEx;
        private int _MaxInvalidPasswordAttempts;
        private int _MinRequiredNonAlphanumericChars;
        private int _MinRequiredPasswordLength;
        private MembershipPasswordFormat _PasswordFormat;

        private UserStore CurrentStore
        {
            get
            {
                if (_CurrentStore == null)
                    _CurrentStore = UserStore.GetStore(_FileName);
                return _CurrentStore;
            }
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "XmlMembershipProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "XML Membership Provider");
            }

            // Initialize the base class
            base.Initialize(name, config);

            // Initialize default values
            _ApplicationName = "DefaultApp";
            _EnablePasswordReset = false;
            _PasswordStrengthRegEx = @"[\w| !§$%&/()=\-?\*]*";
            _MaxInvalidPasswordAttempts = 3;
            _MinRequiredNonAlphanumericChars = 1;
            _MinRequiredPasswordLength = 5;
            _RequiresQuestionAndAnswer = false;
            _PasswordFormat = MembershipPasswordFormat.Hashed;

            // Now go through the properties and initialize custom values
            foreach (string key in config.Keys)
            {
                switch (key.ToLower())
                {
                    case "name":
                        _Name = config[key];
                        break;
                    case "applicationname":
                        _ApplicationName = config[key];
                        break;
                    case "filename":
                        _FileName = config[key];
                        break;
                    case "enablepasswordreset":
                        _EnablePasswordReset = bool.Parse(config[key]);
                        break;
                    case "passwordstrengthregex":
                        _PasswordStrengthRegEx = config[key];
                        break;
                    case "maxinvalidpasswordattempts":
                        _MaxInvalidPasswordAttempts = int.Parse(config[key]);
                        break;
                    case "minrequirednonalphanumericchars":
                        _MinRequiredNonAlphanumericChars = int.Parse(config[key]);
                        break;
                    case "minrequiredpasswordlength":
                        _MinRequiredPasswordLength = int.Parse(config[key]);
                        break;
                    case "passwordformat":
                        _PasswordFormat = (MembershipPasswordFormat)Enum.Parse(
                                    typeof(MembershipPasswordFormat), config[key]);
                        break;
                    case "requiresquestionandanswer":
                        _RequiresQuestionAndAnswer = bool.Parse(config[key]);
                        break;
                }
            }
        }

        #region Properties

        public override string ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                _ApplicationName = value;
                _CurrentStore = null;
            }
        }

        public override bool EnablePasswordReset
        {
            get { return _EnablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                if (this.PasswordFormat == MembershipPasswordFormat.Hashed)
                    return false;
                else
                    return true;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return _MaxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return _MinRequiredNonAlphanumericChars; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return _MinRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 20; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return _PasswordFormat; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                return _PasswordStrengthRegEx;
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return _RequiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        #endregion

        #region Methods

        public override MembershipUser CreateUser(string username, string password,
            string email, string passwordQuestion,
            string passwordAnswer, bool isApproved,
            object providerUserKey, out MembershipCreateStatus status)
        {
            try
            {
                // Validate the username and email
                if (!ValidateUsername(username, email, Guid.Empty))
                {
                    status = MembershipCreateStatus.InvalidUserName;
                    return null;
                }

                // Raise the event before validating the password
                base.OnValidatingPassword(
                    new ValidatePasswordEventArgs(
                            username, password, true));

                // Validate the password
                if (!ValidatePassword(password))
                {
                    status = MembershipCreateStatus.InvalidPassword;
                    return null;
                }

                // Everything is valid, create the user
                SimpleUser user = new SimpleUser();
                user.UserKey = Guid.NewGuid();
                user.UserName = username;
                user.PasswordSalt = string.Empty;
                user.Password = this.TransformPassword(password, ref user.PasswordSalt);
                user.Email = email;
                user.PasswordQuestion = passwordQuestion;
                user.PasswordAnswer = passwordAnswer;
                user.CreationDate = DateTime.Now;
                user.LastActivityDate = DateTime.Now;
                user.LastPasswordChangeDate = DateTime.Now;

                // Add the user to the store
                CurrentStore.Users.Add(user);
                CurrentStore.Save();

                status = MembershipCreateStatus.Success;
                return CreateMembershipFromInternalUser(user);
            }
            catch
            {
                throw;
            }
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByName(username);
                if (user != null)
                {
                    CurrentStore.Users.Remove(user);
                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByName(username);
                if (user != null)
                {
                    if (userIsOnline)
                    {
                        user.LastActivityDate = DateTime.Now;
                        CurrentStore.Save();
                    }
                    return CreateMembershipFromInternalUser(user);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByKey((Guid)providerUserKey);
                if (user != null)
                {
                    if (userIsOnline)
                    {
                        user.LastActivityDate = DateTime.Now;
                        CurrentStore.Save();
                    }
                    return CreateMembershipFromInternalUser(user);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public override string GetUserNameByEmail(string email)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByEmail(email);

                if (user != null)
                    return user.UserName;
                else
                    return null;
            }
            catch
            {
                throw;
            }
        }

        public override void UpdateUser(MembershipUser user)
        {
            try
            {
                SimpleUser suser = CurrentStore.GetUserByKey((Guid)user.ProviderUserKey);

                if (suser != null)
                {
                    if (!ValidateUsername(suser.UserName, suser.Email, suser.UserKey))
                        throw new ArgumentException("Username and / or email are not unique!");

                    suser.Email = user.Email;
                    suser.LastActivityDate = user.LastActivityDate;
                    suser.LastLoginDate = user.LastLoginDate;
                    suser.Comment = user.Comment;

                    CurrentStore.Save();
                }
                else
                {
                    throw new ProviderException("User does not exist!");
                }
            }
            catch
            {
                throw;
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByName(username);
                if (user == null)
                    return false;

                if (ValidateUserInternal(user, password))
                {
                    user.LastLoginDate = DateTime.Now;
                    user.LastActivityDate = DateTime.Now;
                    CurrentStore.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            try
            {
                // Get the user from the store
                SimpleUser user = CurrentStore.GetUserByName(username);
                if (user == null)
                    throw new Exception("User does not exist!");

                if (ValidateUserInternal(user, oldPassword))
                {
                    // Raise the event before validating the password
                    base.OnValidatingPassword(
                        new ValidatePasswordEventArgs(
                                username, newPassword, false));

                    if (!ValidatePassword(newPassword))
                        throw new ArgumentException("Password doesn't meet password strength requirements!");

                    user.PasswordSalt = string.Empty;
                    user.Password = TransformPassword(newPassword, ref user.PasswordSalt);
                    user.LastPasswordChangeDate = DateTime.Now;
                    CurrentStore.Save();

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            try
            {
                // Get the user from the store
                SimpleUser user = CurrentStore.GetUserByName(username);

                if (ValidateUserInternal(user, password))
                {
                    user.PasswordQuestion = newPasswordQuestion;
                    user.PasswordAnswer = newPasswordAnswer;
                    CurrentStore.Save();

                    return true;
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                List<SimpleUser> matchingUsers =
                    CurrentStore.Users.FindAll(delegate(SimpleUser user)
                        {
                            return user.Email.Equals(emailToMatch, StringComparison.OrdinalIgnoreCase);
                        });

                totalRecords = matchingUsers.Count;
                return CreateMembershipCollectionFromInternalList(matchingUsers);
            }
            catch
            {
                throw;
            }
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                List<SimpleUser> matchingUsers =
                    CurrentStore.Users.FindAll(delegate(SimpleUser user)
                        {
                            return user.UserName.Equals(usernameToMatch, StringComparison.OrdinalIgnoreCase);
                        });

                totalRecords = matchingUsers.Count;
                return CreateMembershipCollectionFromInternalList(matchingUsers);
            }
            catch
            {
                throw;
            }
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            try
            {
                totalRecords = CurrentStore.Users.Count;
                return CreateMembershipCollectionFromInternalList(CurrentStore.Users);
            }
            catch
            {
                throw;
            }
        }

        public override int GetNumberOfUsersOnline()
        {
            int ret = 0;

            foreach (SimpleUser user in CurrentStore.Users)
            {
                if (user.LastActivityDate.AddMinutes(
                       Membership.UserIsOnlineTimeWindow) >= DateTime.Now)
                {
                    ret++;
                }
            }

            return ret;
        }

        public override string GetPassword(string username, string answer)
        {
            try
            {
                if (EnablePasswordRetrieval)
                {
                    SimpleUser user = CurrentStore.GetUserByName(username);

                    if (answer.Equals(user.PasswordAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        return user.Password;
                    }
                    else
                    {
                        throw new System.Web.Security.MembershipPasswordException();
                    }
                }
                else
                {
                    throw new Exception("Password retrieval is not enabled!");
                }
            }
            catch
            {
                throw;
            }
        }

        public override string ResetPassword(string username, string answer)
        {
            try
            {
                SimpleUser user = CurrentStore.GetUserByName(username);
                if (user.PasswordAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase))
                {
                    byte[] NewPassword = new byte[16];
                    RandomNumberGenerator rng = RandomNumberGenerator.Create();
                    rng.GetBytes(NewPassword);

                    string NewPasswordString = Convert.ToBase64String(NewPassword);
                    user.PasswordSalt = string.Empty;
                    user.Password = TransformPassword(NewPasswordString, ref user.PasswordSalt);
                    CurrentStore.Save();

                    return NewPasswordString;
                }
                else
                {
                    throw new Exception("Invalid answer entered!");
                }
            }
            catch
            {
                throw;
            }
        }

        public override bool UnlockUser(string userName)
        {
            // This provider doesn't support locking
            return true;
        }

        #endregion

        #region Private Helper Methods

        private string TransformPassword(string password, ref string salt)
        {
            string ret = string.Empty;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    ret = password;
                    break;

                case MembershipPasswordFormat.Hashed:

                    // Generate the salt if not passed in
                    if (string.IsNullOrEmpty(salt))
                    {
                        byte[] saltBytes = new byte[16];
                        RandomNumberGenerator rng = RandomNumberGenerator.Create();
                        rng.GetBytes(saltBytes);
                        salt = Convert.ToBase64String(saltBytes);
                    }
                    ret = FormsAuthentication.HashPasswordForStoringInConfigFile(
                                                            (salt + password), "SHA1");
                    break;

                case MembershipPasswordFormat.Encrypted:
                    byte[] ClearText = Encoding.UTF8.GetBytes(password);
                    byte[] EncryptedText = base.EncryptPassword(ClearText);
                    ret = Convert.ToBase64String(EncryptedText);
                    break;
            }

            return ret;
        }

        private bool ValidateUsername(string userName, string email, Guid excludeKey)
        {
            bool IsValid = true;

            UserStore store = UserStore.GetStore(_FileName);
            foreach (SimpleUser user in store.Users)
            {
                if (user.UserKey.CompareTo(excludeKey) != 0)
                {
                    if (string.Equals(user.UserName, userName, StringComparison.OrdinalIgnoreCase))
                    {
                        IsValid = false;
                        break;
                    }

                    if (string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase))
                    {
                        IsValid = false;
                        break;
                    }
                }
            }

            return IsValid;
        }

        private bool ValidatePassword(string password)
        {
            bool IsValid = true;
            Regex HelpExpression;

            // Validate simple properties
            IsValid = IsValid && (password.Length >= this.MinRequiredPasswordLength);

            // Validate non-alphanumeric characters
            HelpExpression = new Regex(@"\W");
            IsValid = IsValid && (HelpExpression.Matches(password).Count >= this.MinRequiredNonAlphanumericCharacters);

            // Validate regular expression
            HelpExpression = new Regex(this.PasswordStrengthRegularExpression);
            IsValid = IsValid && (HelpExpression.Matches(password).Count > 0);

            return IsValid;
        }

        private bool ValidateUserInternal(SimpleUser user, string password)
        {
            if (user != null)
            {
                string passwordValidate = TransformPassword(password, ref user.PasswordSalt);
                if (string.Compare(passwordValidate, user.Password) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private MembershipUser CreateMembershipFromInternalUser(SimpleUser user)
        {
            MembershipUser muser = new MembershipUser(base.Name,
                user.UserName, user.UserKey, user.Email, user.PasswordQuestion,
                string.Empty, true, false, user.CreationDate, user.LastLoginDate,
                user.LastActivityDate, user.LastPasswordChangeDate, DateTime.MaxValue);

            return muser;
        }

        private MembershipUserCollection CreateMembershipCollectionFromInternalList(List<SimpleUser> users)
        {
            MembershipUserCollection ReturnCollection = new MembershipUserCollection();

            foreach (SimpleUser user in users)
            {
                ReturnCollection.Add(CreateMembershipFromInternalUser(user));
            }

            return ReturnCollection;
        }

        #endregion
    }
}
