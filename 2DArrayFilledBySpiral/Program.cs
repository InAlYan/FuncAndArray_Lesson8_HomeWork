// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int InputNumber(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

void Fill2dArrayBySpiral(int[,] array)
{
    int iBegin = 0, iEnd = array.GetLength(0) - 1, jBegin = 0, jEnd = array.GetLength(1) - 1;
    int iDirection = 1, jDirection = 1, newValue = 1;

    //Количество проходов по прямоугольной матрице по спирали равно countOfPass = 2 * min(array.GetLength) -1
    int countOfPass = array.GetLength(0) > array.GetLength(1) ? 2 * array.GetLength(1) - 1 : 2 * array.GetLength(0) - 1;
    int currentPass = 1;

    while (currentPass <= countOfPass)
    {
        if (iDirection > 0) // если направление вниз iDirection > 0  
        {
            for (int j = jBegin; j <= jEnd; j++) // проходим по строке iBegin с jBegin по jEnd
            {
                array[iBegin, j] = newValue;
                newValue++;        
            }
            iBegin++;
        }
        else // иначе направление вверх iDirection < 0
        {
            for (int j = jEnd; j >= jBegin; j--)// проходим по строке iEnd с jEnd по jBegin            
            {
                array[iEnd, j] = newValue;
                newValue++;
            }
            iEnd--;
        }
        currentPass++;

        if (jDirection > 0) // если направление вправо jDirection < 0        
        {
            for (int i = iBegin; i <= iEnd; i++) // проходим по колонке jEnd c iBegin по iEnd
            {
                array[i, jEnd] = newValue;
                newValue++;
            }
            jEnd--;
        }
        else // иначе направление влево jDirection > 0
        {
            for (int i = iEnd; i >= iBegin; i--) // проходим по колонке jBegin c iEnd по iBegin            
            {
                array[i, jBegin] = newValue;
                newValue++;
            }
            jBegin++;
        }
        currentPass++;

        iDirection = -iDirection;    
        jDirection = -jDirection;
    }
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
            Console.Write($"{array[i, j]:d2}\t");
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.Clear();
int n = InputNumber("Введите количество строк: ");
int m = InputNumber("Введите количество столбцов: ");
Console.WriteLine();

int[,] myArray = CreateArray(n, m);
Fill2dArrayBySpiral(myArray);
PrintArray(myArray); 