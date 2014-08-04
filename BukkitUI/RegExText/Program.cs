using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;

namespace RegExText {
    class Program {

        private static String match1 { get; set; }
        private static String match2 { get; set; }

        static void Main(string[] args) {

            String url = "http://dl.bukkit.org/downloads/craftbukkit"; 
            match1 = "title=\"download ";
            match2 = ".jar";

            String dlPageSource = new WebClient().DownloadString(url);
            bool foundTotalPages = false;
            int totalPages = 0;
            String line;
            String oldUrl = url + "?page=";

            using (StringReader reader = new StringReader(dlPageSource)) {
                while ((line = reader.ReadLine()) != null) {
                    if (line.Contains("class=\"paginatorPageCount\"") && !foundTotalPages) {
                        totalPages = int.Parse(Regex.Split(Regex.Split(line, "(of )")[2], "(</)")[0].Trim());
                        break;
                    }
                }
                reader.Close();
                reader.Dispose();
            }

            Console.WriteLine("Total amount of pages found: " + totalPages);

            for (int i = 1; i < totalPages; i++)
                using (StringReader reader = new StringReader(new WebClient().DownloadString(oldUrl + i.ToString()))) {
                    Console.WriteLine("\nCurrently parsing page " + i);
                    Console.Title = oldUrl + i.ToString()+ " [Page " + i + "]";

                    while ((line = reader.ReadLine()) != null) {
                        if (line.ToLower().Contains(match1) && line.ToLower().Contains(match2)) {
                            Console.WriteLine("Found line that matches criteria: " + line.TrimStart());
                            String[] array = Regex.Split(line, "title=\"");
                            array = Regex.Split(array[1], "\"");
                            String[] array0 = Regex.Split(line, "href=\"");
                            array0 = Regex.Split(array0[1], "\"");
                            //map.put(array[0], new URL("http://dl.bukkit.org" + array0[0]));
                            //linkTable.Add(array[0], "http://dl.bukkit.org" + array0[0]);
                            Console.WriteLine("Found Craftbukkit server!\nTitle = " + array[0] + "\nLink = " + array0[0]);
                        }
                    }
                }

            Console.ReadKey();

        }
    }
}
