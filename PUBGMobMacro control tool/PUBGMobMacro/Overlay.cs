using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace PUBGMobMacro
{
    public partial class Overlay : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;

        [DllImport("user32.dll")]

        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]

        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public Overlay()
        {
            InitializeComponent();
            lblCrouch.Text = Settings.isCrouch.ToString();
            Subscribe();
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Settings.currentGun == 1)
            {
                lblGun.Text = Settings.guns[Settings.Gun1] + "x" + Settings.Gun1Scope.ToString();
            }
            else if(Settings.currentGun == 2)
            {
                lblGun.Text = Settings.guns[Settings.Gun2] + "x" + Settings.Gun2Scope.ToString();
            }

            if (e.KeyCode == Keys.F1)
            {
                lblisEnabled.Text = "Enabled";
            }
            else if (e.KeyCode == Keys.F2)
            {
                lblisEnabled.Text = "Disabled";
            }
            lblCrouch.Text = Settings.isCrouch.ToString();
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += OnKeyDown;
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Wheat;
            this.TransparencyKey = Color.Wheat;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
        }
    }
}
