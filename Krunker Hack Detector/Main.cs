using Krunker_Hack_Detector.Assets.Others;
using System;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Krunker_Hack_Detector
{
    public partial class Main : Form
    {
        //Main
        #region Main
        public Main()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.TopMost = true;
            WinAPI.SetWindowDisplayAffinity(this.Handle, 0x11);
            this.ShowInTaskbar = false;
        }
        #endregion

        //DeplacementWindows
        //Rainbow_Tick
        //EditLbl
        //Main_Load
        #region GUI
        private void DeplacementWindows(object sender, MouseEventArgs e)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Rainbow_Tick(object sender, EventArgs e)
        {
            Random Rand = new Random();
            int A = Rand.Next(0, 255);
            int R = Rand.Next(0, 255);
            int G = Rand.Next(0, 255);
            int B = Rand.Next(0, 255);
            Lblhackers.ForeColor = Color.FromArgb(A, R, G, B);
        }

        public void EditLbl(string Text)
        {
            Lblhackers.Text = "Hackers: " + Text;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, \r\nand welcome to this software.\r\nThe purpose of this software is to deposit an overlay on your screen in order to display in real time the number of cheaters on the video game Krunker.IO\r\nAttention however, this software takes into account only one cheat. \r\nPowered by D4rk.shop", "Krunker.IO Cheat Detector - Powered by D4rk.shop", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateTime();
        }
        #endregion

        //UpdateTime
        #region Socket
        async void UpdateTime()
        {
            var sockets = new ClientWebSocket();
            await sockets.ConnectAsync(new Uri("wss://supercounter.tk"), CancellationToken.None);

            while (true)
            {
                // Set up a buffer to receive the data.
                var buffer = new ArraySegment<byte>(new byte[1024]);

                // Receive data from the WebSocket.
                var result = await sockets.ReceiveAsync(buffer, CancellationToken.None);

                // Print the received data to the console.
                EditLbl(Encoding.UTF8.GetString(buffer.Array, 0, result.Count));
            }
        }
        #endregion
    }
}
