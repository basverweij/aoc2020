using System;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020.Day13
{
    public static class EuclidUtil
    {
        /// <summary>
        /// <see href="https://en.wikipedia.org/wiki/Extended_Euclidean_algorithm"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static (BigInteger gcd, BigInteger x, BigInteger y) Extended(
            BigInteger a,
            BigInteger b)
        {
            var (r0, r1) = (a, b);

            var (s0, s1) = (BigInteger.One, BigInteger.Zero);

            var (t0, t1) = (BigInteger.Zero, BigInteger.One);

            while (r1 != 0)
            {
                var q = r0 / r1;

                (r0, r1) = (r1, r0 - q * r1);

                (s0, s1) = (s1, s0 - q * s1);

                (t0, t1) = (t1, t0 - q * t1);
            }

            return (r0, s0, t0);
        }

        /// <summary>
        /// <see href="https://math.stackexchange.com/questions/2218763/how-to-find-lcm-of-two-numbers-when-one-starts-with-an-offset"/>
        /// </summary>
        public static (BigInteger combinedPeriod, BigInteger combinedPhase) CombinedRotations(
            BigInteger periodA,
            BigInteger phaseA,
            BigInteger periodB,
            BigInteger phaseB)
        {
            var (gcd, s, _) = Extended(periodA, periodB);

            var deltaPhase = phaseA - phaseB;

            var phaseQuotient = BigInteger.DivRem(deltaPhase, gcd, out var phaseRemainder);

            if (phaseRemainder > 0)
            {
                throw new ArgumentException("rotation reference points never synchronize");
            }

            var combinedPeriod = periodA / gcd * periodB;

            var combinedPhase = ( phaseA - s * phaseQuotient * periodA ) % combinedPeriod;

            return (combinedPeriod, combinedPhase);
        }

        public static BigInteger Mod(
            BigInteger a,
            BigInteger b)
        {
            var m = a % b;

            if (m < 0)
            {
                m += b;
            }

            return m;
        }

        public static BigInteger Solution2(
            (int id, int index)[] ids)
        {
            var (combinedPeriod, combinedPhase) = (new BigInteger(ids[0].id), new BigInteger(ids[0].index));

            foreach (var id in ids.Skip(1))
            {
                (combinedPeriod, combinedPhase) = CombinedRotations(combinedPeriod, combinedPhase, id.id, id.index);
            }

            var timestamp = Mod(-combinedPhase, combinedPeriod);

            return timestamp;
        }
    }
}
