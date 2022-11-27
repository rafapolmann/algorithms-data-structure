namespace EditDistance
{
    internal class Distance
    {
        public static int FindEditDistance(string first, string second)
        {
            return FindEditDistance(first, second, first.Length, second.Length);
        }

        private static int FindEditDistance(string str1, string str2, int m, int n)
        {
            if (m == 0)
                return n;

            if (n == 0)
                return m;

            if (str1[m - 1] == str2[n - 1])
                return FindEditDistance(str1, str2, m - 1, n - 1);

            int insert = FindEditDistance(str1, str2, m, n - 1);
            int remove = FindEditDistance(str1, str2, m - 1, n);
            int replace = FindEditDistance(str1, str2, m - 1, n - 1);

            return 1 + Min(insert, remove, replace);
        }

        public static int FindEditDistanceMemoization(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;

            int[,] dp = new int[m + 1, n + 1];

            FillArray(dp);

            return FindEditDistanceMemoization(str1, str2, m, n, dp);
        }

        private static int FindEditDistanceMemoization(String str1, String str2, int m, int n, int[,] dp)
        {
            if (m == 0)
                return n;

            if (n == 0)
                return m;

            if (dp[m - 1, n - 1] != -1)
                return dp[m - 1, n - 1];

            if (str1[m - 1] == str2[n - 1])
            {
                dp[m - 1, n - 1] = FindEditDistanceMemoization(str1, str2, m - 1, n - 1, dp);
                return dp[m - 1, n - 1];
            }

            int insert = FindEditDistanceMemoization(str1, str2, m, n - 1, dp);
            int remove = FindEditDistanceMemoization(str1, str2, m - 1, n, dp);
            int replace = FindEditDistanceMemoization(str1, str2, m - 1, n - 1, dp);

            dp[m - 1, n - 1] = 1 + Min(insert, remove, replace);

            return dp[m - 1, n - 1];
        }

        private static void FillArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = -1;
                }
            }
        }

        private static int Min(int e1, int e2, int e3) => Math.Min(Math.Min(e1, e2), e3);
    }
}
