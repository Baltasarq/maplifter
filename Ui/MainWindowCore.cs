using System;
using System.Windows.Forms;

namespace MapLifter.Ui {
    public partial class MainWindow {
        public MainWindow()
        {
            this.Build();
        }

        private void DoQuit()
        {
            this.Hide();
            Application.Exit();
        }

        private void DoNew()
        {
            
        }

        private void DoOpen()
        {
            
        }

        private void DoSave()
        {
            
        }

        private void DoImport()
        {
            
        }

        private void DoExport()
        {
            
        }

        private void DoSettings()
        {
            
        }

        private void DoHelp()
        {
            
        }

        private void DoAbout()
        {
            
        }
        
        private void SetStatus()
        {
            this.lblStatus.Text = "Ready";
        }

        private void SetStatus(string msg)
        {
            this.lblStatus.Text = msg;
        }

        public int CharWidth {
            get { return 16; }
        }
    }
}
