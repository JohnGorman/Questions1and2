using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Reflection;

namespace Question2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //use reflection to find current directory
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //the question input file path relative to current directory
                string file = dir + @"\File\Q2_xml.xml";

                XDocument xDocument = XDocument.Load(file);

                var results = xDocument.Descendants("Reference")
                    .Select(r => new
                    {
                        Reference = r.Attribute("RefCode").Value,
                        RefText = r.Element("RefText").Value
                    }).Where(rf => rf.Reference == "MWB" || rf.Reference == "TRV" || rf.Reference == "CAR");

                foreach (var result in results)
                {
                    Console.WriteLine("{0} : {1}", result.Reference, result.RefText);
                }

                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Sorry, something went wrong!");
                Console.ReadLine();
            }

        }
    }
}
