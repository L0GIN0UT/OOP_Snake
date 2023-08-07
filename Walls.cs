using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Snake
{   // Класс Стены
    internal class Walls
    {
        // Создаем Список стен
        List<Figure> wallList;

        // Стена принимает Длинну И Ширину карты
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            // Отрисовываем рамку игры
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '■');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '■');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '■');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '■');

            // Добавляем стены в список
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        // Проверка на удар стены о фигуру
        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        // Отрисока Стен
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
