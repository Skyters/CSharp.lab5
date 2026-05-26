using CSharp.lab5.Objects;

namespace CSharp.lab5
{
    public partial class Form1 : Form
    {
        public float count = 0;

        public static Random rnd = new Random();

        List<BaseObject> objects = new();
        Player player;
        Marker marker;

        public Form1()
        {
            InitializeComponent();
            

            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);

            // добавляю реакцию на пересечение
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;
            };

            // добавил реакцию на пересечение с маркером
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };

            player.OnGreenMarkerOverlap += (m) =>
            {
                count = m.cost + count;
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Объект: {m} , был пренесен на координаты: {m.X} , {m.Y}.\n" + txtLog.Text;
                txtLog.Text = $"{DateTime.Now:HH:mm:ss:ff}] Добавлено: {m.cost} очков!\n" + txtLog.Text;
                objects.Remove(m);
                createGreenEnemy();
                lblSpore.Text = $"Очки: {count}";
            };



            for (int i = 0; i < 2; i++)
            {
                createGreenEnemy();
            }

            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);

            objects.Add(marker);
            objects.Add(player);
            createGreenEnemy();
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);
            
            // теперь сначала вызываем пересчёт игрока
            updatePlayer();

            // пересчитываем пересечения
            foreach (var obj in objects.ToList())
            {
                // проверяю было ли пересечение с игроком
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj); // то есть игрок пересекся с объектом
                    obj.Overlap(player);
                }

                obj.ToTick();
            }

            // рендерим объекты
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }

        }


        private void updatePlayer()
        {
            if (marker != null)
            {
                // расчитывает вектор между игроком и маркером
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                // находим его длину
                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                // пересчитываем координаты игрока
                player.vX += dx * 2.0f;
                player.vY += dy * 2.0f;

                // расчитываем угол поворота игрока
                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }

            // тормозящий момент,
            // нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.2f;
            player.vY += -player.vY * 0.2f;

            // пересчет позиция игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // запрашиваем обновление pbMain
            // это вызовет метод pbMain_Paint по новой
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            // тут добавил создание маркера по клику если он еще не создан
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }

        private void createGreenEnemy()
        {
            GreenEnemy g = new GreenEnemy((rnd.Next() % (pbMain.Width - 25) + 25), (rnd.Next() % (pbMain.Height - 25)), 0, 1, rnd.Next() % 100 + 70);

            g.ToDieOfOld += (green) =>
            {
                objects.Remove(green);
                createGreenEnemy();
                txtLog.Text = $"[{DateTime.Now:ss:ff}] Зелёный кружок умер, создан новый\n" + txtLog.Text;
            };
            objects.Add(g);
        }
    }
}
