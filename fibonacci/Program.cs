using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
for (int i = 1; i <= 42; i++)
    Console.WriteLine($"{i.ToString("00")} - {Fibonacci(i)} ");
sw.Stop();

Console.WriteLine($"\r\nFinalizou em {sw.Elapsed.TotalSeconds} segundos");
Console.ReadKey();

static long Fibonacci(long n)
{
    return (n <= 1) ? n : (Fibonacci(n - 1) + Fibonacci(n - 2));
}

static long FibonacciMemoization(long n, long[]? cache = null)
{
    if (n <= 1)
        return n;

    cache ??= new long[n + 1];
    if (cache[n] == 0)
        cache[n] = FibonacciMemoization(n - 1, cache) + FibonacciMemoization(n - 2, cache);

    return cache[n];
}

static long FibonacciLocal(long n)
{
    if (n <= 1)
        return n;

    long a = 0, b = 1, c = 1;

    for (int i = 2; i <= n; i++)
    {
        c = a + b;
        a = b;
        b = c;
    }

    return c;
}

static long FibonacciMatrixExponentiation(long n)
{
    if (n == 0)
        return n;

    long i = n - 1;
    long a = 1, b = 0, c = 0, d = 1;

    long aux1 = 0;
    long aux2 = 0;

    while (i > 0)
    {
        if (i % 2 != 0)
        {
            aux1 = d * b + c * a;
            aux2 = d * (b + a) + c * b;
            a = aux1;
            b = aux2;
        }

        aux1 = (c * c) + (d * d);
        aux2 = d * (2 * c + d);
       
        c = aux1;
        d = aux2;

        i /= 2;
    }

    return a + b;
}




