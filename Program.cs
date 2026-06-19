using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PremiumLivingSystem
{
    internal static class Program
    {
        public static string ConnectionString
        {
            get
            {
                var connStr = System.Configuration.ConfigurationManager
                    .ConnectionStrings["PLFCDB"]?.ConnectionString;
                if (string.IsNullOrEmpty(connStr))
                    connStr = "server=localhost;user id=root;password=;database=plfcdb";
                return connStr;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Global handler: catch WinForms UI-thread exceptions and prevent app termination.
            // This keeps the app alive so the user stays on the login screen instead of crashing out.
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show(
                    "An unexpected error occurred:" + e.Exception.Message,
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                // NOTE: The application will NOT terminate because this handler
                // prevents the default unhandled-exception behaviour for WinForms.
            };

            // AppDomain.UnhandledException fires when a non-UI thread throws.
            // In .NET Framework this event CANNOT stop termination, but it gives
            // us a chance to log or show the error before the process exits.
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                string msg = ex != null
                    ? "A critical error occurred. The application will now close." + ex.Message
                    : "A critical error occurred. The application will now close.";
                MessageBox.Show(msg, "Critical Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            Application.Run(new LoginForm());
        }
    }
}
