using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado.ServiceLibrary.WordsToProvider
{
    public class WordFinderMockProvider : IWordFinder
    {
        public string GetPhrase()
        {
            return "Hola mundo";
        }
    }
}
