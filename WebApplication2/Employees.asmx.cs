using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;

namespace WebApplication2
{
    /// <summary>
    /// Summary description for Employees
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Employees : System.Web.Services.WebService
    {
        const string fileName = "c:\\App_Data\\data.xml";

        [WebMethod] // Post command should return string 
        public string HelloWorld()
        {
            return "hello post world";
        }

        [WebMethod] // Get command should return void and Context.Response.Write
        public void HelloWorld1()
        {
            Context.Response.Write("Hello World from get");     
        }
                
        [WebMethod] 
        public void getAllEmployees()
        {

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(fileName);
            XmlNodeList list = xdoc.SelectNodes("//Employee");
            Console.WriteLine(list);
            JArray jarray = new JArray();
            foreach (XmlNode node in list)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(node);
                jarray.Add(JObject.Parse(json));
            }

            JArray jarray1 = new JArray();
            foreach (JObject x in jarray)
            {                
                object x1 = x["Employee"];
                Console.WriteLine(x1);
                jarray1.Add((JObject)x1);
            }
            
            //string jsonText = JsonConvert.SerializeXmlNode(doc);
            // TBD - need to remove the password node here.
            Context.Response.Write(jarray1);
        }

        [WebMethod]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true, ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public void GetPersonInfo()
        {
          // ASP.NET will automatically JSON serialize this as well.
          object e =  new {
            FirstName = "Eli" ,
            LastName = "Arad" ,
            Address = "Enterprise E",
            City = "Deck 9",
            State = "Israel",
            ZipCode = "001"
          };

          var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
          Context.Response.Write(oSerializer.Serialize(e));
        }
        bool IsEmailExists(string email)
        {
            var c = (from employee in XDocument.Load(fileName).Descendants("Employee")
                     where employee.Element("email").Value == email
                     select employee.Element("email").Value).Count();

            Console.WriteLine(c);
            return c > 0 ? true : false;
        }
        [WebMethod]
        public string AddNewEmployee(string email, dynamic data)
        {


            if (IsEmailExists(email))
            {
                string r = CreateResponse("failed, email already exists");
                return r;
            }


            XmlDocument doc = new XmlDocument();
            XmlElement element1;
            XmlElement element2 = null;
            try
            {
                if (File.Exists(fileName))
                    doc.Load(fileName);

                element1 = doc.CreateElement("Employee");


                foreach (KeyValuePair<string, object> kvp in data)
                {
                    XmlElement bar = doc.CreateElement(kvp.Key);
                    bar.InnerText = kvp.Value.ToString();
                    element1.AppendChild(bar);
                }

                doc.DocumentElement.AppendChild(element1);
                doc.Save(fileName);

                string r = CreateResponse("ok");
                return r;

            }
            catch (Exception err)
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);

                element1 = doc.CreateElement(string.Empty, "Employees", string.Empty);
                doc.AppendChild(element1);

                //(2) string.Empty makes cleaner code
                element2 = doc.CreateElement(string.Empty, "Employee", string.Empty);
                element1.AppendChild(element2);

                foreach (KeyValuePair<string, object> kvp in data)
                {
                    XmlElement element3 = doc.CreateElement(string.Empty, kvp.Key, string.Empty);
                    XmlText text1 = doc.CreateTextNode(kvp.Value.ToString());
                    element3.AppendChild(text1);
                    element2.AppendChild(element3);
                }
                doc.Save(fileName);
                string r = CreateResponse("ok");
                return r;
            }                                
        }
        string CreateResponse(string status)
        {
            object e = new
            {
                status = status
            };

            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(e);
        }
    }
}
