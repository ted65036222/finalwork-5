using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplication1.Service
{
    public class DataService
    {
        private static List<Models.Album> list = new List<Models.Album>();

        static DataService()
        {
            var item = new Models.Album();

            item.ID = "1";
            item.Name = "pop";
            item.Number = "The Best Of The Men At Work";
            item.Email = "8";
            item.ImageUrl = @"/Content/Image/Desert.jpg";

            list.Add(item);

            var item2 = new Models.Album();
            item2.ID = "2";
            item2.Name = "Metal";
            item2.Number = "Black Light Syndrome";
            item2.Email = "20";
            item2.ImageUrl = @"/Content/Image/Desert.jpg";
            list.Add(item2);


        }
        public DataService()
        {

        }

        public List<Models.Album> LoadAllAlbum()
        {
             
            return list;
        }

        public void LoadCandidate()
        {
            using (var webClient = new System.Net.WebClient())
            {
               // var json = webClient(URL);
                // Now parse with JSON.Net
            }
            var baseAddress = "http://www.taichungfes.com.tw/api/Candidate/GetPage";

            var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = @"{'PageNo':1,'PageSize':16,'TotalCount':0}";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);

            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();

            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();

            //
        }



    }
}