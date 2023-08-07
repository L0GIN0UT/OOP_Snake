using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   // Класс Вертикальные Линии
    internal class VerticalLine: Figure
    {
        // Создание вертикальных линий (Принимает координаты и символ)
        // создает Список Линий
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<myPoint>();
            for (int y = yUp; y <= yDown; y++)
            {
                myPoint p = new myPoint(x, y, sym);
                pList.Add(p);
            }
        }
    }
}
