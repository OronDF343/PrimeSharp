using OronUtil.Collections;
using System;
using System.Collections.Generic;
using Win32FileIO;

namespace PrimeSharp
{
    public static class Engine
    {
        public static LongBitArray GetPrimes(long length)
        {
            // Custom super-fast sieving algorithm based on Sieve of Erathnoses
            // 1 billion length in ~6.3 seconds! (Intel Core i5-2400 3.1GHz (OC@3.6GHz) / 4 cores / 4 threads)
            // arithmetic time complexity might be o(n log log n)

            // First, all primes up to Sqrt(length) are found using standard sieve:
            var sq = (int) Math.Sqrt(length) + 1;
            var knownPrimes = new LongBitArray(sq);
            // Mark all multiples of 2 first
            ParallelUtil.MarkAll(knownPrimes, 2, true);
            // Use standard sieve:
            for (long i = 3; i < sq; i += 2)
                if (!knownPrimes[i])
                    ParallelUtil.MarkAllOdd(knownPrimes, i, true);
            // make sure padding does not show up as prime
            for (long i = sq; i < knownPrimes.Count; ++i)
                knownPrimes[i] = true;
            // Get these known primes as actual numbers
            var known = ParallelUtil.GetPrimesAsInt64(knownPrimes);

            // In the full array, mark all the multiples of the known primes.
            // This will effectively sift the entire array because:
            // all nonprime numbers up to x have at least one prime factor less than or equal to Sqrt(x) (this is trivial)
            // therefore, by eliminating all multiples of all the possible prime factors below sqrt(x), only te prime numbers will be left.
            var allPrimes = new LongBitArray(length + 1);
            ParallelUtil.MarkAll(allPrimes, 2, true);
            foreach (var p in known) ParallelUtil.MarkAllOdd(allPrimes, p, true);
            
            // 0 and 1 were skipped, so mark them as nonprime
            allPrimes[0] = true;
            allPrimes[1] = true;
            // make sure padding does not show up as prime
            for (var i = length + 1; i < allPrimes.Count; ++i)
                allPrimes[i] = true;
            return allPrimes;
        }

        //private static readonly byte[] BitZeroCount = { 4, 3, 3, 2, 3, 2, 2, 1, 3, 2, 2, 1, 2, 1, 1, 0 };

        public static long Save(uint[] data, string filename)
        {
            long count = 0;
            for (long c = 0; c < data.Length; ++c)
                count += 32 - BitCount(data[c]);

            using (var wf = new WinFileIO(data))
            {
                wf.OpenForWriting(filename);
                wf.WriteBlocks(data.Length * 4);
                wf.Close();
            }

            return count;
        }

        private static uint BitCount(uint n)
        {
            // BitHacks
            var m = n - ((n >> 1) & 0x55555555);
            m = (m & 0x33333333) + ((m >> 2) & 0x33333333);
            return ((m + (m >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
        }

        public static Dictionary<long, byte> GetPrimeFactors(long num)
        {
            var a = Engine.GetPrimes(num);
            var p = a.IndexOf(true);
            var f = new Dictionary<long, byte>();
            long i = 0;
            while (num != 1 && i < p.Length)
            {
                if (num % p[i] == 0)
                {
                    if (!f.ContainsKey(p[i])) f.Add(p[i], 0);
                    ++f[p[i]];
                    num /= p[i];
                }
                else
                    ++i;
            }
            return f;
        }

        public static bool LongCheck(long num)
        {
            var limit = (long)Math.Sqrt(num);

            if (num % 2 == 0)
                return false;

            for (long div = 3; div <= limit; div += 2)
                if (num % div == 0)
                    return false;

            return true;
        }
    }
}
