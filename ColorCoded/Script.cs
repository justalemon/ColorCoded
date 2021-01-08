using GTA;
using PlayerCompanion;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        [DllImport("JoyShockLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int JslConnectDevices();
        /// <summary>
        /// Gets the Device IDs of the number of the specific controllers.
        /// </summary>
        /// <param name="array">The array to fill.</param>
        /// <param name="count">The number of controllers to fill. This can be fetched with JslConnectDevices.</param>
        /// <returns>The number of controllers found.</returns>
        [DllImport("JoyShockLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern int JslGetConnectedDeviceHandles(int[] array, int count);
        /// <summary>
        /// Disconnects and Disposes all of the controllers.
        /// </summary>
        [DllImport("JoyShockLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern void JslDisconnectAndDisposeAll();
        /// <summary>
        /// Gets the type of the controller.
        /// </summary>
        /// <param name="id">The Device ID of the controller.</param>
        /// <returns>The type of controller for a specific ID.</returns>
        [DllImport("JoyShockLibrary", CallingConvention = CallingConvention.Cdecl)]
        public static extern ControllerType JslGetControllerType(int id);
        /// <summary>
        /// Sets the color of the DualShock 4 or DualSense controller.
        /// </summary>
        /// <param name="id">The Device ID of the controller.</param>
        /// <param name="color">The color to set.</param>
        [DllImport("JoyShockLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern void JslSetLightColour(int id, int color);

        #endregion

        #region Fields

        /// <summary>
        /// The last number of wanted star that the player had.
        /// </summary>
        private int lastWanted = 0;
        /// <summary>
        /// The last time where the siren color was changed.
        /// </summary>
        private int lastSirenChange = 0;
        /// <summary>
        /// The last color used.
        /// </summary>
        private Color lastUsedColor = Color.Transparent;
        /// <summary>
        /// The last time where the device IDs were updated.
        /// </summary>
        private int lastUpdateTime = 0;
        /// <summary>
        /// The currently known devices.
        /// </summary>
        private readonly List<int> devices = new List<int>();

        #endregion

        #region Constructor

        public ColorCoded()
        {
            UpdateDevices();
            SetColor(Companion.Colors.Current);
            Tick += ColorCoded_Tick;
            Aborted += ColorCoded_Aborted;
        }

        #endregion

        #region Functions

        private void UpdateDevices()
        {
            // Clear the currently known devices
            devices.Clear();

            // Get the number of devices connected
            int count = JslConnectDevices();
            // And then get the Device IDs
            int[] deviceIds = new int[count];
            JslGetConnectedDeviceHandles(deviceIds, count);

            // Now, time to separate the DualShock 4 and DualSense controllers from the rest
            foreach (int id in deviceIds)
            {
                switch (JslGetControllerType(id))
                {
                    case ControllerType.DualShock4:
                    case ControllerType.DualSense:
                        devices.Add(id);
                        break;
                }
            }

            // Done!
            lastUpdateTime = Game.GameTime;
        }
        private void SetColor(Color color)
        {
            if (lastUsedColor == color)
            {
                return;
            }

            lastUsedColor = color;

            foreach (int id in devices)
            {
                JslSetLightColour(id, color.ToArgb());
            }
        }

        #endregion

        #region Events

        private void ColorCoded_Tick(object sender, EventArgs e)
        {
            // If the device is
            if (Game.GameTime > lastUpdateTime + 1000)
            {
                //UpdateDevices();
            }

            // If the player stars had changed, set the correct color
            int wanted = Game.Player.WantedLevel;
            if (wanted != lastWanted)
            {
                lastWanted = wanted;

                if (wanted == 0)
                {
                    SetColor(Companion.Colors.Current);
                }
                else
                {
                    SetColor(Color.Blue);
                    lastSirenChange = Game.GameTime;
                }
            }

            // Then, change the color for when the player is wanted
            if (wanted > 0 && Game.GameTime > lastSirenChange + 500)
            {
                if (lastUsedColor == Color.Blue)
                {
                    SetColor(Color.Red);
                }
                else
                {
                    SetColor(Color.Blue);
                }
                lastSirenChange = Game.GameTime;
            }
        }
        private void ColorCoded_Aborted(object sender, EventArgs e) => JslDisconnectAndDisposeAll();

        #endregion
    }
}
