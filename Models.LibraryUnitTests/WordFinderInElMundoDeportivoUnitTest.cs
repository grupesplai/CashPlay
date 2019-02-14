using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ahorcado.ServiceLibrary;
using System.Diagnostics;

namespace Models.LibraryUnitTests
{
    [TestClass]
    public class WordFinderInElMundoDeportivoUnitTest
    {
        [TestMethod]
        public void TestWhen_RandomPhraseFromElMundoDeportivo()
        {
            WordFinderInElMundoDeportivo wf = new WordFinderInElMundoDeportivo();
            string phrase = wf.GetPhrase();

            Assert.AreNotEqual(true, string.IsNullOrWhiteSpace(phrase));

            Debug.Print("Phrase: "+ phrase);
        }
    }
}
