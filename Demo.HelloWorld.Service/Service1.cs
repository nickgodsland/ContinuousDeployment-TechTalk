using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;
using Nancy;
using Nancy.Hosting.Wcf;

namespace Demo.HelloWorld.Service
{
   public partial class Service1 : ServiceBase
   {

      public Service1()
      {
         InitializeComponent();
      }

      protected override void OnStart(string[] args)
      {
         var host = new WebServiceHost(new NancyWcfGenericService(),
                              new Uri("http://localhost:1234/base/"));
         host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), "");
         host.Open();
      }

      protected override void OnStop()
      {
      }

      public class SampleModule : NancyModule
      {
         public SampleModule()
         {
            Get["/"] = _ => "Hello world!";
         }
      }
   }
}
