using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JapanExample.Events
{
    internal class OutputEventArgs : EventArgs
    {
        public string Output;
        
        // Constructor(s)
        public OutputEventArgs()
        {
        }
        public OutputEventArgs(string output)
        {
            Output = output;
        }
    }
}
