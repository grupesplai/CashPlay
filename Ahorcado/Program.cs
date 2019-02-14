using Ahorcado.ServiceLibrary;
using Models.Library.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            WordFinderInElMundoDeportivo wordFinder = new WordFinderInElMundoDeportivo();
            Hanged hanged = new Hanged();

            hanged.StarGame(wordFinder.GetPhrase());

            while (true)
            {
                Console.WriteLine(hanged.ActualPhaseState);
                Console.WriteLine($"Errors: {hanged.Errors} / {Hanged.MaxErrorsPosibles}");
                Console.Write("Letra? ");
                char newChar = Console.ReadKey().KeyChar;

                while (!Hanged.isValid(newChar))
                {
                    Console.Write("\n Not valid letter. Try another!");
                    newChar = Console.ReadKey().KeyChar;
                }

                var result = hanged.GuestChar(newChar);
                Console.Clear();

            }
        }
    }
}
