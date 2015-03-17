using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JapanExample.Events;

namespace JapanExample
{
    internal interface IControlApplication
    {
        // Apply/Remove
        void Apply(FormControl control);
        void Remove(FormControl control);

        // Event Methods
        void OnInput(object sender, InputEventArgs e);
        void OnOutput(object sender, OutputEventArgs e);
        void OnClear(object sender, ClearEventArgs e);
    }
}
