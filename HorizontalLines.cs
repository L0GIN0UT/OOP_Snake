using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    // класс Горизонтальные Линии (принимает координаты и символ)
    class HorizontalLine : Figure // Горизонтальная линия - частный случай фигуры
                                 // таким образом происходит наследование
    {
        // Создание Листа Линий
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<myPoint>();
            for (int x = xLeft; x <= xRight; x++)
            {
                myPoint p = new myPoint(x, y, sym);
                pList.Add(p);
            }

        }
        
    }
}
