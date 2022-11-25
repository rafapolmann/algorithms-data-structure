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

Console.WriteLine();

static void ShowArrayOrdained(int[] array)
{
    foreach (var item in array)
        Console.Write($"{item} ");
    Console.WriteLine();

    SortArray(array, array.Length);
    foreach (var item in array)
        Console.Write($"{item} ");

    Console.WriteLine("\r\n-----------------------------------------");
}

static void SortArray(int[] array, int size)
{
    if (size <= 1)
        return;

    for (int i = size / 2 - 1; i >= 0; i--)
    {
        Heapify(array, size, i);
    }

    for (int i = size - 1; i >= 0; i--)
    {
        (array[0], array[i]) = (array[i], array[0]);
        Heapify(array, i, 0);
    }
}

static void Heapify(int[] array, int size, int index)
{
    var largestIndex = index;
    var leftChild = 2 * index + 1;
    var rightChild = 2 * index + 2;
    if (leftChild < size && array[leftChild] > array[largestIndex])
    {
        largestIndex = leftChild;
    }
    if (rightChild < size && array[rightChild] > array[largestIndex])
    {
        largestIndex = rightChild;
    }
    if (largestIndex != index)
    {
        (array[index], array[largestIndex]) = (array[largestIndex], array[index]);
        Heapify(array, size, largestIndex);
    }
}