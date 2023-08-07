using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   // Класс Точка (принимает координаты и символ)
    internal class myPoint
    {
        public int x;
        public int y;
        public char sym;

        // Связующий "Метод" (получающий Коррдинаты точки и символ) передающий их дальше
        public myPoint(int _x, int _y, char _sym)
        {
            x = _x;
            y = _y;
            sym = _sym;
        }

        // Передача точек Хвоста и Головы Snake
        public myPoint(myPoint p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }


        // метод Движение (принимает следующую точку в которую надо передвинуться и Направление)
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }

        // Проверка на удар об Точку
        public bool IsHit(myPoint p)
        {
            return p.x == this.x && p.y == this.y;
        }

        // Метод отрисовки точек
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(sym);
            
        }
        
        // метод очищения точек (для движения змейки)
        public void Clear()
        {
            sym = ' ';
            Draw();
        }

       
        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
