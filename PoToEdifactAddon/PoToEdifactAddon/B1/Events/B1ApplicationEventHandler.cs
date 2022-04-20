using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon.Events
{
    public static partial class B1ApplicationEventHandler
    {
        public static void InitializeB1Events()
        {
            SAPbouiCOM.Application b1App = B1Application.GetSboApplication();

            b1App.AppEvent += B1AppEventHandlerAction;
            b1App.MenuEvent += B1MenuEventHandlerAction;
            b1App.ItemEvent += B1ItemEventHandlerAction;
        }
    }
}
