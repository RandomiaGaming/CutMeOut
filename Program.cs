using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutMeOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Preview preview = new Preview();
            Application.Run(preview);
        }
    }
    public sealed class Preview : Form
    {
        private PictureBox opacityIndicator;
        public Preview()
        {
            opacityIndicator = new PictureBox();
            opacityIndicator.Location = new Point(0, 0);
            opacityIndicator.Size = ClientSize;
            opacityIndicator.BackgroundImage = new Bitmap("C:\\Users\\RandomiaGaming\\Desktop\\OpacityIndicator.png");
            opacityIndicator.BackgroundImageLayout = ImageLayout.Tile;
            Controls.Add(opacityIndicator);

            Resize += OnResize;
        }
        private void OnResize(object sender, EventArgs e)
        {
            opacityIndicator.Location = new Point(0, 0);
            opacityIndicator.Size = ClientSize;
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            BackColor = ComputeAnimation();
            base.OnPaintBackground(e);
            Invalidate();
        }
        private Stopwatch animTimer = Stopwatch.StartNew();
        private const long animInterval = 10000000;
        private Color ComputeAnimation()
        {
            double animPercentage = ComputeAnimPercentage();

            throw new Exception("Um what the actual fuck!");
        }
        private Color Gradient(double value, params Color[] colors)
        {

        }
        private Color Gradient(double value, Color start, Color end)
        {
            double r = Scale(start.R, end.R, value);
            double g = Scale(start.G, end.G, value);
            double b = Scale(start.B, end.B, value);
            double a = Scale(start.A, end.A, value);
            byte rByte = (byte)r;
            byte gByte = (byte)g;
            byte bByte = (byte)b;
            byte aByte = (byte)a;
            return Color.FromArgb(aByte, rByte, gByte, bByte);
        }
        private double Scale(double start, double end, double value)
        {
            double range = end - start;
            value *= range;
            return start + value;
        }
        private double UnScale(double start, double end, double value)
        {
            double range = end - start;
            value -= start;
            return value / range;
        }
    }
}
