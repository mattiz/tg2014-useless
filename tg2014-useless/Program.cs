using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Media;


namespace TG20014Useless {
    public class SysTrayApp : Form {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private KeyListener keyListener;


        [STAThread]
        public static void Main() {
            Application.Run(new SysTrayApp());
        }


        public SysTrayApp() {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("About", OnAbout);
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Typewriter Simulator";
            trayIcon.Icon = TG20014Useless.Properties.Resources.star_black;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            keyListener = new KeyListener();
        }


        protected override void OnLoad(EventArgs e) {
            Visible = false;
            ShowInTaskbar = false;

            base.OnLoad(e);
        }


        private void OnAbout(object sender, EventArgs e) {
            MessageBox.Show("Typewriter Simulator - TG 2014 Useless contribution by #MooG");
        }


        private void OnExit(object sender, EventArgs e) {
            keyListener.dispose();
            Application.Exit();
        }


        protected override void Dispose(bool isDisposing) {
            if (isDisposing) {
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}