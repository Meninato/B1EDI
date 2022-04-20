using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoToEdifactAddon
{
    public static class B1ApplicationMenu
    {
        public const string B1_MAIN_MENU = "43520";
        public const string B1_ADDON_MENU = "B1POTOEDI1";

        public static void InitializeB1Menus()
        {
            SAPbouiCOM.Application b1App = B1Application.GetSboApplication();

            RemoveMenusIfAlreadySetup();

            SAPbouiCOM.MenuItem menuItem;
            SAPbouiCOM.Menus menus;
            SAPbouiCOM.MenuCreationParams menuCreationParams;

            menuCreationParams = 
                b1App.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams);

            menuCreationParams.Type = SAPbouiCOM.BoMenuType.mt_STRING ;
            menuCreationParams.UniqueID = B1_ADDON_MENU;
            menuCreationParams.String = "Export purchase orders to EDIFACT";
            menuCreationParams.Position = -1;

            menuItem = b1App.Menus.Item(B1_MAIN_MENU);
            menus = menuItem.SubMenus;

            menus.AddEx(menuCreationParams);

            B1Application.ReleaseComObject(menuItem);
            B1Application.ReleaseComObject(menus);
            B1Application.ReleaseComObject(menuCreationParams);
        }

        private static void RemoveMenusIfAlreadySetup()
        {
            RemoveAddonMenu();
        }

        public static void RemoveAddonMenu()
        {
            if (B1Application.GetSboApplication().Menus.Exists(B1_ADDON_MENU))
            {
                B1Application.GetSboApplication().Menus.RemoveEx(B1_ADDON_MENU);
            }
        }
    }
}
