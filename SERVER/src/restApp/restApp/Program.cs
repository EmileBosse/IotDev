using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Net;

namespace restApp
{

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract, WebInvoke(UriTemplate = "/sum", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        double sum(double x, double y);
    }

    public class Calculator : ICalculator
    {
        public double sum(double x, double y)
        {
            return x + y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9011/Calculator";
            WebServiceHost myHost = new WebServiceHost(typeof(Calculator), new Uri(baseAddress));
            Console.WriteLine("starting service...");
            myHost.Open();
            Console.WriteLine("press any key to close the service...");
            Console.ReadLine();
            myHost.Close();
        }
    }
}
