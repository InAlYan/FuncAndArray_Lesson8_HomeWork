// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortedRowsByMaxIn2dArray(int[,] array)
{
    //ЭТО РАБОТАЕТ, НО НЕ ОПТИМАЛЬНО (метод пузырька)
    // int temp;
    // Console.WriteLine("НАЧАЛО");
    // Console.WriteLine();
    // for (int i = 0; i < array.GetLength(0); i++)
    // {
    //     Console.WriteLine($"Строка: {i}");
    //     for (int j = 0; j < array.GetLength(1); j++)
    //     {
    //         // for (int k = j; k < array.GetLength(1) - 1; k++)
    //         for (int k = 0; k < array.GetLength(1) - 1; k++)            
    //         {
    //             Console.Write($"{k}: ");
    //             if (array[i, k] < array[i, k + 1])
    //             {
    //                 temp = array[i, k];
    //                 array[i, k] = array[i, k + 1];
    //                 array[i, k + 1] = temp;
    //                 //
    //                 for (int p = 0; p < array.GetLength(1); p++)
    //                     Console.Write($"{array[i, p]} ");
    //                 Console.Write($" обмен {k} и {k + 1}");
    //                 Console.WriteLine();
    //                 //
    //             }
    //             else
    //             {
    //                 //
    //                 for (int p = 0; p < array.GetLength(1); p++)
    //                     Console.Write($"{array[i, p]} ");
    //                 Console.Write($" {k} и {k + 1}");                        
    //                 Console.WriteLine();
    //                 //
    //             }
    //         }
    //         Console.WriteLine($"С {j + 1} позиции---------");                        
    //     }
    //     Console.WriteLine($"Конец строки: {i}");
    //     Console.WriteLine();
    //     Console.WriteLine();                
    // }
    // Console.WriteLine();
    // Console.WriteLine("КОНЕЦ");
    //ЭТО РАБОТАЕТ, НО НЕ ОПТИМАЛЬНО (метод пузырька)

    int localMax, localMaxColumn;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            localMax = array[i, j];
            localMaxColumn = j;
            for (int k = j; k < array.GetLength(1); k++)
                if (array[i, k] > localMax)
                {
                    localMaxColumn = k;
                    localMax = array[i, k];
                }
            if (localMaxColumn != j)
            {
                array[i, localMaxColumn] = array[i, j];
                array[i, j] = localMax;
            }
        }
}

int n = InputNumber("Введите количество строк: ");
int m = InputNumber("Введите количество столбцов: ");
int min = InputNumber("Минимальное значение в массиве: ");
int max = InputNumber("Максимальное значение в массиве: ");
int[,] myArray = CreateArray(n, m);
Fill2dArray(myArray, min, max);
PrintArray(myArray);

SortedRowsByMaxIn2dArray(myArray);

PrintArray(myArray);
// !!Работает, сделать красиво...