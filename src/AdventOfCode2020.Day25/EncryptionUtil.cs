namespace AdventOfCode2020.Day25
{
    public static class EncryptionUtil
    {
        private const long _modulo = 20_201_227L;

        public static (int cardLoopSize, int doorLoopSize) GetLoopSize(
             long cardPublicKey,
             long doorPublicKey,
             long subjectNumber)
        {
            var (cardLoopSize, doorLoopSize) = (0, 0);

            var key = 1L;

            for (var i = 1; cardLoopSize == 0 || doorLoopSize == 0; i++)
            {
                key *= subjectNumber;

                key %= _modulo;

                if (key == cardPublicKey)
                {
                    cardLoopSize = i;
                }

                if (key == doorPublicKey)
                {
                    doorLoopSize = i;
                }
            }

            return (cardLoopSize, doorLoopSize);
        }

        public static long GetEncryptionKey(
            long publicKey,
            int loopSize)
        {
            var key = 1L;

            for (var i = 0; i < loopSize; i++)
            {
                key *= publicKey;

                key %= _modulo;
            }

            return key;
        }
    }
}
