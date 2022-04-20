using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Events
{
    public static partial class B1ApplicationEventHandler
    {
        private static void B1MenuEventHandlerAction(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            if(pVal.BeforeAction && pVal.MenuUID == B1ApplicationMenu.B1_ADDON_MENU)
            {
                SAPbouiCOM.Form form = FormFactory.CreateForm();
                form.Visible = true;

                B1Application.ReleaseComObject(form);
            }
        }
    }
}
