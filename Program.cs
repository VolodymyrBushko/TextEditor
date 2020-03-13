using System;
using System.Windows.Forms;

namespace VolodWF
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo("en-US");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
