using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{  // Класс Змейка
    class Snake: Figure
    {   
        // Получаем Направление
        Direction direction;

        // Создание Змейки и постановка ее на карте с началом движения RIGHT
        // (Принимает координаты хвоста, длинну змейки и Направление)
        public Snake(myPoint tail, int length, Direction _direction) 
        {
            direction = _direction;
            pList = new List<myPoint>();
            for(int i = 0; i < length; i++)
            {
                myPoint p = new myPoint(tail); // Копии хвостовой точки (передаваемая в конструкторе)
                p.Move(i, direction);
                pList.Add(p);
            }
        }


        // Метод Движения (Удаляет из списка Змейка Хвостовой элемент и Добавдяет 1 элемент головы)
        internal void Move()
        {
            myPoint tail = pList.First();
            pList.Remove(tail);
            myPoint head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }


        // Получение следующей точки (для передвижения змейки)
        public myPoint GetNextPoint()
        {
            myPoint head = pList.Last();
            myPoint nextPoint = new myPoint(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        // Проверка на удар с Хвостом
        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        // Метод получения направления движения с Ввода Клавиатуры
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        // Проверка на то съела ли Змейка Еду или нет (Если да то эл еда двигается пока не станет хвостом)
        internal bool Eat(myPoint food)
        {
            myPoint head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }
    }
}
