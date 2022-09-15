using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Rekurze
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Paint += MainForm_Paint;
        }

        // purely visual thingy stolen from stack overflow
        #region Dark Window Border
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        private static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, (int)attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UseImmersiveDarkMode(this.Handle, true);
        }
        #endregion

        Pen spiralPen = new Pen(Color.FromArgb(0x1F, 0xB3, 0x11), 1f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        // parameters
        int len = 500;
        int space = 20;

        // event hadler for the window paint event
        // also the form is to double buffering to prevent flickering
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawSpiral(e.Graphics, spiralPen, new PointF(10, 150), len, space, Direction.Right);
        }

        // enumeration used with default numbering to make use of modulo
        public enum Direction
        {
            Right,
            Down,
            Left,
            Up,
        }

        // 'len' and 'spacing' parameters are the two that change the shape
        public static void DrawSpiral(Graphics g, Pen pen, PointF point, float len, float spacing, Direction direction = Direction.Right)
        {
            // exit case
            if (len <= 0)
                return;

            PointF tmp;
            // calculation of the next point based on the given direction
            switch (direction)
            {
                case Direction.Right: tmp = new PointF(point.X + len, point.Y); break;
                case Direction.Down: tmp = new PointF(point.X, point.Y + len); break;
                case Direction.Left: tmp = new PointF(point.X - len, point.Y); break;
                case Direction.Up: tmp = new PointF(point.X, point.Y - len); break;
                default: throw new Exception("wtf?"); // just to be sure
            }

            // draw the current line segment
            g.DrawLine(pen, point, tmp);

            // pass the parameters to the next iteration of the recursion
            DrawSpiral(g, pen, tmp, len - spacing / 2, spacing, (Direction)(((int)direction + 1) % 4));
        }

        private void LenUpDown_ValueChanged(object sender, EventArgs e)
        {
            LenTrackBar.Value = len = (int)((NumericUpDown)sender).Value;
            this.Invalidate();
        }

        private void SpaceUpDown_ValueChanged(object sender, EventArgs e)
        {
            SpaceTrackBar.Value = space = (int)((NumericUpDown)sender).Value;
            this.Invalidate();
        }

        private void LenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            LenUpDown.Value = len = ((TrackBar)sender).Value;
            this.Invalidate();
        }

        private void SpaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SpaceUpDown.Value = space = ((TrackBar)sender).Value;
            this.Invalidate();
        }
    }
}
