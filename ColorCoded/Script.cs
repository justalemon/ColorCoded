using GTA;
using System;

namespace ColorCoded
{
    /// <summary>
    /// Script that handle the DualShock 4 and DualSense color.
    /// </summary>
    public class ColorCoded : Script
    {
        #region Constructor

        public ColorCoded()
        {
            Tick += ColorCoded_Tick;
        }

        #endregion

        #region Functions

        #endregion

        #region Events

        private void ColorCoded_Tick(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
