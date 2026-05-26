using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace CSharp.lab5.Objects
{
    class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<GreenEnemy> OnGreenMarkerOverlap;
        public float vX, vY;

        public Player(float x, float y, float angle) : base(x, y, angle)  
        {

        }

        public override void Render(Graphics g)
        {
            g.FillEllipse( // рис. кружочек
            new SolidBrush(Color.DeepSkyBlue),
                -15, -15,
                30, 30
            );

            g.DrawEllipse( // очёрчиваю кружочек
                new Pen(Color.Black, 2),
                -15, -15,
                30, 30
            );

            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0); // палочка направления игрока
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }

            if (obj is GreenEnemy)
            {
                OnGreenMarkerOverlap(obj as GreenEnemy);
            }
        }
    }
}
