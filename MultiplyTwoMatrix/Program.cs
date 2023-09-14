// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


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

bool AdjacencyMatrix(int[,] arr1, int[,] arr2)
{
    return arr1.GetLength(1) == arr2.GetLength(0);
}

int[,] MatrixMultiplication(int[,] arr1, int[,] arr2)
{
    int[,] multArray;
    if (AdjacencyMatrix(arr1, arr2))
    {
        Console.WriteLine($"Матрицы смежны");
        int newRows = arr1.GetLength(0);
        int newCols = arr2.GetLength(1);
        int commonDimension = arr1.GetLength(1);
        int mult;

        multArray = CreateArray(newRows, newCols);
        for (int i = 0; i < newRows; i++)
            for (int j = 0; j < newCols; j++)
            {
                mult = 0;
                for (int k = 0; k < commonDimension; k++)
                    mult += arr1[i, k] * arr2[k, j];
                multArray[i, j] = mult;
            }
    }
    else
    {
        Console.WriteLine($"Матрицы не смежны");
        multArray = CreateArray(1, 1);
    }
    return multArray;
}

Console.Clear();

int n = InputNumber("Введите количество строк: ");
int m = InputNumber("Введите количество столбцов: ");
int min = InputNumber("Минимальное значение в массиве: ");
int max = InputNumber("Максимальное значение в массиве: ");
int[,] myArray = CreateArray(n, m);
Fill2dArray(myArray, min, max);

int n2 = InputNumber("Введите количество строк: ");
int m2 = InputNumber("Введите количество столбцов: ");
int min2 = InputNumber("Минимальное значение в массиве: ");
int max2 = InputNumber("Максимальное значение в массиве: ");
int[,] myArray2 = CreateArray(n2, m2);
Fill2dArray(myArray2, min2, max2);

PrintArray(myArray);
PrintArray(myArray2);

int[,] multMatrix = MatrixMultiplication(myArray, myArray2);
PrintArray(multMatrix);