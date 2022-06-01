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
            if (!correct) //к чему тут знак "!"? -- [sb] это логическое отрицание. в переводе на русский "если НЕ корректно...."
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
            for (int k = 0; k < Size; k++) // [sb] тут в цикле было условие i < Size, и цикл никогда не выполнялся, так как 
                // i было присвоено значение 'A' что в целочисленном эквиваленте где-то около 65. соответственно 65 < 10 
                // это ложь, и цикл не крутится совсем
            {
                Console.Write($" {i++} ");
            }
            Console.WriteLine();

            // [sb] сюда добавил ещё один пробел, иначе не соответствовало коду выше
            // Если хочется оставить 2 пробела, тогда надо один пробел убрать выше, в строке 36
            const string K = "   ";

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
                }
                // [sb] вот этот кусок должен быть за пределами цикла. 
                // иначе получается, что номер выводится после каждой клетки
                //Восстановление исходного цвета консоли
                Console.BackgroundColor = saveColor;
                Console.Write($" {h} ");
                Console.WriteLine();
            }
        }
    }
}
