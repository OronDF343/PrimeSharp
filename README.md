PrimeSharp
==========

Finds prime numbers very quickly using a modified implementation of the Sieve of Eratosthenes.

* Fast algorithm implementation, o(n log log n) time comlexity. Cuts iterations wherever possible.
* Efficient memory use: Custom LongBitArray class, 1 bool = 1 bit. Does not leak memory when saving.
* Fast file IO using the Win32FileIO (WriteBlocks)
* Full multithreading: ensures thread saftey of the operation.
* Accuracy: Outputs correct number of primes according to pi(x)

On an Intel Core i5-2400 processor (4 cores, 4 threads, OC @ 3.6GHz), it takes only 6.3 seconds to find all the primes below 1 billion! Of which 0.15 seconds were for saving the results to the disk
