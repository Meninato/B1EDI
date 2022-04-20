using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PoToEdifactAddon
{
    public static class B1Application
    {
        private static SAPbouiCOM.Application _oApplication;
        private static SAPbobsCOM.Company _oCompany;

        public static void ConnectToUi()
        {
            // Object responsable to estabilish a connection to an active SAP application
            SAPbouiCOM.SboGuiApi sboGui = new SAPbouiCOM.SboGuiApi();

            // Get the connection string from Debug Command Line Args
            sboGui.Connect(System.Convert.ToString(Environment.GetCommandLineArgs().GetValue(1)));

            _oApplication = sboGui.GetApplication();
        }

        public static bool ConnectoToDi()
        {
            int result = 1;

            _oCompany = GetSboApplication().Company.GetDICompany();

            if (_oCompany.Connected == false)
            {
                result = _oCompany.Connect();
            }

            return (result == 0);
        }

        public static SAPbouiCOM.Application GetSboApplication()
        {
            return _oApplication;
        }

        public static SAPbobsCOM.Company GetDiCompany()
        {
            return _oCompany;
        }

        public static void Dispose()
        {
            if(_oApplication != null)
            {
                Marshal.FinalReleaseComObject(_oApplication);
            }
        }

        public static void ReleaseComObject(object o)
        {
            if(o != null)
            {
                Marshal.ReleaseComObject(o);
            }
        }
    }
}
