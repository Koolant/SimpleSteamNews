using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace SteamInterface
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Retriever myRetriever = new Retriever();
            SteamMethodUrlLibrary steamMethodLibrary = new SteamMethodUrlLibrary();

            string appNamesIdsUrlString = steamMethodLibrary.appNamesIds;   // This string contains the hard coded URL of the JSON data containing the Names and IDs of all available products.

            string jsonString = myRetriever.RetrieveJson(appNamesIdsUrlString); // This string contains the JSON data pulled from the Steam API.

            AppListRoot applistRoot = new AppListRoot();
            applistRoot = JsonConvert.DeserializeObject<AppListRoot>(jsonString);   // Deserializes the JSON data into objects containing two properties: AppID and Name.

            bool endProgram = false;
            
            while (!endProgram)
            {
                string userInput = Console.ReadLine();

                int targetObjId = (from t in applistRoot.applist.apps          // This lambda expression will search through the objects for the first one containing the users search string and return the property called "appid" of that object.
                                   where t.name.Contains(userInput)    // The reason for this is that the news articles are found in a different set of JSON data that is indexed by appid rather than title.
                                   select t).First().appid;                    // Thus the appid that corresponds to the title must be retrieved first in order to query the JSON data that contains the news.

                string getNewUrlString = steamMethodLibrary.newsFeedConcatenator(targetObjId);  // This string is the new http request built from the AppId we've just located.

                string newJsonString = myRetriever.RetrieveJson(getNewUrlString); // This string contains the result of the new http request.

                AppNewsRoot appNewsRoot = new AppNewsRoot();

                appNewsRoot = JsonConvert.DeserializeObject<AppNewsRoot>(newJsonString); // This deserializes the news feed JSON data into an object.

                string articleText = appNewsRoot.appnews.newsItems.First().contents;    // This pulls the body of the article from the "contents" property of the object.
                                                                                        // The article body comes down as html so I will need to format this once I have a functional UI.

                Console.WriteLine(articleText);
                Console.WriteLine("\r\nEnd? y/n");

                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    endProgram = true;
                }
                Console.Clear();
            }
        }
    }
}
 