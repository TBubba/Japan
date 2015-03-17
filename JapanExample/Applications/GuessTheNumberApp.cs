using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Japan;
using JapanExample.Events;

namespace JapanExample.Applications
{
    internal class GuessTheNumberApp : ControlApplication
    {
        // Private
        private int _number;
        private string _words;

        private bool _numbersToWords;
        private int _minNumber = 0;
        private int _maxNumber = 100;
        private NumberSettings _numSettings = NumberSettings.Default();

        private Random _random;

        // Constructor(s)
        internal GuessTheNumberApp(bool numbersToWords) : this(numbersToWords, 0, 100)
        {
        }
        internal GuessTheNumberApp(bool numbersToWords, int minNumber, int maxNumber)
        {
            // Apply settings
            _numbersToWords = numbersToWords;
            _minNumber = minNumber;
            _maxNumber = maxNumber;

            // Create random
            _random = new Random();
        }

        // Game Methods
        private void CreateNewQuestion()
        {
            // Slumpa ett nummer
            _number = _random.Next(_minNumber, _maxNumber);

            // Genera orden
            _words = Numbers.GetRomanNumber(_number, _numSettings);

            // Skriv
            if (_numbersToWords)
                Control.WriteLine(_number.ToString());
            else
                Control.WriteLine(_words);
        }

        private void CorrectAnswerNumber(string input)
        {
            int answer;
            string text = System.Text.RegularExpressions.Regex.Replace(input, "[^.0-9]", "");

            // Try converting the guess to a number
            if (int.TryParse(text, out answer))
            {
                // Type the players guess in the console
                Control.WriteLine(text);

                // If the guess was correct
                if (answer == _number)
                {
                    // Type that it was correct
                    Control.WriteLine("Correct! " + (_random.Next(2) == 0 ? ":D" : ":)"));

                    // Generate new question
                    CreateNewQuestion();
                }
                else
                {
                    // Type that the guess was incorrect (and let them try again)
                    Control.WriteLine("Wrong.");
                }
            }
            else
            {
                // Type that the player should only use digits (this occurs when the user breaks that rule)
                Control.WriteLine("Type the number with digits, and digits only (0 - 9).");
            }
        }
        private void CorrectAnswerWords(string input)
        {
            string answer = System.Text.RegularExpressions.Regex.Replace(input, "[^a-zA-Z -]", "");

            // Type the players guess in the console
            Control.WriteLine(answer);

            // If the guess was correct
            if (answer == _words)
            {
                // Type that it was correct
                Control.WriteLine("Correct! " + (_random.Next(2) == 0 ? ":D" : ":)"));

                // Generate new question
                CreateNewQuestion();
            }
            else
            {
                // Type that the guess was incorrect (and let them try again)
                Control.WriteLine("Wrong.");
            }
        }

        internal void StartGame()
        {
            // Add some kind of anti-multi-start mechanism (?)

            // Create a starting-question
            CreateNewQuestion();
        }

        // Event Methods
        protected override void OnApplied(FormControl control)
        {
            // Type basic instructions (also clarifies the current game-mode)
            if (_numbersToWords)
                Control.WriteLine("Type the numbers in japanese (using romans).");
            else
                Control.WriteLine("Type the numbers with digits.");
        }

        public override void OnInput(object sender, InputEventArgs e)
        {
            // Check answer (using different methods depending on game mode)
            if (_numbersToWords)
                CorrectAnswerWords(e.Input);
            else
                CorrectAnswerNumber(e.Input);
        }
    }
}
