using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Question1
{
    struct LOC  //although not specified, LOC seems to contain 2 elements an id and a value
    {
        public int id;
        public string value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //use reflection to find current directory
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                //the question input file path relative to current directory
                string file = dir + @"\File\Q1_Text.txt";

                var list = new List<string>();  //each LOC line in the file will be read into a string in this list

                var filestream = new FileStream(file, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(filestream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "LOC")  //check the line starts with LOC
                        {
                            line = line.Remove(line.Length - 1);  //remove end of line hyphen
                            list.Add(line);
                        }
                    }
                }

                //foreach(string line in list)      //Check file was read correctly and only LOC lines in list
                //{
                //    Console.WriteLine(line);
                //}


                LOC[] LOCs = new LOC[list.Count];   //to hold the required LOC data as an array of LOC Structs

                //Loop through the list, not using foreach as a counter is required
                for (int i = 0; i < list.Count; i++)
                {
                    string[] lineElements = list[i].Split('+');

                    LOCs[i].id = Convert.ToInt32(lineElements[1]);
                    LOCs[i].value = lineElements[2];
                }

                //Loop through the resulting array and write result to the console window
                for (int i = 0; i < LOCs.Length; i++)
                {
                    Console.WriteLine("LOC:  id={0}  value={1}", LOCs[i].id, LOCs[i].value);
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
