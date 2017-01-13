using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;

namespace SteamInterface
{
    class AppListRoot //These Classes are the framework for parsing the app id list from the web api
    {
        public Applist applist { get; set; }
    }
    class Applist
    {
        public List<Apps> apps { get; set; }
    }
    class Apps
    {
        public int appid { get; set; }

        public string name { get; set; }
    }

    class AppNewsRoot
    {
        public AppNews appnews { get; set; }
    }
    class AppNews
    {
        public int appid { get; set; }
        public List<NewsItems> newsItems { get; set; }
    }
    class NewsItems
    {
        public string gid { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public bool is_external_url { get; set; }

        public string author { get; set; }

        public string contents { get; set; }

        public string feedlabel { get; set; }

        public int date { get; set; }

        public string feedname { get; set; }
    }

    class SteamMethodUrlLibrary // This class builds strings to be fed into the Retriever class
    {
        private string baseString = "http://api.steampowered.com";

        public string appNamesIds
        {
            get
            {
                return baseString + "/ISteamApps/GetAppList/v0002/";
            }
        }

        public string newsFeedConcatenator(int myAppid)     // This function takes the AppId as an argument and concatenates it into an http request for the most recent news entry corresponding to that ID
        {
                return baseString + "/ISteamNews/GetNewsForApp/V0002/?format=json&appid=" + myAppid + "&count=1";
        }
    }

    class Retriever
    {
        private WebClient web = new WebClient();

        public string RetrieveJson(string uriString) // This function takes a string as an argument, converts it into a URI and attempts a web request.
        {            
            Uri appendedUri = new Uri(uriString);

            try
            {
                return web.DownloadString(appendedUri);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error");
                return null;
            }
        }
    }
    /*abstract class QueryBuilder
    {
        public QueryBuilder()
        {

        }
    }
    */

}
