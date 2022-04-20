using PoToEdifactAddon.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoToEdifactAddon
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {

            try
            {
                B1Application.ConnectToUi();
                B1Application.ConnectoToDi();
                B1ApplicationMenu.InitializeB1Menus();
                B1ApplicationEventHandler.InitializeB1Events();

                Application.Run();

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error on initialization: {0}", ex.Message));
            }
            finally
            {
                B1ApplicationMenu.RemoveAddonMenu();
                B1Application.Dispose();
            }
        }
    }
}
