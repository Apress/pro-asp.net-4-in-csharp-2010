using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;


public class OrderService : ConfigurationSection 
{
	[ConfigurationProperty("available",
    IsRequired = false, DefaultValue = true)]
	public bool Available
	{
		get { return (bool)base["available"]; }
		set { base["available"] = value; }
	}

	[ConfigurationProperty("pollTimeout",
    IsRequired = true)]
	public TimeSpan PollTimeout
	{
		get { return (TimeSpan)base["pollTimeout"]; }
		set { base["pollTimeout"] = value; }
	}

    [ConfigurationProperty("location",
    IsRequired = true)]
	public Location Location
	{
        get { return (Location)base["location"]; }
        set { base["location"] = value; }
	}
}


public class Location : ConfigurationElement
{
    [ConfigurationProperty("computer",
    IsRequired = true)]
	public string Computer
	{
		get { return (string)base["computer"]; }
		set { base["computer"] = value; }
	}

    [ConfigurationProperty("port",
    IsRequired = true)]
    public int Port
    {
        get { return (int)base["port"]; }
        set { base["port"] = value; }
    }

    [ConfigurationProperty("endpoint",
    IsRequired = true)]
    public string Endpoint
    {
        get { return (string)base["endpoint"]; }
        set { base["endpoint"] = value; }
    }
}

	
