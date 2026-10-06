using System;
using System.Windows.Forms;

namespace KisiGrup
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new KisiForm("Data Source=.;Initial Catalog=master;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"));
        }
    }
}
