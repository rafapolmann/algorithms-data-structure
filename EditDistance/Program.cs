
using EditDistance;
using System.Diagnostics;

string ant = "ant";
string aunt = "aunt";
Console.WriteLine($"Compare {ant}, {aunt}");
Console.WriteLine($"Levenshtein.ComputeDistance: {Levenshtein.ComputeDistance(ant, aunt)}");
Console.WriteLine($"Levenshtein.ComputeDistanceOptimized: {Levenshtein.ComputeDistanceOptimized(ant, aunt)}");
Console.WriteLine($"Distance.FindEditDistanceMemoization: {Distance.FindEditDistanceMemoization(ant, aunt)}");
Console.WriteLine($"Distance.FindEditDistance: {Distance.FindEditDistance(ant, aunt)}");
Console.WriteLine("-------------------------------------------------");

string sunday = "sunday";
string saturday = "saturday";
Console.WriteLine($"Compare {sunday}, {saturday}");
Console.WriteLine($"Levenshtein.ComputeDistance: {Levenshtein.ComputeDistance(sunday, saturday)}");
Console.WriteLine($"Levenshtein.ComputeDistanceOptimized: {Levenshtein.ComputeDistanceOptimized(sunday, saturday)}");
Console.WriteLine($"Distance.FindEditDistanceMemoization: {Distance.FindEditDistanceMemoization(sunday, saturday)}");
Console.WriteLine($"Distance.FindEditDistance: {Distance.FindEditDistance(sunday, saturday)}");

Console.WriteLine("-------------------------------------------------");
string str1 = @"1234abcdefg-UmaStringComMuitosCaracterers";
string str2 = @"1234abcdefg-OutraStringComMuitosCaracterers";
Console.WriteLine($"Compare {str1}, {str2}");

Stopwatch sw = new Stopwatch();

sw.Start();
int levenshteinComputeDistance = Levenshtein.ComputeDistance(str1, str2);
sw.Stop();
Console.WriteLine($"Levenshtein.ComputeDistance: {levenshteinComputeDistance} - Elapsed Time:  {sw.Elapsed.ToString()}");

sw.Start();
int levenshteinComputeDistanceOptimized = Levenshtein.ComputeDistanceOptimized(str1, str2);
sw.Stop();
Console.WriteLine($"Levenshtein.ComputeDistanceOptimized: {levenshteinComputeDistanceOptimized} - Elapsed Time:  {sw.Elapsed.ToString()}");

sw.Start();
int findEditDistanceMemoization = Distance.FindEditDistanceMemoization(str1, str2);
sw.Stop();
Console.WriteLine($"Distance.FindEditDistanceMemoization: {findEditDistanceMemoization} - Elapsed Time:  {sw.Elapsed.ToString()}");

sw.Start();
int findEditDistance = Distance.FindEditDistance(str1, str2);
sw.Stop();
Console.WriteLine($"Distance.FindEditDistance: {findEditDistance} - Elapsed Time:  {sw.Elapsed.ToString()}");
