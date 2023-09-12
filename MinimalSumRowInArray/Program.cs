// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int InputNumber(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

void Fill2dArray(int[,] array, int minValue, int maxValue)
{
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(minValue, maxValue + 1);
}

int[,] CreateArray(int rows, int cols)
{
    int[,] array = new int[rows, cols];
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]}\t");
        Console.WriteLine();
    }
    Console.WriteLine();
}

int MinimalRowIn2DArray(int[,] array)
{
    int sum = 0, minRow = 0, minSum;
    for (int i = 0; i < array.GetLength(1); i++)
        sum += array[0, i];
    minSum = sum;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
            sum += array[i, j];
        if (sum < minSum)
        {
            minRow = i;
            minSum = sum;
        }
    }

    return minRow;
}

int n = InputNumber("Введите количество строк: ");
int m = InputNumber("Введите количество столбцов: ");
int min = InputNumber("Минимальное значение в массиве: ");
int max = InputNumber("Максимальное значение в массиве: ");
int[,] myArray = CreateArray(n, m);
Fill2dArray(myArray, min, max);
PrintArray(myArray);

Console.WriteLine($"{MinimalRowIn2DArray(myArray)} строка");