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
            string baseAddressOne = "http://localhost:9011/Calculator";
            WebServiceHost myHost = new WebServiceHost(typeof(Calculator), new Uri(baseAddressOne));
            string baseAddress = "http://localhost:9011/Multimedia";
            WebServiceHost myHostP = new WebServiceHost(typeof(Photo), new Uri(baseAddress));
            WebServiceHost myHostV = new WebServiceHost(typeof(Video), new Uri(baseAddress));
            WebServiceHost myHostM = new WebServiceHost(typeof(Music), new Uri(baseAddress));
            Console.WriteLine("starting service...");
            myHost.Open();
            myHostP.Open();
            myHostV.Open();
            myHostM.Open();
            Console.WriteLine("press any key to close the service...");
            Console.ReadLine();
            myHost.Close();
        }
    }
}
