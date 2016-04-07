using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClientApp
{
    using WCFClientApp.WCFService;
    class Program
    {
        static void Main(string[] args)
        {

            Service1Client client = new Service1Client();
            string str  = client.GetData(19);
            Console.WriteLine(str);
            int r = client.Add(1, 2);
            Console.WriteLine(r);
            

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();

        }
    }
}
