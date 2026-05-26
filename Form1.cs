using CSharp.lab5.Objects;

namespace CSharp.lab5
{
    public partial class Form1 : Form
    {
        //MyRectangle myRect; // Прямоугольник
        List<BaseObject> objects = new();
        Player player;
        Marker marker;

        public Form1()
        {
            InitializeComponent();
            //objects.Add(new MyRectangle(50, 50, 0));

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);
            objects.Add(player);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            // расчитывает вектор между игроком и маркером
            float dx = marker.X - player.X; 
            float dy = marker.Y - player.Y;
        }
    }
}
