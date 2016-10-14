using System;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using APress.ProAspNet.Providers.Store;

namespace APress.ProAspNet.Providers
{
    public class XmlRoleProvider : RoleProvider
    {
        private string _FileName;
        private string _ApplicationName;
        private RoleStore _CurrentStore = null;

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "XmlRoleProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "XML Role Provider");
            }

            // Base initialization
            base.Initialize(name, config);

            // Initialize properties
            _ApplicationName = "DefaultApp";
            foreach (string key in config.Keys)
            {
                if (key.ToLower().Equals("applicationname"))
                    ApplicationName = config[key];
                else if (key.ToLower().Equals("filename"))
                    _FileName = config[key];
            }
        }

        private RoleStore CurrentStore
        {
            get
            {
                if (_CurrentStore == null)
                    _CurrentStore = RoleStore.GetStore(_FileName);
                return _CurrentStore;
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

        #endregion

        #region Methods

        public override void CreateRole(string roleName)
        {
            try
            {
                SimpleRole NewRole = new SimpleRole();
                NewRole.RoleName = roleName;
                NewRole.AssignedUsers = new StringCollection();

                CurrentStore.Roles.Add(NewRole);
                CurrentStore.Save();
            }
            catch
            {
                throw;
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            try
            {
                SimpleRole Role = CurrentStore.GetRole(roleName);
                if (Role != null)
                {
                    CurrentStore.Roles.Remove(Role);
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

        public override bool RoleExists(string roleName)
        {
            try
            {
                if (CurrentStore.GetRole(roleName) != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                throw;
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                // Get the roles to be modified
                foreach (string roleName in roleNames)
                {
                    SimpleRole Role = CurrentStore.GetRole(roleName);
                    if (Role != null)
                    {
                        foreach (string userName in usernames)
                        {
                            if (!Role.AssignedUsers.Contains(userName))
                            {
                                Role.AssignedUsers.Add(userName);
                            }
                        }
                    }
                }

                CurrentStore.Save();
            }
            catch
            {
                throw;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                // Get the roles to be modified
                List<SimpleRole> TargetRoles = new List<SimpleRole>();
                foreach (string roleName in roleNames)
                {
                    SimpleRole Role = CurrentStore.GetRole(roleName);
                    if (Role != null)
                    {
                        foreach (string userName in usernames)
                        {
                            if (Role.AssignedUsers.Contains(userName))
                            {
                                Role.AssignedUsers.Remove(userName);
                            }
                        }
                    }
                }

                CurrentStore.Save();
            }
            catch
            {
                throw;
            }
        }

        public override string[] GetAllRoles()
        {
            try
            {
                string[] Results = new string[CurrentStore.Roles.Count];
                for (int i = 0; i < Results.Length; i++)
                {
                    Results[i] = CurrentStore.Roles[i].RoleName;
                }

                return Results;
            }
            catch
            {
                throw;
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                List<SimpleRole> RolesForUser = CurrentStore.GetRolesForUser(username);
                string[] Results = new string[RolesForUser.Count];
                for (int i = 0; i < Results.Length; i++)
                    Results[i] = RolesForUser[i].RoleName;
                return Results;
            }
            catch
            {
                throw;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            try
            {
                return CurrentStore.GetUsersInRole(roleName);
            }
            catch
            {
                throw;
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                SimpleRole Role = CurrentStore.GetRole(roleName);
                if (Role != null)
                {
                    return Role.AssignedUsers.Contains(username);
                }
                else
                {
                    throw new ProviderException("Role does not exist!");
                }
            }
            catch
            {
                throw;
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            try
            {
                List<string> Results = new List<string>();
                Regex Expression = new Regex(usernameToMatch.Replace("%", @"\w*"));
                SimpleRole Role = CurrentStore.GetRole(roleName);
                if (Role != null)
                {
                    foreach (string userName in Role.AssignedUsers)
                    {
                        if (Expression.IsMatch(userName))
                            Results.Add(userName);
                    }
                }
                else
                {
                    throw new ProviderException("Role does not exist!");
                }

                return Results.ToArray();
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
