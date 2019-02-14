using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.ServiceLibrary
{
    public static class HtmlHelper
    {
        public static string GetHtmlFromUrl(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
            return data;
        }

        public static string[] GetResultWithXPath(string html, string xpath)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);

            IList<string> results = new List<string>();
            foreach (HtmlNode row in doc.DocumentNode.SelectNodes(xpath))
            {
                results.Add(row.InnerText);
            }
            return results.ToArray();
        }
    }
}
