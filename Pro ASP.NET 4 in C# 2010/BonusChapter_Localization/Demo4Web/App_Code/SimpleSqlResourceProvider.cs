namespace Apress.Localization
{
    using System;
    using System.Configuration;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Text;
    using System.Threading;
    using System.Web.Compilation;
    using System.Web.UI;
    using System.Web.UI.Design;
    using System.Web;

    [DesignTimeResourceProviderFactoryAttribute(typeof(SimpleSqlResourceDesignTimeFactory))]
    public sealed class SimpleSqlResourceProviderFactory : ResourceProviderFactory
    {
        public override IResourceProvider CreateLocalResourceProvider(string virtualPath)
        {
            virtualPath = System.IO.Path.GetFileName(virtualPath);
            return new SimpleSqlResourceProvider(virtualPath, ConfigurationManager.ConnectionStrings["ResDB"].ConnectionString);
        }

        public override IResourceProvider CreateGlobalResourceProvider(string className)
        {
            return null;
        }

        private sealed class SimpleSqlResourceProvider : IResourceProvider
        {
            private string _virtualPath;
            private SimpleSqlResourceDatabaseHelper _db = null;
            private ListDictionary _resCache = null;

            internal SimpleSqlResourceProvider(string virtualPath, string connString)
            {
                _virtualPath = System.IO.Path.GetFileName(virtualPath);
                _db = new SimpleSqlResourceDatabaseHelper(connString);
            }

            private ListDictionary GetResources(string cultureName)
            {
                if (_resCache == null)
                    _resCache = new ListDictionary();

                if (cultureName == null)
                    cultureName = string.Empty;

                ListDictionary dict;
                if (!_resCache.Contains(cultureName))
                {
                    dict = _db.GetResources(cultureName, _virtualPath);
                    _resCache.Add(cultureName, dict);
                }
                else
                {
                    dict = (ListDictionary)_resCache[cultureName];
                }

                return dict;
            }

            object IResourceProvider.GetObject(string resourceKey, CultureInfo culture)
            {
                // Retrieve the currently active culture
                string cultureName = null;

                if (culture == null)
                {
                    CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
                    if (currentUICulture != null)
                    {
                        cultureName = currentUICulture.Name;
                    }
                }
                else
                {
                    cultureName = culture.Name;
                }

                // Now get the dictionary for the retrieved culture
                ListDictionary dict = GetResources(cultureName);

                // If dictionary does not exist, fall back to
                // the dictionary for the neutral culture
                if (dict.Contains(resourceKey))
                    return dict[resourceKey];
                else
                {
                    dict = GetResources(null);
                    if (dict.Contains(resourceKey))
                        return dict[resourceKey];
                }

                // No dictionary found at all
                return null;
            }

            IResourceReader IResourceProvider.ResourceReader
            {
                get
                {
                    return new SimpleSqlResourceReader(GetResources(null));
                }
            }

            private sealed class SimpleSqlResourceReader : IResourceReader
            {
                private IDictionary _resources;

                internal SimpleSqlResourceReader(IDictionary dict)
                {
                    _resources = dict;
                }

                void IResourceReader.Close()
                {
                    // Nothing to do...
                }

                IDictionaryEnumerator IResourceReader.GetEnumerator()
                {
                    return _resources.GetEnumerator();
                }

                IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return _resources.GetEnumerator();
                }

                void IDisposable.Dispose()
                {
                    // Nothing to do...
                }
            }
        }
    }
}