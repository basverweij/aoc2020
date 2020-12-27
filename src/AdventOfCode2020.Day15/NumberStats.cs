namespace AdventOfCode2020.Day15
{
    public class NumberStats
    {
        public int Count { get; set; }

        public int LastTurn { get; set; }

        public NumberStats(
            int count,
            int lastTurn)
        {
            Count = count;

            LastTurn = lastTurn;
        }

        public override string? ToString() => $"{{Count={Count}, LastTurn={LastTurn}}}";
    }
}
