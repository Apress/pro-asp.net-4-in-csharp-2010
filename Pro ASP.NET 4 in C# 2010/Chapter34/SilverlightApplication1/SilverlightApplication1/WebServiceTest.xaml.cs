using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightApplication1.ServiceReference1;
using System.ServiceModel;
using System.Windows.Browser;

namespace SilverlightApplication1
{
    public partial class WebServiceTest : UserControl
    {
        public WebServiceTest()
        {
            InitializeComponent();
        }

        private void cmdGetTime_Click(object sender, RoutedEventArgs e)
        {
            // Create the proxy.
            TestServiceClient proxy = new TestServiceClient();

            // Create a new URL for the TestService.svc service using the current port number.
            proxy.Endpoint.Address = new EndpointAddress(
                "http://localhost:" +
              HtmlPage.Document.DocumentUri.Port + "/SilverlightApplication1.Web/TestService.svc");
                        
            // Attach an event handler to the completed event.
            proxy.GetServerTimeCompleted += new
              EventHandler<GetServerTimeCompletedEventArgs>(GetServerTimeCompleted);

            // Start the web service call.
            proxy.GetServerTimeAsync();
        }

        private void GetServerTimeCompleted(object sender, GetServerTimeCompletedEventArgs e)
        {
            try
            {
                lblTime.Text = e.Result.ToLongTimeString();
            }
            catch (Exception err)
            {
                lblTime.Text = err.InnerException.ToString();
            }
        }

    }
}
