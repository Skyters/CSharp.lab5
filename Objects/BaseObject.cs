using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CSharp.lab5.Objects
{
    class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
    
        public BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }

        // добавил виртуальный метод для отрисовки
        public virtual void Render(Graphics g)
        {
            // тут пусто
        }
    }
}