using System;
using System.Drawing;
using System.Windows.Forms;
 
namespace MyTrayApp
{
    public class SysTrayApp : Form
    {
        [STAThread]
        public static void Main()
        {
            Application.Run(new SysTrayApp());
        }
 
        private NotifyIcon  trayIcon;
        private ContextMenu trayMenu;
 
        public SysTrayApp()
        {
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon      = new NotifyIcon();
            trayIcon.Text = "MyTrayApp";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible     = true;
        }
 
        protected override void OnLoad(EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;
 
            base.OnLoad(e);
        }
 
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
 
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                trayIcon.Dispose();
            }
 
            base.Dispose(isDisposing);
        }
    }
}