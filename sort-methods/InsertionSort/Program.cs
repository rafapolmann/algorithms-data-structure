var arrayToSort1 = new int[] { 15, 2, 35, 9, 24, 32, 21, 11, 10, 6, 7, 8, 50, 1, 0, 4 };
var arrayToSort2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var arrayToSort3 = new int[] { 1, 9, 3, 4, 5, 6, 7, 8, 2, 10 };
var arrayToSort4 = new int[] { 4, 2, 7, 10, 9, 6, 3, 1, 5, 8 };

Console.WriteLine($"Array1 lenght:{arrayToSort1.Length}");
ShowArrayOrdained(arrayToSort1);

Console.WriteLine($"Array2 lenght:{arrayToSort2.Length}");
ShowArrayOrdained(arrayToSort2);

Console.WriteLine($"Array3 lenght:{arrayToSort3.Length}");
ShowArrayOrdained(arrayToSort3);

Console.WriteLine($"Array4 lenght:{arrayToSort4.Length}");
ShowArrayOrdained(arrayToSort4);

static void ShowArrayOrdained(int[] array)
{
    foreach (var item in array)
        Console.Write($"{item} ");
    Console.WriteLine();

    long changes = InsertionSort(array);
    Console.WriteLine($"Trocas: {changes} ");
    foreach (var item in array)
        Console.Write($"{item} ");

    Console.WriteLine("\r\n-----------------------------------------");
}

static long InsertionSort(int[] array)
{
    long changes = 0;
    for (int i = 1; i < array.Length; i++)
    {
        int current = array[i];
        int j = i - 1;
        while (j >= 0 && array[j] > current)
        {
            array[j + 1] = array[j];
            j--;
            changes++;
        }

        array[j + 1] = current;
    }
    return changes;
}