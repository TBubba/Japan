using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JapanExample.Events;
using JapanExample.Applications;

namespace JapanExample
{
    public partial class MainForm : Form
    {
        // Control
        FormControl _control;

        // Constructor(s)
        public MainForm()
        {
            // Initialize Components (WinForms)
            InitializeComponent();

            // Create Control
            _control = new FormControl();

            // Apply (Control) Event Methods
            _control.OnOutput += OnOutput;
            _control.OnClear += OnClear;
        }

        // (Control) Event Methods
        private void OnOutput(object sender, OutputEventArgs e)
        {
            // Append output
            _rtbOutput.AppendText(e.Output);
            
            // Scroll
            _rtbOutput.ScrollToCaret();
        }
        private void OnClear(object sender, EventArgs e)
        {
            // Clear
            _rtbOutput.Text = "";
        }

        // Events
        private void _rtbInput_KeyDown(object sender, KeyEventArgs e)
        {
            // if the "Enter"-key is pressed
            if (e.KeyCode == Keys.Enter) // && !e.Shift)
            {
                // Copy and clear the input-textfield
                string input = _rtbInput.Text;
                _rtbInput.Clear();

                // Send input to control
                _control.Input(input);

                // Suppress key (enter) to avoid adding a line to the input-textfield
                e.SuppressKeyPress = true;
            }
        }

        private void guessTheNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create and set up game
            GuessTheNumberApp app = new GuessTheNumberApp(true);
            
            // Apply app to control
            _control.ApplyApplication(app);

            // Start app
            app.StartGame();
        }
    }
}
