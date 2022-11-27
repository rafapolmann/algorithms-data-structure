namespace EditDistance
{
    internal static class Levenshtein
    {
        public static int ComputeDistance(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
                return second.Length;
            if (string.IsNullOrEmpty(second))
                return first.Length;

            int[,] d = new int[first.Length + 1, second.Length + 1];

            for (int i = 0; i <= first.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= second.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= first.Length; i++)
            {
                for (int j = 1; j <= second.Length; j++)
                {
                    int cost = (second[j - 1] == first[i - 1]) ? 0 : 1;
                    int e1 = d[i - 1, j] + 1;
                    int e2 = d[i, j - 1] + 1;
                    int e3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Min(e1, e2, e3);
                }
            }

            return d[first.Length, second.Length];
        }

        public static int ComputeDistanceOptimized(string first, string second)
        {
            if (string.IsNullOrEmpty(first))
                return second.Length;
            if (string.IsNullOrEmpty(second))
                return first.Length;

            int current = 1;
            int previous = 0;
            int[,] r = new int[2, second.Length + 1];

            for (int i = 0; i <= second.Length; i++)
                r[previous, i] = i;

            for (int i = 0; i < first.Length; i++)
            {
                r[current, 0] = i + 1;
                for (int j = 1; j <= second.Length; j++)
                {
                    int cost = (second[j - 1] == first[i]) ? 0 : 1;
                    int e1 = r[previous, j] + 1;
                    int e2 = r[current, j - 1] + 1;
                    int e3 = r[previous, j - 1] + cost;
                    r[current, j] = Min(e1, e2, e3);
                }
                previous = (previous + 1) % 2;
                current = (current + 1) % 2;
            }

            return r[previous, second.Length];
        }

        private static int Min(int e1, int e2, int e3) => Math.Min(Math.Min(e1, e2), e3);
    }
}
