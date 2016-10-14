using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

[ServiceContract]
[AspNetCompatibilityRequirements(RequirementsMode =
 AspNetCompatibilityRequirementsMode.Allowed)]
public class TestService
{
    [OperationContract]
    public DateTime GetServerTime()
    {
        return DateTime.Now;
    }
}
