using System;
using System.Text;
using System.Collections.Specialized;

namespace APress.ProAspNet.Providers.Store
{
    public class SimpleRole
    {
        public string RoleName = "";
        public StringCollection AssignedUsers = new StringCollection();
    }
}
