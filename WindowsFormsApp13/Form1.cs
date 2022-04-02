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
using System.Drawing.Drawing2D;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp13
{





    public partial class Form1 : Telerik.WinControls.UI.RadForm
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool HideCaret(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public Form1()
        {
            InitializeComponent();
            /// (new 切換新舊IME輸入法.DropShadow()).ApplyShadows(this);

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();


        }




        private void Form1_Load(object sender, EventArgs e)
        {

            //  this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, -this.Height);

            // this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 0);


            //        this.Location = new Point(0, (Screen.PrimaryScreen.Bounds.Height/ 2));



            this.Location = new Point(切換新舊IME輸入法.Properties.Settings.Default.FXX, 切換新舊IME輸入法.Properties.Settings.Default.FYY);




        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Input\TSF\Tsf3Override\{B115690A-EA02-48D5-A231-E3578D2FDF80}");

            //storing the values  
            key.SetValue("NoTsf3Override4", "0", RegistryValueKind.DWord);
            key.Close();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\LINE\\bin\\LineLauncher.exe";


            //  Process.Start(path);
            MessageBox.Show("已切換為新版輸入法", "訊息視窗", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Input\TSF\Tsf3Override\{B115690A-EA02-48D5-A231-E3578D2FDF80}");

            //storing the values  
            key.SetValue("NoTsf3Override4", "1", RegistryValueKind.DWord);
            key.Close();
            var path = Path.GetPathRoot(Environment.SystemDirectory) + "\\TWEWinner\\EWinnerStart.exe";

            //Process.Start(path);
            MessageBox.Show("已切換為舊版輸入法", "訊息視窗", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {





        }

        private void Form1_Activated(object sender, EventArgs e)
        {



            timer1.Start();



        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            /*
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                int posX = Cursor.Position.X;

                int posY = Cursor.Position.Y;
                MessageBox.Show(posX.ToString());
                MessageBox.Show(posY.ToString());

            }
            */






        }

        protected override CreateParams CreateParams
        {
            get
            {
                //const int WS_EX_APPWINDOW = 0x40000;
                //  const int WS_EX_TOOLWINDOW = 0x80;
                //const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                // cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不顯示在TaskBar
                //cp.ExStyle |= WS_EX_TOOLWINDOW;      //不顯示在Alt+Tab
                cp.ExStyle |= 0x02000000;// 雙緩衝
                                         // cp.ClassStyle |= CS_DROPSHADOW;// 陰影
                                         // const int CS_NOCLOSE = 0x200;

                // cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void DoSomething()
        {


            if (this.Location.X > Screen.PrimaryScreen.WorkingArea.X + Screen.PrimaryScreen.WorkingArea.Width - this.Width)
            {

                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;





            }
            else if (this.Location.X < Screen.PrimaryScreen.WorkingArea.X)
            {


                this.Left = 0;





            }
            if (this.Location.Y > Screen.PrimaryScreen.WorkingArea.Y + Screen.PrimaryScreen.WorkingArea.Height - this.Height)
            {
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;



            }
            else if (this.Location.Y < Screen.PrimaryScreen.WorkingArea.Y)
            {


                this.Top = 0;



            }

        }


        private void timer1_Tick(object sender, EventArgs e)
        {/*
            if (ClientRectangle.Contains(PointToClient(Control.MousePosition)))
            {
               

            }
            else
            {

                
                this.Cursor = new Cursor(Cursor.Current.Handle);
                int posX = Cursor.Position.X;
                int posY = Cursor.Position.Y;

          
                if (  (posX>795 && posX<1120) && posY==0)
                {

                        this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 0);
                    
                }
                else
                {
                    this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, -this.Height);
                }

           
            } 
            
          */
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            切換新舊IME輸入法.Properties.Settings.Default.FXX = Location.X;
            切換新舊IME輸入法.Properties.Settings.Default.FYY = Location.Y;
            切換新舊IME輸入法.Properties.Settings.Default.Save();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {




        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {


        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        [DllImport("user32", CharSet = CharSet.Auto)]
        public static extern int EnableWindow(IntPtr hwnd, bool bEnable);
        private void Form1_Move(object sender, EventArgs e)
        {




        }




        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            DoSomething();
        }


    }

}
