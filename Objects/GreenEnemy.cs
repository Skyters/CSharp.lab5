using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Text;

namespace CSharp.lab5.Objects
{
    class GreenEnemy : BaseObject
    {
        public Action<GreenEnemy> ToDieOfOld;
        public float cost;
        public float timeToLive;

        public GreenEnemy(float x, float y, float angle, float cost, float timeToLive) : base(x, y, angle)
        {
            this.cost = cost;
            this.timeToLive = timeToLive;
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse( // рис. кружочек
                new SolidBrush(Color.Green),
                -15, -15,
                30, 30
            );
            g.DrawEllipse(new Pen(Color.Green, 2), -6, -6, 12, 12);
     
            g.DrawString(
                        $"{this.timeToLive}",
                        new Font("Verdana", 8),
                        new SolidBrush(Color.Green),
                        10, 10
            );
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6);
            return path;
        }

        public override void ToTick()
        {
            this.timeToLive -= 1f;
            if (this.timeToLive <= 0)
            {
                ToDieOfOld?.Invoke(this);
            }
        }
    }


}
