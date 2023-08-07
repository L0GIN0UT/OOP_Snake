using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   //каласс фигур (наследуется классами Snake, Horisontallone, Verticalline)
    internal class Figure
    {   
        // создаем лист фигур
        protected List<myPoint> pList;

        // Метод отрисовки фигур
        public void Draw()
        {
            foreach (myPoint p in pList)
            {
                p.Draw();
            }
        }

        // Проверка на Удар об Стену
        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        // Проверка на то ударилась ли Snake
        private bool IsHit(myPoint point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
