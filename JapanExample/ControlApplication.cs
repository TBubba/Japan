using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JapanExample.Events;

namespace JapanExample
{
    internal class ControlApplication : IControlApplication
    {
        // Control
        private FormControl _control;

        internal FormControl Control
        { get { return _control; } }

        // Constructor(s)
        internal ControlApplication()
        {

        }

        // Control-related
        public void Apply(FormControl control)
        {
            // Keep control (since the application might want to use it)
            _control = control;
            
            // Call "event"
            OnApplied(control);
        }
        public void Remove(FormControl control)
        {
            // Remove control (since it will not be needed any more)
            _control = null;

            // Call "event"
            OnRemoved(control);
        }

        // Event Methods
        public virtual void OnInput(object sender, InputEventArgs e)
        {
        }
        public virtual void OnOutput(object sender, OutputEventArgs e)
        {
        }
        public virtual void OnClear(object sender, ClearEventArgs e)
        {
        }

        // "Event" Methods
        protected virtual void OnApplied(FormControl control)
        {
        }
        protected virtual void OnRemoved(FormControl control)
        {
        }
    }
}
