using System;

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

    MergeSort(array);

    foreach (var item in array)
        Console.Write($"{item} ");

    Console.WriteLine("\r\n-----------------------------------------");
}

static void MergeSort(int[] array)
{
    int inputLength = array.Length;

    if (inputLength < 2)
        return;

    int midIndex = inputLength / 2;
    int[] leftHalf = new int[midIndex];
    int[] rightHalf = new int[inputLength - midIndex];

    for (int i = 0; i < midIndex; i++)
        leftHalf[i] = array[i];
    for (int i = midIndex; i < inputLength; i++)
        rightHalf[i - midIndex] = array[i];

    MergeSort(leftHalf);
    MergeSort(rightHalf);

    Merge(array, leftHalf, rightHalf);
}

static void Merge(int[] inputArray, int[] leftHalf, int[] rightHalf)
{
    int leftSize = leftHalf.Length;
    int rightSize = rightHalf.Length;
    int i = 0, j = 0, k = 0;

    while (i < leftSize && j < rightSize)
    {
        if (leftHalf[i] <= rightHalf[j])
            inputArray[k++] = leftHalf[i++];
        else
            inputArray[k++] = rightHalf[j++];
    }

    while (i < leftSize)
        inputArray[k++] = leftHalf[i++];
    while (j < rightSize)
        inputArray[k++] = rightHalf[j++];
}
