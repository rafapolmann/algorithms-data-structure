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

    int changes = QuickSort(array, 0, array.Length - 1);
    Console.WriteLine($"Trocas: {changes} ");
    foreach (var item in array)
        Console.Write($"{item} ");

    Console.WriteLine("\r\n-----------------------------------------");
}

static int QuickSort(int[] array, int startPosition, int endPosition)
{
    int changes = 0;
    int pivot = array[startPosition];
    int left = startPosition;
    int right = endPosition;

    while (left <= right)
    {
        while (array[left] < pivot)
            left++;
        while (array[right] > pivot)
            right--;

        if (left <= right)
        {
            if(array[left]!= array[right])
                changes++;

            (array[left], array[right]) = (array[right], array[left]);
            left++;
            right--;          
        }
    }

    if (startPosition < right)
        changes += QuickSort(array, startPosition, right);

    if (left < endPosition)
        changes += QuickSort(array, left, endPosition);

    return changes;
}




