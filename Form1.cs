using CSharp.lab5.Objects;

namespace CSharp.lab5
{
    public partial class Form1 : Form
    {
        MyRectangle myRect; // Прямоугольник
        public Form1()
        {
            InitializeComponent();
            myRect = new MyRectangle(100, 100, 45);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            g.Transform = myRect.GetTransform();

            myRect.Render(g); // теперь так рисуем
        }
    }
}
