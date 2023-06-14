namespace Lesson6
{
    public partial class Form1: Form
    {
        private SaveFileDialog sf;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            sf = new SaveFileDialog();
            sf.Filter = "png files|*.png| jpg files|*.jpg";
        }

        private void DrawRoadSign(PaintEventArgs e)
        {
            int wh = 150;
            int x = 362 / 2 - (wh / 2);
            int y = 273 / 2 - (wh / 2);

            Graphics holst = e.Graphics;
            Pen p = new Pen(Brushes.Black, 1);
            holst.DrawEllipse(p, new Rectangle(new Point(x, y), new Size(wh, wh)));
            holst.FillEllipse(Brushes.Red, new Rectangle(new Point(x + 3, y + 3), new Size(wh - 6, wh - 6)));
            holst.FillRectangle(Brushes.White, new Rectangle(new Point(x + 22, y + 63), new Size(104, 25)));
        }

        private void DrawDonatello(Graphics holst)
        {
            // фон
            holst.FillRectangle(Brushes.Olive, new Rectangle(0, 0, Size.Width, Size.Height));

            // тело
            holst.FillEllipse(Brushes.DarkSeaGreen, new Rectangle(new Point(203, 90), new Size(165, 225)));
            holst.FillEllipse(Brushes.LawnGreen, new Rectangle(new Point(210, 97), new Size(150, 210)));

            // голова
            holst.FillEllipse(Brushes.LawnGreen, new Rectangle(new Point(250, 38), new Size(68, 50)));
            holst.FillEllipse(Brushes.LawnGreen, new Rectangle(new Point(238, 52), new Size(90, 70)));
            holst.FillRectangle(Brushes.DarkViolet, new Rectangle(new Point(250, 45), new Size(68, 18)));

            // лапы
            holst.FillEllipse(Brushes.LawnGreen, new Rectangle(new Point(175, 165), new Size(40, 40)));
            holst.FillEllipse(Brushes.LawnGreen, new Rectangle(new Point(355, 165), new Size(40, 40)));

            // живот
            holst.FillRectangle(Brushes.Yellow, new Rectangle(new Point(245, 126), new Size(82, 115)));
            holst.FillEllipse(Brushes.Yellow, new Rectangle(new Point(244, 210), new Size(83, 75)));

            // ноги
            holst.FillRectangle(Brushes.LawnGreen, new Rectangle(new Point(241, 288), new Size(22, 65)));
            holst.FillRectangle(Brushes.LawnGreen, new Rectangle(new Point(308, 288), new Size(22, 65)));
            holst.FillRectangle(Brushes.DarkViolet, new Rectangle(new Point(241, 330), new Size(22, 15)));
            holst.FillRectangle(Brushes.DarkViolet, new Rectangle(new Point(308, 330), new Size(22, 15)));

            // посох
            holst.FillRectangle(Brushes.DarkKhaki, new Rectangle(new Point(380, 50), new Size(20, 110)));
            holst.FillRectangle(Brushes.LightGray, new Rectangle(new Point(380, 160), new Size(20, 80)));
            holst.FillRectangle(Brushes.DarkKhaki, new Rectangle(new Point(380, 240), new Size(20, 110)));
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            DrawDonatello(e.Graphics);
        }

        private bool SaveImage(string path)
        {
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height);
            try
            {
                using (Graphics holst = Graphics.FromImage(bitmap))
                {
                    holst.FillRectangle(Brushes.Olive, new Rectangle(0, 0, Size.Width, Size.Height));
                    DrawDonatello(holst);
                }
                bitmap.Save(path);
                bitmap.Dispose();
            }
            catch (Exception) { return false; }

            return true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (SaveImage(sf.FileName))
                {
                    MessageBox.Show("Картинка успешно сохранена!", "Сохранено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Картинка не сохранена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}