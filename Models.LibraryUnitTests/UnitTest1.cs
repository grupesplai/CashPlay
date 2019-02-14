using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Library.Game;

namespace Models.LibraryUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWhen_GuessCharInPhrase()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            var result = game.GuestChar('o');

            Assert.AreEqual(GameState.NotFinished, game.State);
            Assert.AreEqual("_o__ ____o", result);
            Assert.AreEqual(0, game.Errors);
        }

        [TestMethod]
        public void TestWhen_GuessCharInNotPhrase()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            var result = game.GuestChar('x');

            Assert.AreEqual(GameState.NotFinished, game.State);
            Assert.AreEqual("____ _____", result);
            Assert.AreEqual(1, game.Errors);
        }

        [TestMethod]
        public void TestWhen_Guess2CharInNotPhrase()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            var result = game.GuestChar('o');
            result = game.GuestChar('a');

            Assert.AreEqual(GameState.NotFinished, game.State);
            Assert.AreEqual("_o_a ____o", result);
            Assert.AreEqual(0, game.Errors);
        }

        [TestMethod]
        public void TestWhen_GuessAllCharInPhrase()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            var result = game.GuestChar('H');
            result = game.GuestChar('o');
            result = game.GuestChar('l');
            result = game.GuestChar('a');
            result = game.GuestChar('m');
            result = game.GuestChar('u');
            result = game.GuestChar('n');
            result = game.GuestChar('d');

            Assert.AreEqual(GameState.Winner, game.State);
            Assert.AreEqual("Hola mundo", result);
            Assert.AreEqual(0, game.Errors);
        }

        [TestMethod]
        public void TestWhen_GuessCapsInPhrase()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            var result = game.GuestChar('h');

            Assert.AreEqual(GameState.NotFinished, game.State);
            Assert.AreEqual("H___ _____", result);
            Assert.AreEqual(0, game.Errors);
        }

        [TestMethod]
        public void TestWhen_StartingNewGame()
        {
            Hanged game = new Hanged();
            game.StarGame("Hola mundo");
            
            Assert.AreEqual("____ _____", game.ActualPhaseState);
        }

        [TestMethod]
        public void TestWhen_IsValidChar()
        {
            char[] lettersToTest =  { 'a','B','A','T'};

            foreach (var item in lettersToTest)
            {
                bool result = Hanged.isValid(item);
                if(!result)
                {
                    Assert.Fail($"Letter {item} should be valid");
                }
            }
        }

        [TestMethod]
        public void TestWhen_IsUnvalidChar()
        {
            char[] lettersToTest = { '_', '!', ',', '\n' };

            foreach (var item in lettersToTest)
            {
                bool result = Hanged.isValid(item);
                if (result)
                {
                    Assert.Fail($"Letter {item} should not be valid");
                }
            }
        }
    }
}
