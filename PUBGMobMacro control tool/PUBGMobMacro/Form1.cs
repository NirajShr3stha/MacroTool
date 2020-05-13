using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;
using WindowsInput;

namespace PUBGMobMacro
{
    public partial class Form1 : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private static Timer loopTimer;
        public bool isEnabled = false;
        Overlay overlay = new Overlay();
        public static int currentGun = 1;
        public static int guncode;
        public static int recoil;
        public static int minusrecoil1 = 0;
        public static int minusrecoil2 = 0;
        
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Settings.currentGun = currentGun;
            if (e.KeyCode == Keys.F1)
            {
                isEnabled = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                isEnabled = false;
            }

            if (e.KeyCode == Keys.D1)
            {
                currentGun = 1;
                Settings.currentGun = currentGun;
            }
            else if (e.KeyCode == Keys.D2)
            {
                currentGun = 2;
                Settings.currentGun = currentGun;
            }

            if(e.KeyCode == Keys.NumPad0)
            {
                if(currentGun == 1)
                {
                    Settings.Gun1Scope = 0;
                    lblScope1.Text = "x0";
                }
                else if(currentGun == 2)
                {
                    Settings.Gun2Scope = 0;
                    lblScope2.Text = "x0";
                }
            }
            else if (e.KeyCode == Keys.NumPad1)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 1;
                    lblScope1.Text = "x1";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 1;
                    lblScope2.Text = "x1";
                }
            }
            else if (e.KeyCode == Keys.NumPad2)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 2;
                    lblScope1.Text = "x2";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 2;
                    lblScope2.Text = "x2";
                }
            }
            else if (e.KeyCode == Keys.NumPad3)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 3;
                    lblScope1.Text = "x3";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 3;
                    lblScope2.Text = "x3";
                }
            }
            else if (e.KeyCode == Keys.NumPad4)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 4;
                    lblScope1.Text = "x4";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 4;
                    lblScope2.Text = "x4";
                }
            }
            else if (e.KeyCode == Keys.NumPad6)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 6;
                    lblScope1.Text = "x6";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 6;
                    lblScope2.Text = "x6";
                }
            }
            else if (e.KeyCode == Keys.NumPad8)
            {
                if (currentGun == 1)
                {
                    Settings.Gun1Scope = 8;
                    lblScope1.Text = "x8";
                }
                else if (currentGun == 2)
                {
                    Settings.Gun2Scope = 8;
                    lblScope2.Text = "x8";
                }
            }

            if (e.KeyCode == Keys.C)
            {
                Settings.isCrouch = !Settings.isCrouch;
            }
            lblCurrentGun.Text = currentGun.ToString();
        }
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            lblCurrentGun.Text = currentGun.ToString();
            if (currentGun == 1)
            {
                guncode = Settings.Gun1 * 10 + Settings.Gun1Scope;
            }
            else if(currentGun == 2)
            {
                guncode = Settings.Gun2 * 10 + Settings.Gun2Scope;
            }
            
            if (isEnabled == true)
            {
                foreach (KeyValuePair<int, int> recoilvalue in Settings.recoil)
                {
                    if(guncode == recoilvalue.Key)
                    {
                        recoil = recoilvalue.Value;
                        if (currentGun == 1)
                        {
                            if (Settings.isCrouch == false)
                            {
                                if (Settings.Gun1 == 0 || Settings.Gun1 == 3)
                                {
                                    recoil = recoil + 3;
                                }
                                else
                                {
                                    recoil = recoil + 2;
                                }

                            }
                            if (cbxComp1.Checked)
                            {
                                if (Settings.Gun1 == 1 || Settings.Gun1 == 2 || Settings.Gun1 == 3 || Settings.Gun1 == 4 || Settings. Gun1 == 5 || Settings.Gun1 == 6)
                                {
                                    recoil = recoil + minusrecoil1 + 1;
                                }
                                else
                                {
                                    recoil = recoil + minusrecoil1;
                                }
                                
                            }
                        }else if (currentGun == 2)
                        {
                            if (Settings.isCrouch == false)
                            {
                                if (Settings.Gun2 == 0 || Settings.Gun2 == 3)
                                {
                                    recoil = recoil + 3;
                                }
                                else
                                {
                                    recoil = recoil + 2;
                                }

                            }
                            if (cbxComp2.Checked)
                            {
                                if (Settings.Gun2 == 1 || Settings.Gun2 == 2 || Settings.Gun2 == 3 || Settings.Gun2 == 4 || Settings.Gun2 == 5 || Settings.Gun2 == 6)
                                {
                                    recoil = recoil + minusrecoil2 + 1;
                                }
                                else
                                {
                                    recoil = recoil + minusrecoil2;
                                }
                            }
                        }
                        break;
                    }
                }
                foreach (KeyValuePair<int, int> delay in Settings.delay)
                {
                    if (guncode == delay.Key)
                    {
                        loopTimer.Interval = delay.Value;
                        break;
                    }
                }
                loopTimer.Enabled = true;
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            loopTimer.Enabled = false;
        }
        private static void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            InputSimulator s = new InputSimulator();
            s.Mouse.MoveMouseBy(0, recoil);
            //MessageBox.Show(recoil.ToString());
        }

        public void Subscribe()
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.MouseDown += OnMouseDown;
            m_GlobalHook.MouseUp += OnMouseUp;
            m_GlobalHook.KeyDown += OnKeyDown;
        }
        public Form1()
        {
            InitializeComponent();
            overlay.Show();
            Subscribe();
            loopTimer = new Timer();
            loopTimer.Interval = 1000;
            loopTimer.Enabled = false;
            loopTimer.Elapsed += loopTimerEvent;
            loopTimer.AutoReset = true;
        }

        private void comboBoxGun1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings.guns.Length; i++)
            {
                if(Settings.guns[i] == comboBoxGun1.Text)
                {
                    Settings.Gun1 = i;
                    break;
                }
            }
        }

        private void comboBoxGun2_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Settings.guns.Length; i++)
            {
                if (Settings.guns[i] == comboBoxGun2.Text)
                {
                    Settings.Gun2 = i;
                    break;
                }
            }
        }

        private void cbxComp1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxComp1.Checked)
            {
                minusrecoil1 = -2;
            }
            else
            {
                minusrecoil1 = 0;
            }
        }

        private void cbxComp2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxComp2.Checked)
            {
                minusrecoil2 = -2;
            }
            else
            {
                minusrecoil2 = 0;
            }
        }
    }
}
