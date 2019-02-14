using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Library.Game
{
    public class Hanged
    {
        public const int MaxErrorsPosibles = 5;

        public Hanged()
        {

        }

        public int Errors { get; private set; }
        public string PhraseToGuess { get; private set; }
        public string ActualPhaseState { get; private set; } = "";
        public GameState State { get; private set; } = GameState.NotStarted;


        public void StarGame(string phraseToGuess)
        {
            this.PhraseToGuess = phraseToGuess;
            foreach (char letter in this.PhraseToGuess)
            {
                this.ActualPhaseState += isValid(letter) ? '_' : letter;
            }
            this.State = GameState.NotFinished;
            this.Errors = 0;
        }

        public static bool isValid(char letter)
        {
            if ((int)letter < 65 || (int)letter > 90)
            {
                if ((int)letter < 97 || (int)letter > 122)
                    if (letter == 'Ñ' || letter == 'ñ')
                        return true;
                    else
                        return false;
            }

            return true;
        }

        public string GuestChar(char v)
        {
            if (this.State == GameState.NotStarted) throw new Exception("Game not started");

            if (this.PhraseToGuess.IndexOf(v) == -1 && this.PhraseToGuess.IndexOf(Char.ToUpper(v)) == -1)
                this.Errors++;

            int index = 0;
            foreach (char letter in PhraseToGuess)
            {
                if (letter == v || letter == Char.ToUpper(v))
                {
                    this.ActualPhaseState = this.ActualPhaseState.Substring(0, index) + letter +
                       this.ActualPhaseState.Substring(index + 1, this.ActualPhaseState.Length - (index + 1));
                }
                index++;
            }
            if (this.ActualPhaseState == this.PhraseToGuess)
                this.State = GameState.Winner;
            return ActualPhaseState;
        }
    }
}
