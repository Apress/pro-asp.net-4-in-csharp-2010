using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Caching;
using System.Xml.Serialization;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class FileCacheProvider : OutputCacheProvider
{
    public override void Initialize(string name, System.Collections.Specialized.NameValueCollection attributes)
    {
        base.Initialize(name, attributes);

        // Retrieve the web.config settings.
        CachePath = HttpContext.Current.Server.MapPath(attributes["cachePath"]);
    }
    
    public string CachePath
    {
        get;
        set;
    }

    public override object Add(string key, object entry, DateTime utcExpiry)
    {        
        // Transform the key to a unique filename.
        string path = ConvertKeyToPath(key);

        // Set it only if it is not already cached.
        if (!File.Exists(path))
        {            
            Set(key, entry, utcExpiry);
        }
        return entry;        
    }

    public override void Set(string key, object entry, DateTime utcExpiry)
    {
        CacheItem item = new CacheItem(entry, utcExpiry);
        string path = ConvertKeyToPath(key);

        // Overwrite it, even if it already exists.
        using (FileStream file = File.OpenWrite(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, item);
        }
    }

    public override object Get(string key)
    {       
        string path = ConvertKeyToPath(key);

        if (!File.Exists(path))
            return null;

        CacheItem item = null;
        using (FileStream file = File.OpenRead(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            item = (CacheItem)formatter.Deserialize(file);
        }

        // Remove expired items.
        if (item.ExpiryDate <= DateTime.Now.ToUniversalTime())
        {            
            Remove(key);
            return null;
        }

        return item.Item;
    }

    public override void Remove(string key)
    {
        string path = ConvertKeyToPath(key);

        if (File.Exists(path))
            File.Delete(path);
    }      

    private string ConvertKeyToPath(string key)
    {
        // Flatten it to a single file name, with no path information.
        string file = key.Replace('/', '-');        
       
        // Add .txt extension so it's not confused with a real ASP.NET file.
        file += ".txt";
        return Path.Combine(CachePath, file);
    }
}


[Serializable]
public class CacheItem
{
    public DateTime ExpiryDate;
    public object Item;

    public CacheItem(object item, DateTime expiryDate)
    {
        ExpiryDate = expiryDate;
        Item = item;
    }
}