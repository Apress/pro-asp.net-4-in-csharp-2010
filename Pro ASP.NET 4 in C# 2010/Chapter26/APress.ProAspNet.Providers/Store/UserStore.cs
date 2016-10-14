using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Collections.Generic;

namespace APress.ProAspNet.Providers.Store
{
    public class UserStore
    {
        private string _FileName;
        private List<SimpleUser> _Users;
        private XmlSerializer _Serializer;

        #region "Singleton implementation"

        private static Dictionary<string, UserStore> _RegisteredStores;

        private UserStore(string fileName)
        {
            _FileName = fileName;
            _Users = new List<SimpleUser>();
            _Serializer = new XmlSerializer(typeof(List<SimpleUser>));

            LoadStore(_FileName);
        }

        public static UserStore GetStore(string fileName)
        {
            // Create the registered stores
            if (_RegisteredStores == null)
                _RegisteredStores = new Dictionary<string, UserStore>();

            // Now return the approprate store
            if (!_RegisteredStores.ContainsKey(fileName))
            {
                _RegisteredStores.Add(fileName, new UserStore(fileName));
            }

            return _RegisteredStores[fileName];
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
                        _Users = (List<SimpleUser>)_Serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("Unable to load file {0}", fileName), ex);
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
                    _Serializer.Serialize(writer, _Users);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("Unable to save file {0}", fileName), ex);
            }
        }

        #endregion

        public List<SimpleUser> Users
        {
            get { return _Users; }
        }

        public void Save()
        {
            SaveStore(_FileName);
        }

        public SimpleUser GetUserByName(string name)
        {
            return _Users.Find(delegate(SimpleUser user)
                    {
                        return string.Equals(name, user.UserName);
                    });
        }

        public SimpleUser GetUserByEmail(string email)
        {
            return _Users.Find(delegate(SimpleUser user)
                    {
                        return string.Equals(email, user.Email);
                    });
        }

        public SimpleUser GetUserByKey(Guid key)
        {
            return _Users.Find(delegate(SimpleUser user)
            {
                return (user.UserKey.CompareTo(key) == 0);
            });
        }
    }
}
