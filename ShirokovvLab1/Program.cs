using System;

class Program
{
    // Часть 1

    static void Main()
    {
        // Входные данные
        const int N = 10; 
        double[] array = { -2.5, 1.0, 3.7, -4.2, 0.0, 5.6, -7.8, 9.3, -10.5, 6.1 }; 
        const double X = 3.0; 

        // Решение и вывод результатов
        Console.WriteLine($"Количество элементов массива, больших {X}: {CountElementsGreaterThanX(array, X)}");
        Console.WriteLine($"Произведение элементов массива после максимального по модулю элемента: {ProductAfterMaxAbs(array)}");
        Console.WriteLine("Преобразованный массив: " + string.Join(" ", TransformArray(array)));
        
        // Часть 2
        
        const int Rows = 3; 
        const int Columns = 4; 
        int[,] matrix = { { 1, 2, 3, 0 }, { -1, 0, 5, 2 }, { 4, -2, 6, 7 } }; 

        // Решение и вывод результатов
        int columnWithZero = FindColumnWithZero(matrix);
        Console.WriteLine($"Номер первого столбца с нулевым элементом: {columnWithZero + 1}");

        Console.WriteLine("Матрица после перестановки строк:");
        int[,] sortedMatrix = SortMatrixByCharacteristics(matrix);
        PrintMatrix(sortedMatrix);
    }

    static int CountElementsGreaterThanX(double[] array, double X)
    {
        int count = 0;
        foreach (var element in array)
        {
            if (element > X)
            {
                count++;
            }
        }
        return count;
    }

    static double ProductAfterMaxAbs(double[] array)
    {
        int maxAbsIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) > Math.Abs(array[maxAbsIndex]))
            {
                maxAbsIndex = i;
            }
        }

        double product = 1;
        for (int i = maxAbsIndex + 1; i < array.Length; i++)
        {
            product *= array[i];
        }

        return product;
    }

    static double[] TransformArray(double[] array)
    {
        Array.Sort(array, (a, b) => Math.Sign(a) != Math.Sign(b) ? Math.Sign(a) : Math.Sign(b));
        return array;
    }

  

    static int FindColumnWithZero(int[,] matrix)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 0)
                {
                    return j;
                }
            }
        }
        return -1;
    }

    static int[,] SortMatrixByCharacteristics(int[,] matrix)
    {
        int[] characteristics = new int[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0 && matrix[i, j] % 2 == 0)
                {
                    characteristics[i] += matrix[i, j];
                }
            }
        }

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int k = i + 1; k < matrix.GetLength(0); k++)
            {
                if (characteristics[i] < characteristics[k])
                {
                    SwapRows(matrix, i, k);
                    SwapCharacteristics(characteristics, i, k);
                }
            }
        }

        return matrix;
    }

    static void SwapRows(int[,] matrix, int i, int k)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int temp = matrix[i, j];
            matrix[i, j] = matrix[k, j];
            matrix[k, j] = temp;
        }
    }

    static void SwapCharacteristics(int[] characteristics, int i, int k)
    {
        int temp = characteristics[i];
        characteristics[i] = characteristics[k];
        characteristics[k] = temp;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
