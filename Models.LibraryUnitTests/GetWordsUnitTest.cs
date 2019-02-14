using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ahorcado.ServiceLibrary;
using System.IO;

namespace Models.LibraryUnitTests
{
    [TestClass]
    public class GetWordsUnitTest
    {
        [TestMethod]
        public void TestWhen_GetHtmlfromUrl()
        {
            string url = "https://www.york.ac.uk/teaching/cws/wws/webpage1.html";

            string htmlInUrl = HtmlHelper.GetHtmlFromUrl(url);

            Assert.IsNotNull(htmlInUrl);
            Assert.AreEqual("<HMTL>", htmlInUrl.Substring(0,6));
            Assert.AreEqual(true, htmlInUrl.Contains("There are lots of ways to create"));
        }

        [TestMethod]
        public void TestWhen_GetTextWithXPathInHtml()
        {
            string fileWithHtml = @"C:\Users\G1\Documents\Visual Studio 2015\Projects\Ahorcado\Models.LibraryUnitTests\htmlElDiario.html";

            string html = File.ReadAllText(fileWithHtml);
            string xpath = "//article/div/header/h3/a";
            string[] results = HtmlHelper.GetResultWithXPath(html, xpath);

            Assert.AreEqual("No hubo alineación indebida del Barça en la ida de Copa: Chumi podía jugar", results[0]);
        }
    }
}
