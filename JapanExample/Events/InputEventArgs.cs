using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JapanExample.Events
{
    internal class InputEventArgs : EventArgs
    {
        // Data
        public string Input;

        // Constructor(s)
        public InputEventArgs()
        {
        }
        public InputEventArgs(string input)
        {
            Input = input;
        }
    }
}
