using SharpShell.Attributes;
using SharpShell.SharpIconHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace RegisterFileIcon
{
    /// <summary>
    /// The DllIconHandler is a Shell Icon Handler exception that
    /// shows different icons for native and managed dlls.
    /// </summary>
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.ClassOfExtension, ".lqj")]
    public class RegisterFileIcon : SharpIconHandler
    {
        static Icon Icon_Blank = Properties.Resources.Icon1;
        static Icon Icon_Little = Properties.Resources.Icon2;
        static Icon Icon_Much = Properties.Resources.Icon3;

        /// <summary>
        /// Gets the icon
        /// </summary>
        /// <param name="smallIcon">if set to <c>true</c> provide a small icon.</param>
        /// <param name="iconSize">Size of the icon</param>
        /// <returns>
        /// The icon for the file
        /// </returns>
        protected override Icon GetIcon(bool smallIcon, uint iconSize)
        {
            //  The icon we'll return
            Icon icon = null;

            try
            {
                FileInfo fi = new FileInfo(SelectedItemPath);
                if (fi.Length == 0)
                    icon = Icon_Blank;
                else if (fi.Length < 4096)
                    icon = Icon_Little;
                else
                    icon = Icon_Much;
            }
            catch (Exception)
            {
                icon = Icon_Blank;
            }


            //  Return the icon with the correct size. 
            //  Use the SharpIconHandler 'GetIconSpecificSize'
            //  function to extract the icon of the required size.
            return GetIconSpecificSize(icon, new Size((int)iconSize, (int)iconSize));
        }
    }
}
