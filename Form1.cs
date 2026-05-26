using CSharp.lab5.Objects;

namespace CSharp.lab5
{
    public partial class Form1 : Form
    {
        MyRectangle myRect; // Прямоугольник
        List<BaseObject> objects = new(); 

        public Form1()
        {
            InitializeComponent();

            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));
            //myRect = new MyRectangle(100, 100, 45);
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }
            
            //g.Transform = myRect.GetTransform();
            //myRect.Render(g); // теперь так рисуем
        }
    }
}
