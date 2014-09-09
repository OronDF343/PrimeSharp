using System;
using System.Collections;
using System.Collections.Generic;

namespace OronUtil.Collections
{
    public class LongBitArray : IEnumerable<bool>, ICloneable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (long i = 0; i < Capacity; ++i)
                yield return this[i];
        }
        public IEnumerator<bool> GetEnumerator()
        {
            for (long i = 0; i < Capacity; ++i)
                yield return this[i];
        }

        public long Count
        {
            get { return Capacity; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot()
        {
            // not implemented, do not use
            return this;
        }

        public void CopyTo(LongBitArray array, int index)
        {
            // not fully implemented, do not use
            Data.CopyTo(array.Data, index / 8);
        }

        public void CopyTo(LongBitArray array, long index)
        {
            // not fully implemented, do not use
            Data.CopyTo(array.Data, index / 8);
        }

        public void CopyTo(Array array, int index)
        {
            // not fully implemented, do not use
            Data.CopyTo(array, index / 8);
        }

        public object Clone()
        {
            var temp = new LongBitArray(Capacity);
            CopyTo(temp, 0);
            return temp;
        }

        public volatile uint[] Data;

        public byte[] GetByteArray()
        {
            var result = new byte[Data.Length * sizeof(uint)];
            Buffer.BlockCopy(Data, 0, result, 0, result.Length);
            return result;
        }
        public long Capacity { get; private set; }

        public LongBitArray(long len)
        {
            Data = new uint[MathHelper.DivRoundUp(len, 32)];
            Capacity = 32 * Data.LongLength;
        }

        public void Set(long i, bool b)
        {
            Data[i / 32] = (byte)(b ? Data[i / 32] | MathHelper.OrMasks[i % 32] : Data[i / 32] & MathHelper.AndMasks[i % 32]);
        }

        public bool Get(long i)
        {
            return (Data[i / 32] >> (byte)(i % 32)) % 2 == 1;
        }

        public bool this[long index]
        {
            get { return (Data[index / 32] >> (byte)(index % 32)) % 2 == 1; }
            set
            {
                if (value) Data[index / 32] |= MathHelper.OrMasks[index % 32];
                else Data[index / 32] &= MathHelper.AndMasks[index % 32];
            }
        }

        public long[] IndexOf(bool p)
        {
            var temp = new List<long>();
            for (long i = 0; i < Capacity; ++i)
                if (Get(i) == p)
                    temp.Add(i);
            return temp.ToArray();
        }
    }
}
