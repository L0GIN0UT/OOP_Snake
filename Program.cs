using OOP_Snake;
using Snake;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{   // Класс программа (Где мы собираем проект по кирпичикам)
    class Program
    {

        static void Main(string[] args)
        {
            // Делаем консоль определенного размера
            // Console.SetBufferSize(80, 25);

            // Создаем список Стен и Передаем в них размер + Рисуем Стены
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Создаем Змейку и задаем её Координаты      Длинну и Направление + Рисуем Змейку
            myPoint p = new myPoint(4, 5, '@');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // Создаем Еду и задаем Пределы ее Генерации и Символ + Рисуем Еду
            FoodCreator foodCreator = new FoodCreator(80, 25, '*');
            myPoint food = foodCreator.CreateFood();
            food.Draw();

            // Вечный цикл для Движения Змейки с Проверкой на Удар о Стену + Удар о Хвост
            // Если Змейка съела Еду то Она Вырастает 
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                // Задержка движения Змейки
                Thread.Sleep(100);

                // Считывание Нажатия клавиши
                // заставляет змейку двигаться по направлению (вверх, вниз, влево, вправо)
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            // Если Цикл прервался а прервался он потоу что Змейка Ударилась
            // Завершаем игру
            WriteGameOver();
            Console.ReadLine();

        }

        // Метод Отрисовки Финального Сообщения
        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            yOffset++;
            WriteText("Автор: Логин Иван", xOffset + 1, yOffset++);
            WriteText("GeekBrains - курс ООП", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        // Установка позиции печати текста
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
        
    }
}

