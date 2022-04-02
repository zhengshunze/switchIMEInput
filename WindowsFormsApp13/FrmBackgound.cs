using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
    class FrmBackgound
    {
        public static void Show(Form frmTop, Form frmBackOwner, Color frmBackColor, double frmBackOpacity)
        {
            // 背景窗體設置
            var frmBack = new Form();
            frmBack.FormBorderStyle = FormBorderStyle.None;
            frmBack.StartPosition = FormStartPosition.Manual;
            frmBack.ShowIcon = false;
            frmBack.ShowInTaskbar = false;
            frmBack.Opacity = frmBackOpacity;
            frmBack.BackColor = frmBackColor;
            frmBack.Owner = frmBackOwner;
            frmBack.Size = frmTop.Size;
            frmBack.Location = frmTop.Location;
            // 頂部窗體設置
            frmTop.Owner = frmBack;
            frmTop.StartPosition = FormStartPosition.Manual;
            frmTop.LocationChanged += (o, args) => { frmBack.Location = frmTop.Location; };
            // 顯示窗體
            frmTop.Show();
            frmBack.Show();
        }
    }

}
