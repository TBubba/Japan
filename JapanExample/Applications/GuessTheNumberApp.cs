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
        private enum AppState
        {
            NotStarted,

            SetGameMode,
            SetAlphabet,
            SetMinNumber,
            SetMaxNumber,

            InGame
        }

        // Private
        private int _number;
        private string _words;

        private bool _numbersToWords;
        private bool _hiragana;
        private int _minNumber = 0;
        private int _maxNumber = 100;
        private NumberSettings _numberSettings = NumberSettings.Default();

        private Random _random;

        private AppState _state; 

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
            // Pick a random number
            _number = _random.Next(_minNumber, _maxNumber);

            // Generate / Translate number to words
            _words = (_hiragana) ? Numbers.GetHiraganaNumber(_number, _numberSettings) : 
                                   Numbers.GetRomanNumber(_number, _numberSettings);

            // Type words/number
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
            // Let the player choose settings
            _state = (AppState)((int)AppState.NotStarted + 1);

            // Type the info for the first setting
            Control.WriteLine("Choose \"Game Mode\" ([N]umbers to words /or/ [W]ords to numbers):");
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
            // Get input as lower (for checking)
            string input = e.Input.ToLower();
            char first = ' ';

            int parsedInput = 0;
            bool parsed = false;

            if (input.Length >= 1) // First char
                first = input[0];

            parsed = int.TryParse(input, out parsedInput); // TryParse input

            // Handle input according to the current state
            switch (_state)
            {
                default:
                    break;

                case AppState.SetGameMode: // Game Mode
                    // Check if the input is valid
                    if (first == 'w' || first == 'n') // [W]ords or [N]umbers
                    {
                        // Set Game Mode
                        _numbersToWords = (first == 'n');

                        // Type input
                        Control.WriteLine(e.Input);

                        // Go to the next setting
                        Control.WriteLine("Choose Alphabet ([R]omans /or/ [H]iragana):");
                        _state = (AppState)((int)_state + 1);
                    }
                    break;
                case AppState.SetAlphabet: // Language
                    // Check if the input is valid
                    if (first == 'r' || first == 'h') // [R]omans or [H]iragana
                    {
                        // Set Game Mode
                        _hiragana = (first == 'h');

                        // Type input
                        Control.WriteLine(e.Input);

                        // Go to the next setting
                        Control.WriteLine(string.Format("Set the Minimum Number Value ({0} -> {1}):",
                                                        Numbers.MinNumberValue, Numbers.MaxNumberValue - 1));
                        _state = (AppState)((int)_state + 1);
                    }
                    break;
                case AppState.SetMinNumber: // Min-Number
                    // Check if input was parsed
                    if (parsed)
                    {
                        // Do not accept the maximum value or higher (since max number has to be larger)
                        if (parsedInput >= Numbers.MaxNumberValue)
                            break;

                        // Do not accept values below the minimum
                        if (parsedInput < Numbers.MinNumberValue)
                            break;

                        // Set setting
                        _minNumber = parsedInput;

                        // Type input
                        Control.WriteLine(e.Input);

                        // Go to the next setting
                        Control.WriteLine(string.Format("Set the Maximum Number Value ({0} -> {1}):",
                                                        _minNumber, Numbers.MaxNumberValue));
                        _state = (AppState)((int)_state + 1);
                    }
                    break;
                case AppState.SetMaxNumber: // Max-Number
                    // Check if input was parsed
                    if (parsed)
                    {
                        // Do not accept values larger than the maximum
                        if (parsedInput > Numbers.MaxNumberValue)
                            break;

                        // Do not accept values below the minimum
                        if (parsedInput < _minNumber)
                            break;

                        // Set setting
                        _maxNumber = parsedInput;

                        // Type input
                        Control.WriteLine(e.Input);

                        // Start the game (since there are no more settings to be set)
                        _state = AppState.InGame;
                        CreateNewQuestion();
                    }
                    break;

                case AppState.InGame: // In game
                    if (_numbersToWords) // Check answer (using different methods depending on game mode)
                        CorrectAnswerWords(e.Input);
                    else
                        CorrectAnswerNumber(e.Input);
                    break;
            }
        }
    }
}
