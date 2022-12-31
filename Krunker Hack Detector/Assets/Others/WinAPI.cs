using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Krunker_Hack_Detector.Assets.Others
{
    internal class WinAPI
    {
        //SetWindowDisplayAffinity
        //SendMessage
        //ReleaseCapture
        #region DLLimport
        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        #endregion
    }
}
