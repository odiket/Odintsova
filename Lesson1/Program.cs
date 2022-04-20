using System;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Какой размер шахматной доски?");

            // Задание строковой переменной размера, запись в консоль
            string size = Console.ReadLine();

            // Из строки в целое число
            bool correct = int.TryParse(size, out int Size); 
            if (!correct) //к чему тут знак "!"?
            {
                Console.WriteLine("Нам нужно число, а не: " + size);
                //Конец программы if
                return;
            }

            //Сохранение исходного цвета фона консоли
            ConsoleColor saveColor = Console.BackgroundColor;

            //Ответ консоли на мою цифру
            Console.WriteLine($"Готовая доска размером: {Size}x{Size}");

            //Буквы у клеток
            Console.Write($"   ");
            char i = 'A';
            for (int k = 0; i < Size; k++)
            {
                Console.Write($" {i++} ");
            }
            Console.WriteLine();

            const string K = "  ";

            //Формирование всего шахматного поля
            for (int h = Size; h >= 1; h--)
            {
                //Интерполяция строки. String вместо int
                Console.Write($" {h, 2} ");
                //Формирование одной строки поля
                for (int n = 1; n <= Size / 2; n++)
                {
                    //Четная или нечетная
                    if (h % 2 == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(K);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(K);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(K);
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(K);
                    }
                    //Восстановление исходного цвета консоли
                    Console.BackgroundColor = saveColor;
                    Console.Write($" {h} ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
