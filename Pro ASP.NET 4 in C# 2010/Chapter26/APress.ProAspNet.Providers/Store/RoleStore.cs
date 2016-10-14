using System;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;

namespace APress.ProAspNet.Providers.Store
{
    public class RoleStore
    {
        XmlSerializer _Serializer;
        private string _FileName;
        List<SimpleRole> _Roles;

        #region "Singleton Implementation"

        private static Dictionary<string, RoleStore> _RegisteredStores;

        public static RoleStore GetStore(string fileName)
        {
            // Create the registered stores
            if (_RegisteredStores == null)
                _RegisteredStores = new Dictionary<string, RoleStore>();

            // Now return the approprate store
            if (!_RegisteredStores.ContainsKey(fileName))
            {
                _RegisteredStores.Add(fileName, new RoleStore(fileName));
            }

            return _RegisteredStores[fileName];
        }

        private RoleStore(string fileName)
        {
            _Roles = new List<SimpleRole>();
            _FileName = fileName;
            _Serializer = new XmlSerializer(typeof(List<SimpleRole>));

            LoadStore(_FileName);
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadStore(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                {
                    using (XmlTextReader reader = new XmlTextReader(fileName))
                    {
                        _Roles = (List<SimpleRole>)_Serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(
                    "Unable to load file {0}", fileName), ex);
            }
        }

        private void SaveStore(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(fileName))
                    System.IO.File.Delete(fileName);

                using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    _Serializer.Serialize(writer, _Roles);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(
                    "Unable to save file {0}", fileName), ex);
            }
        }

        #endregion

        public List<SimpleRole> Roles
        {
            get { return _Roles; }
        }

        public void Save()
        {
            SaveStore(_FileName);
        }

        public List<SimpleRole> GetRolesForUser(string userName)
        {
            List<SimpleRole> Results = new List<SimpleRole>();
            foreach (SimpleRole r in Roles)
            {
                if (r.AssignedUsers.Contains(userName))
                    Results.Add(r);
            }
            return Results;
        }

        public string[] GetUsersInRole(string roleName)
        {
            SimpleRole Role = GetRole(roleName);
            if (Role != null)
            {
                string[] Results = new string[Role.AssignedUsers.Count];
                Role.AssignedUsers.CopyTo(Results, 0);
                return Results;
            }
            else
            {
                throw new Exception(string.Format("Role with name {0} does not exist!", roleName));
            }
        }

        public SimpleRole GetRole(string roleName)
        {
            return Roles.Find(delegate(SimpleRole role)
                {
                    return role.RoleName.Equals(
                        roleName, StringComparison.OrdinalIgnoreCase);
                });
        }
    }
}
