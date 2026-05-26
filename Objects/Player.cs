using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.lab5.Objects
{
    class Player : BaseObject
    {
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
    }
}
