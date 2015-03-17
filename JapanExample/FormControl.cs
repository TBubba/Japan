using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JapanExample.Events;
using System.Collections.ObjectModel;

namespace JapanExample
{
    internal class FormControl
    {
        // Application
        private List<IControlApplication> _applications;

        internal ReadOnlyCollection<IControlApplication> Applications;

        // Events
        internal event EventHandler<InputEventArgs> OnInput;
        internal event EventHandler<OutputEventArgs> OnOutput;
        internal event EventHandler<ClearEventArgs> OnClear;

        // Constructor(s)
        internal FormControl()
        {
            // Create list for keeping track of applied applications
            _applications = new List<IControlApplication>();

            // Create readonly wrapper for list
            Applications = new ReadOnlyCollection<IControlApplication>(_applications);
        }

        // Applications
        internal void ApplyApplication(IControlApplication app)
        {
            // Do not allow multi-applying
            if (_applications.Contains(app))
                throw new Exception("Applying the same application multiple times (without removing it) is not allowed");

            // Add application to list
            _applications.Add(app);

            // Tell application it is applied
            app.Apply(this);

            // Apply event methods to events
            OnInput += app.OnInput;
            OnOutput += app.OnOutput;
            OnClear += app.OnClear;
        }
        internal bool RemoveApplication(IControlApplication app)
        {
            // Return false if the application is not previously applied
            if (!_applications.Contains(app))
                return false;

            // Remove application from list
            _applications.Remove(app);

            // Tell application it is removed
            app.Remove(this);

            // Remove event methods from events
            OnInput -= app.OnInput;
            OnOutput -= app.OnOutput;
            OnClear -= app.OnClear;

            // Success
            return true;
        }

        // Input
        internal void Input(string input)
        {
            if (OnInput != null)
                OnInput(this, new InputEventArgs(input));
        }

        // Write
        internal void Write(string text)
        {
            if (OnOutput != null)
                OnOutput(this, new OutputEventArgs(text));
        }
        internal void WriteLine(string text)
        {
            if (OnOutput != null)
                OnOutput(this, new OutputEventArgs(text + "\n"));
        }

        // Clear
        internal void Clear()
        {
            if (OnClear != null)
                OnClear(this, new ClearEventArgs());
        }
    }
}
