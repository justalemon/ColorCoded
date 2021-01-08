using GTA;
using System;
using System.Runtime.InteropServices;

namespace ColorCoded
{
    /// <summary>
    /// The controller types returned by JslGetControllerType.
    /// </summary>
    public enum ControllerType
    {
        JoyConLeft = 1,
        JoyConRight = 2,
        SwitchPro = 3,
        DualShock4 = 4,
        DualSense = 5,  // not part of the docs, but present on the source code
    }

    /// <summary>
    /// Script that handle the DualShock 4 and DualSense color.
    /// </summary>
    public class ColorCoded : Script
    {
        #region API

        /// <summary>
        /// Gets the number of connnected devices.
        /// </summary>
        /// <returns>The number of connected devices.</returns>
        [DllImport("JoyShockLibrary")]
        private static extern int JslConnectDevices();
        /// <summary>
        /// Gets the Device IDs of the number of the specific controllers.
        /// </summary>
        /// <param name="array">The array to fill.</param>
        /// <param name="count">The number of controllers to fill. This can be fetched with JslConnectDevices.</param>
        /// <returns>The number of controllers found.</returns>
        [DllImport("JoyShockLibrary")]
        private static extern int JslGetConnectedDeviceHandles(int[] array, int count);
        /// <summary>
        /// Disconnects and Disposes all of the controllers.
        /// </summary>
        [DllImport("JoyShockLibrary")]
        private static extern void JslDisconnectAndDisposeAll();
        /// <summary>
        /// Gets the type of the controller.
        /// </summary>
        /// <param name="id">The Device ID of the controller.</param>
        /// <returns>The type of controller for a specific ID.</returns>
        [DllImport("JoyShockLibrary")]
        public static extern ControllerType JslGetControllerType(int id);
        /// <summary>
        /// Sets the color of the DualShock 4 or DualSense controller.
        /// </summary>
        /// <param name="id">The Device ID of the controller.</param>
        /// <param name="color">The color to set.</param>
        [DllImport("JoyShockLibrary")]
        private static extern void JslSetLightColour(int id, int color);

        #endregion

        #region Constructor

        public ColorCoded()
        {
            Tick += ColorCoded_Tick;
            Aborted += ColorCoded_Aborted;
        }

        #endregion

        #region Functions

        #endregion

        #region Events

        private void ColorCoded_Tick(object sender, EventArgs e)
        {
        }
        private void ColorCoded_Aborted(object sender, EventArgs e) => JslDisconnectAndDisposeAll();

        #endregion
    }
}
