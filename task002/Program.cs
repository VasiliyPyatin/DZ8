// Задача 56: Задайте прямоугольный двумерный массив. 
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Исходный массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Результат:
// 1-строка

using System;
using static System.Console;

Clear();

Write("Введите размер матрицы через пробел: ");

string[] sizeS = ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
int rows = int.Parse(sizeS[0]);
int columns = int.Parse(sizeS[1]);
int[,] ar = GetRandomArray(rows, columns);
PrintArray(ar);
SumStringLineArray (ar);
MinSumStringArray (ar);

int[,] GetRandomArray(int row, int column)
{
    int [,] result = new int [row, column];
    for (int i = 0; i<result.GetLength(0); i++) 
    {
        for(int j = 0; j<result.GetLength(1); j++)
        {
            result [i,j] = new Random().Next(0,10);
        }
    }
    
    return result;
}

void PrintArray(int [,] array)
{
    for (int i = 0; i<array.GetLength(0); i++) 
    {
        for(int j = 0; j<array.GetLength(1); j++)
        {
            Write($"{array [i,j]} ");
        }
        WriteLine();
    }
}

void SumStringLineArray (int [,] ray) // метод выводит построчно сумму строк
{
    
    WriteLine("Сумма элементов в строках:");
         
    for (int numbString = 0; numbString < ray.GetLength(0); numbString++)
    {
        int sumString = 0;
        for (int j = 0; j<ray.GetLength (1); j++)
        {
            sumString+= ray [numbString,j];
        }
        WriteLine($"Номер строки: {numbString+1} Сумма элементов: {sumString}");
    }
}

int SumLineElements (int [,] arrayi, int indexLine) // метод считает сумму одной строки массива
{
    int sumLineMetod = arrayi[indexLine,0];
    for (int j = 1; j < arrayi.GetLength(1); j++)
        {
            sumLineMetod += arrayi[indexLine,j];
        }
    return sumLineMetod;
}

void MinSumStringArray (int [,] arr)
{
int minSumLine = 0;
int sumLine = SumLineElements(arr, 0);

for (int i = 1; i < rows; i++)
{
int tempSumLine = SumLineElements(arr, i);
if (sumLine > tempSumLine)
  {
    sumLine = tempSumLine;
    minSumLine = i;
  }
}

WriteLine($"Результат {minSumLine+1} - строкa");
}