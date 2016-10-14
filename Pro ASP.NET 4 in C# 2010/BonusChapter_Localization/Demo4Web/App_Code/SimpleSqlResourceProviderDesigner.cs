namespace Apress.Localization
{
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Web.Compilation;
    using System.Resources;
    using System.Data.SqlClient;
    using System.Collections;
    using System.Web.UI.Design;
    using System.Globalization;
    using System.ComponentModel.Design;
    using System.Collections.Specialized;

    public sealed class SimpleSqlResourceDesignTimeFactory : DesignTimeResourceProviderFactory
    {
        private IServiceProvider _serviceProvider = null;
        private SimpleSqlResourceDesignerProvider _localProvider = null;
        private SimpleSqlResourceDesignerProvider LocalProvider
        {
            get
            {
                if (_localProvider == null)
                    _localProvider = new SimpleSqlResourceDesignerProvider(_serviceProvider);
                return _localProvider;
            }
        }

        public override IResourceProvider CreateDesignTimeGlobalResourceProvider(IServiceProvider serviceProvider, string classKey)
        {
            return null;
        }

        public override IResourceProvider CreateDesignTimeLocalResourceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            return LocalProvider;
        }

        public override IDesignTimeResourceWriter CreateDesignTimeLocalResourceWriter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            return LocalProvider;
        }

        private sealed class SimpleSqlResourceDesignerProvider : IResourceProvider, IDesignTimeResourceWriter
        {
            private IServiceProvider _provider;
            private SimpleSqlResourceDatabaseHelper _db;
            private ListDictionary _resCache = null;

            public SimpleSqlResourceDesignerProvider(IServiceProvider provider)
            {
                _provider = provider;
                _db = new SimpleSqlResourceDatabaseHelper(CreateConnectionString(provider));
            }

            #region Private Helpers

            private ListDictionary _Resources = null;
            private ListDictionary Resources
            {
                get
                {
                    if (_Resources == null)
                    {
                        _Resources = _db.GetResources("none", GetVirtualPath(_provider));
                        if (_Resources == null)
                            _Resources = new ListDictionary();
                    }
                    return _Resources;
                }
            }

            private const string DatabaseLocationKey = "ResDB";
            private string CreateConnectionString(IServiceProvider serviceProvider)
            {
                if (serviceProvider == null)
                {
                    return System.Configuration.ConfigurationManager.AppSettings[DatabaseLocationKey];
                }
                else
                {
                    IWebApplication webApp = (IWebApplication)serviceProvider.GetService(typeof(IWebApplication));
                    return webApp.OpenWebConfiguration(true).ConnectionStrings.ConnectionStrings[DatabaseLocationKey].ConnectionString;
                }
            }

            private string GetVirtualPath(IServiceProvider provider)
            {
                IDesignerHost host = (IDesignerHost)provider.GetService(typeof(IDesignerHost));
                WebFormsRootDesigner rootDesigner = host.GetDesigner(host.RootComponent) as WebFormsRootDesigner;
                return System.IO.Path.GetFileName(rootDesigner.DocumentUrl);
            }

            private ListDictionary GetResources(string cultureName)
            {
                if (_resCache == null)
                    _resCache = new ListDictionary();

                if (cultureName == null)
                    cultureName = "none";

                ListDictionary dict;
                if (!_resCache.Contains(cultureName))
                {
                    dict = _db.GetResources(cultureName, GetVirtualPath(_provider));
                    _resCache.Add(cultureName, dict);
                }
                else
                {
                    dict = (ListDictionary)_resCache[cultureName];
                }

                return dict;
            }

            private int GetNextKeyIndex(string key, int counter)
            {
                // Go through the existing items and verify if key is used
                foreach (string k in Resources.Keys)
                {
                    if (k.IndexOf(string.Format("{0}{1}", key, counter)) >= 0)
                    {
                        counter = GetNextKeyIndex(key, counter + 1);
                    }
                }

                return counter;
            }

            #endregion

            object IResourceProvider.GetObject(string resourceKey, CultureInfo culture)
            {
                // Always use the default culture
                string cultureName = string.Empty;

                // Get the resource object
                ListDictionary dict = GetResources(cultureName);

                if (dict.Contains(resourceKey))
                    return dict[resourceKey];
                else
                {
                    dict = GetResources(null);
                    if (dict.Contains(resourceKey))
                        return dict[resourceKey];
                }

                return null;
            }

            IResourceReader IResourceProvider.ResourceReader
            {
                get
                {
                    return new SimpleSqlResourceDesignerReader(GetResources(null));
                }
            }

            string IDesignTimeResourceWriter.CreateResourceKey(string resourceName, object obj)
            {
                // Now add a dictionary for the specified object
                // But also generate a key that is not used, already
                int counter = 1;
                string objTypeName = obj.GetType().Name;
                string keyBaseName = objTypeName + "Resource" + resourceName;
                counter = GetNextKeyIndex(keyBaseName, counter);

                return string.Format("{0}{1}", keyBaseName, counter);
            }

            void IResourceWriter.AddResource(string name, byte[] value)
            {
                if (Resources.Contains(name))
                    Resources[name] = value;
                else
                    Resources.Add(name, value);
            }

            void IResourceWriter.AddResource(string name, object value)
            {
                if (Resources.Contains(name))
                    Resources[name] = value;
                else
                    Resources.Add(name, value);
            }

            void IResourceWriter.AddResource(string name, string value)
            {
                if (Resources.Contains(name))
                    Resources[name] = value;
                else
                    Resources.Add(name, value);
            }

            void IResourceWriter.Close()
            {
                // Closes connections if necessary
            }

            void IResourceWriter.Generate()
            {
                // Get the current virtual path
                string vPath = GetVirtualPath(_provider);

                // Writes back to the database
                foreach (object k in Resources.Keys)
                {
                    // For simplicity: we have just strings
                    // in our simple sample implementation
                    _db.AddResource(vPath, k.ToString(), Resources[k].ToString(), null);
                }
            }

            void IDisposable.Dispose()
            {
                // Close anything you have used
            }
        }

        private sealed class SimpleSqlResourceDesignerReader : IResourceReader
        {
            private IDictionary _resources;

            public SimpleSqlResourceDesignerReader(IDictionary dict)
            {
                _resources = dict;
            }

            public void Close()
            {
                // Nothing to do...
            }

            public System.Collections.IDictionaryEnumerator GetEnumerator()
            {
                return _resources.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _resources.GetEnumerator();
            }

            public void Dispose()
            {
                // Nothing to do...
            }
        }
    }
}
