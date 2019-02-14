using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.ServiceLibrary
{
    public class WordFinderInElMundoDeportivo : IWordFinder
    {
        public string GetPhrase()
        {
            string html = HtmlHelper.GetHtmlFromUrl("https://www.mundodeportivo.com/");
            string xpath = "//article/div/header/h3/a";

            string[] result = HtmlHelper.GetResultWithXPath(html, xpath);
            Random random = new Random();
            int index = random.Next(1,result.Length);
            return result[index -1];
        }
    }
}
