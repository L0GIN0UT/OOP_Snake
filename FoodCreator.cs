using Snake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Snake
{  // Класс Генератор Еды (принимает размеры карты (длина ширина) и символ)
    internal class FoodCreator
    {
        int mapWidht;
        int mapHeight;
        char sym;

        Random rand = new Random();

        // генератор положения еды на карте
        public FoodCreator(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        // Создание еды
        internal myPoint CreateFood()
        {
            int x = rand.Next(2, mapWidht - 2);
            int y = rand.Next(2, mapHeight - 2);
            return new myPoint(x, y, sym);
        }
    }
}
