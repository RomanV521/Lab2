using Microsoft.Win32.SafeHandles;
using System;


//Вариант: №1
//Задания: 904, 911, 930, 967, 911;
internal class Program
{
    static void Main(string[] args)
    {
        Task904();
        Task911();
        Task930();
        Task967();
        Task911();
    }

    /// <summary>
    /// 904. Найти наибольший и наименьший элементы Двумерного массива вещественных чисел В[m, n].
    /// </summary>
    static void Task904()
    {
        Console.WriteLine("\n\n904. Найти наибольший и наименьший элементы Двумерного массива вещественных чисел В[m, n].\n");
        Random random = new Random();

        int minLength = 3, maxLength = 15;
        int[] length = { random.Next(minLength, maxLength), random.Next(minLength, maxLength)};
        
        double min = -10, max = 20;
        double[,] arrayB = GenerateRandomDoubleArray(min, max, length[0], length[1], "{0:F3}");
        double maxElement=min, minElement=max, currentElement;

        Console.WriteLine($"Значения M:{length[0]} и N:{length[1]}");
        for (int i = 0; i < length[0]; i++)
        {
            for (int j = 0; j < length[1]; j++)
            {
                currentElement = arrayB[i, j];

                if(currentElement < minElement)
                {
                    minElement = currentElement;
                }
                else if(currentElement > maxElement)
                {
                    maxElement = currentElement;
                }
            }
        }

        Console.WriteLine("Наибольший элемент: " + maxElement);
        Console.WriteLine("Наименьший элемент: " + minElement);
    }

    /// <summary>
    /// 911. Задан Двумерный массив вещественных чисел. Найти:
    ///     а) максимальную сумму абсолютных значений элементов по строкам и номер строки с такой суммой;
    ///     б) максимальную сумму абсолютных значений элементов по столбцам и номер столбца с такой суммой.
    /// </summary>
    static void Task911()
    {
        Console.WriteLine("\n\n911. Задан Двумерный массив вещественных чисел. Найти: \n\tа) максимальную сумму абсолютных значений элементов по строкам и номер строки с такой суммой; \n\tб) максимальную сумму абсолютных значений элементов по столбцам и номер столбца с такой суммой.\n");
        Random random = new Random();

        int minLength = 3, maxLength = 15;
        int[] length = { random.Next(minLength, maxLength), random.Next(minLength, maxLength) };
        int[] elementNumberSum = { -1, -1 }; //{rows, columns}

        double min = -10, max = 20, maxSumByRows = min, maxSumByColumns = min;
        double[,] array = GenerateRandomDoubleArray(min, max, length[0], length[1], "{0:F3}");
        Console.WriteLine($"Значения M:{length[0]} и N:{length[1]}");

        double rowSum, columnSum;
        for(int i = 0; i < length[0]; i++)
        {
            rowSum = 0;
            for(int j = 0; j < length[1]; j++)
            {
                rowSum += Math.Abs(array[i, j]); 
            }
            if(rowSum > maxSumByRows)
            {
                maxSumByRows = rowSum;
                elementNumberSum[0] = i;
            }
        }

        for(int i = 0;i < length[1]; i++)
        {
            columnSum = 0;
            for (int j = 0;j < length[0]; j++)
            {
                columnSum += Math.Abs(array[j,i]);
            }
            if(columnSum > maxSumByColumns)
            {
                maxSumByColumns= columnSum;
                elementNumberSum[1] = i;
            }
        }

        Console.WriteLine("Максимальная сумма абсолютных значений по строкам: " + maxSumByRows + ", номер строки: "+ elementNumberSum[0]);
        Console.WriteLine("Максимальная сумма абсолютных значений по столбцам: " + maxSumByColumns + ", номер столбца: " + elementNumberSum[1]);
    }

