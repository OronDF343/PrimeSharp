using OronUtil.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeSharp
{
    public static class ParallelUtil
    {
        public static void MarkAll(LongBitArray array, long modulo, bool value)
        {
            // Special code to mark all multiples of a number in a LongBitArray with multithreading
            // since LongBitArray is internally an array of unsigned ints, indexes 32 bits apart are stored at different addresses
            // because of this, for multiples of 32 or higher a simple loop will be thread-safe
            // for numbers below that, the operation is run multiple times, testing multiples of the number times 32 for every remainder which is a multiple of the number
            // which is effectively the same as running the operation normally, except that now it can be parallelized safely
            // Because of the nature of Parallel.For, the iterations are counted as multiples of the number
            // starting position is the number squared, since any numbers below that have a smaller prime factor, so they may be marked for that factor to save time
            // Note about the ForParams IEnumerable solution: Due to significant overhead it is better to work around the loop manually.
            if (modulo < 32)
                for (long i = 0; i < modulo * 32; i += modulo) MarkAllWithFakeMod(array, modulo * 32, i, value, modulo);
            else
                Parallel.For(modulo, DivRoundUp(array.Count, modulo), i => array[i * modulo] = value);
        }

        public static void MarkAllOdd(LongBitArray array, long modulo, bool value)
        {
            // same but skips even numbers
            // 16 can be used instead of 32 because loop skips num times 2
            if (modulo < 16)
                for (var i = modulo; i < modulo * 16; i += 2 * modulo) MarkAllWithFakeMod(array, modulo * 16, i, value, modulo);
            else
                Parallel.For(modulo / 2, DivRoundUp(DivRoundUp(array.Count, modulo) - 1, 2), i => array[(2 * i + 1) * modulo] = value);
        }

        private static void MarkAllWithFakeMod(LongBitArray array, long modulo, long remainder, bool value, long fakemod)
        {
            // For the smaller numbers, a different starting position was needed to respect the original value
            // using the same function recursively would have skipped the numbers between the number squared and the number times 32, squared.
            // so this loop starts at the current remainder, unless it is less than the number squared in which case it starts at the number times 32 plus the remainder
            Parallel.For(remainder < fakemod * fakemod ? 1 : 0, DivRoundUp(array.Count - remainder, modulo), i => array[i * modulo + remainder] = value);
        }

        public static IEnumerable<long> GetPrimesAsInt64(LongBitArray array)
        {
            var r = new List<long>();
            for (long i = 3; i < array.Count; i += 2)
                if (!array[i])
                    r.Add(i);
            return r;
        }

        private static long DivRoundUp(long x, long y)
        {
            return x / y + (x % y > 0 ? 1 : 0);
        }
    }
}
