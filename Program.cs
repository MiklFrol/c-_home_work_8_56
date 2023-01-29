// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.Clear();

int[,] get2DArray(int colLenght, int rowLenght, int start, int finish)
{
    int[,] array = new int[colLenght, rowLenght];
    for (int i = 0; i < colLenght; i++)
    {
        for (int j = 0; j < rowLenght; j++)
        {
            array[i,j] = new Random().Next(start, finish + 1);
        }
    }
    return array;
}

void printInColor(string data)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(data);
    Console.ResetColor();
}

void print2DArray(int[,] array)
{
     Console.Write(" \t");
    for (int j = 0; j < array.GetLength(1); j++)
    {
         printInColor(j + "\t");
    }
    Console.WriteLine();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        printInColor( i + "\t");
        for (int j = 0; j < array.GetLength(1); j++)
        {       
            Console.Write(array[i,j] + "\t"); 
        }
        Console.WriteLine();
    }
}

int getMinSumOfRow(int[,] array)
{
    int minOfRow = 0;
    int minSumOfRow = 0;
    int sumOfRow = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        minOfRow += array[0, i];
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        sumOfRow += array[i, j];
        if (sumOfRow < minOfRow)
        {
            minOfRow = sumOfRow;
            minSumOfRow = i;
        }
        sumOfRow = 0;
    }
    return minSumOfRow;
}

int[,] array = get2DArray(4, 4, 1, 10);
print2DArray(array);
Console.WriteLine();
int minSumOfRow = getMinSumOfRow(array);
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write($"Строка с наименьшей суммой элементов - {minSumOfRow + 1}");
Console.ResetColor();