using System.Windows.Forms;
using MapLifter.Ui;

namespace MapLifter {
    public class Boot {
        public static void Main()
        {
            var mainWindow = new MainWindow();
            
            mainWindow.Show();
            Application.Run();
        }
    }
}
