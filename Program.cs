using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Squirrel;

namespace IssueCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Issue issue = new Issue();

            SquirrelAwareApp.HandleEvents(onAppUpdate: issue.OnAppUpdate,
                        onAppUninstall: issue.OnAppUninstall,
                        onInitialInstall: issue.OnInitialInstall,
                        onFirstRun: issue.OnFirstRun);

            Application.Run(issue);
        }

    }
}
