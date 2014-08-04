using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BukkitUI.ServerManager {
    class HTMLParser {

        private String url { get; set; }
        public Dictionary<String, String> linkDescTable { get { update(); return linkTable; } }

        private Dictionary<String, String> linkTable;
        private String match1 { get; set; }
        private String match2 { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        private ProgressBar progressBar { get; set; }

        public HTMLParser(ProgressBar pBar) { 
            url = "http://dl.bukkit.org/downloads/craftbukkit/";
            match1 = "title=\"download ";
            match2 = ".jar";
            progressBar = pBar;
        }

        private void update() {

            // Set progressBar
            progressBar.Style = ProgressBarStyle.Blocks;
            
            linkTable = new Dictionary<string, string>();
            linkTable.Clear();

            String dlPageSource = new WebClient().DownloadString(url);
            bool foundTotalPages = false;
            totalPages = 0;
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

            progressBar.Maximum = totalPages;

            for (int i = 1; i < totalPages; i++) {
                progressBar.Value = i;
                using (StringReader reader = new StringReader(new WebClient().DownloadString(oldUrl + i.ToString()))) {

                    while ((line = reader.ReadLine()) != null) {
                        if (line.ToLower().Contains(match1) && line.ToLower().Contains(match2)) {
                            String[] array = Regex.Split(line, "title=\"");
                            array = Regex.Split(array[1], "\"");
                            String[] array0 = Regex.Split(line, "href=\"");
                            array0 = Regex.Split(array0[1], "\"");
                            //map.put(array[0], new URL("http://dl.bukkit.org" + array0[0]));
                            linkTable.Add(array[0], "http://dl.bukkit.org" + array0[0]);
                        }
                    }
                }
            }
        }

    }
}
