// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int InputNumber(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

void Fill3DArrayByRandom(int[,,] array, int minValue, int maxValue)
{
    int num;
    bool numInArray;
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
            {
                num = rnd.Next(minValue, maxValue + 1);
                if (!IsNumberIn3DArray(array, num))
                    array[i, j, k] = num;
                else
                    do
                    {
                        num = rnd.Next(minValue, maxValue + 1);
                        numInArray = IsNumberIn3DArray(array, num);
                        if (!numInArray)
                        {
                            array[i, j, k] = num;
                            numInArray = false;
                        }
                    }
                    while (numInArray);
            }
}

void Fill3DArrayLinear(int[,,] array, int fromNumber)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = fromNumber;
                fromNumber++;
            }
}

void Mix3DArrayByRandom(int[,,] array, int fromNumber)
{
    Fill3DArrayLinear(array, fromNumber);
    Random rnd = new Random();
    int temp, fromI, fromJ, fromK, toI, toJ, toK;
    for (int t = 0; t < array.Length; t++)
    {
        fromI = rnd.Next(0, array.GetLength(0));
        fromJ = rnd.Next(0, array.GetLength(1));
        fromK = rnd.Next(0, array.GetLength(2));
        toI = rnd.Next(0, array.GetLength(0));
        toJ = rnd.Next(0, array.GetLength(1));
        toK = rnd.Next(0, array.GetLength(2));
        temp = array[fromI, fromJ, fromK];
        array[fromI, fromJ, fromK] = array[toI, toJ, toK];
        array[toI, toJ, toK] = temp;
    }
}

bool IsNumberIn3DArray(int[,,] array, int number)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(1); k++)
                if (array[i, j, k] == number)
                    return true;
    return false;
}

int[,,] Create3DArray(int x, int y, int z)
{
    int[,,] array = new int[x, y, z];
    return array;
}

void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)                    
                Console.Write($"{array[j, k, i]}({j},{k},{i}) ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.Clear();
int x = InputNumber("Введите количество измерений по оси x: ");
int y = InputNumber("Введите количество измерений по оси y: ");
int z = InputNumber("Введите количество измерений по оси z: ");
Console.WriteLine();

int[,,] myArray = Create3DArray(x, y, z);
Fill3DArrayByRandom(myArray, 10, 99);
Console.WriteLine("МАССИВ ЗАПОЛНЕННЫЙ СЛУЧАЙНЫМ ОБРАЗОМ:");
Print3DArray(myArray);

int[,,] myArray2 = Create3DArray(x, y, z);
Mix3DArrayByRandom(myArray2, 10);
Console.WriteLine("МАССИВ ЗАПОЛНЕННЫЙ ЛИНЕЙНО И ПЕРЕМЕШАННЫЙ СЛУЧАЙНО:");
Print3DArray(myArray2);