    /// <summary>
    /// 930. В Двумерном массиве вещественных чисел заменить все элементы, меньшие суммы элементов первой строки, этой суммой.
    /// </summary>
    static void Task930()
    {
        Console.WriteLine("\n\n930. В Двумерном массиве вещественных чисел заменить все элементы, меньшие суммы элементов первой строки, этой суммой.\n");
        Random random = new Random();

        int minLength = 3, maxLength = 15;
        int[] length = { random.Next(minLength, maxLength), random.Next(minLength, maxLength) };

        double min = -10, max = 20, sumOfFirstRow = 0;
        double[,] array = GenerateRandomDoubleArray(min, max, length[0], length[1], "{0:F3}");

        Console.WriteLine($"Значения M:{length[0]} и N:{length[1]}");
        for (int i = 0; i < length[1]; i++)
        {
            sumOfFirstRow += array[0, i]; 
        }

        for (int i = 1;i < length[0]; i++)
        {
            for (int j = 0; j < length[1]; j++)
            {
                if (array[i, j] < sumOfFirstRow)
                {
                    array[i, j] = sumOfFirstRow;
                }
            }
        }
        Console.WriteLine("Сумма элементов первой строки: "+ sumOfFirstRow);
        WritingArray("Массив после замены:", array, "{0:F3}");
    }

    /// <summary>
    /// 967. Фирма имеет 10 магазинов. Информация о доходе каждого магазина за каждый месяц года хранится в Двумерном массиве(первого магазина — в первой строке, второго — во второй и т. д.). 
    /// Составить программу для расчета среднемесячного дохода любого магазина.
    /// </summary>
    static void Task967()
    {
        Console.WriteLine("\n\n967. Фирма имеет 10 магазинов. Информация о доходе каждого магазина за каждый месяц года хранится в Двумерном массиве(первого магазина — в первой строке, второго — во второй и т. д.).\nСоставить программу для расчета среднемесячного дохода любого магазина.\n");

        int numberOfStores = 10, numberOfMonths = 12, min=0, max=100, answer;
        double[,] income = GenerateRandomDoubleArray(min, max, numberOfStores, numberOfMonths, "{0:F3}");
        double averageIncome, overallIncome = 0;

        do
        {
            Console.Write("Введите номер магазина (от 1 до 10): ");
            answer = Convert.ToInt32(Console.ReadLine());
        } while (answer > numberOfStores || answer<1);

        for(int month = 0; month < numberOfMonths; month++)
        {
            overallIncome += income[answer - 1, month];
        }
        averageIncome = overallIncome / numberOfMonths;

        Console.WriteLine($"Среднемесячный доход для магазина №{answer}: {averageIncome:F3}");
    }

    /// <summary>
    /// Функция генерирует двумерный массив из чисел формата double
    /// </summary>
    /// <param name="min">Минимальное значение в формате double</param>
    /// <param name="max">Максимальное значение в формате double</param>
    /// <param name="lengthM">Длина строк</param>
    /// <param name="lengthN">Длина столбцов</param>
    /// <param name="form">Формула для сокращенного вывода чисел типа double</param>
    /// <returns>Массив с числами</returns>
    static double[,] GenerateRandomDoubleArray(double min, double max, int lengthM, int lengthN, string form)
    {
        Random random = new Random();
        double[,] array = new double[lengthM, lengthN];
        Console.WriteLine($"\tМассив с округленными значениями {form}:\n");
        for (int i = 0; i < lengthM; i++)
        {
            for (int j = 0; j < lengthN; j++)
            {
                array[i, j] = random.NextDouble() * (max - min) + min;
                Console.Write($"\t{string.Format(form, array[i, j])}");
            }
            Console.WriteLine("\n");
        }
        return array;
    }

    /// <summary>
    /// Функция выводит двумерный массив из чисел с предварительным текстом
    /// </summary>
    /// <param name="text">Текст</param>
    /// <param name="array">Массив в формате double</param>
    static void WritingArray(string text, double[,] array, string form)
    {
        Console.WriteLine("\n\n" + text);
        int m = array.GetLength(0), n = array.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"\t{string.Format(form, array[i, j])}");
            }
            Console.WriteLine();
        }
    }
}
