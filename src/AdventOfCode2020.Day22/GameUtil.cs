using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day22
{
    public static class GameUtil
    {
        public static void Play(
            Queue<int> player1,
            Queue<int> player2)
        {
            while (player1.Any() && player2.Any())
            {
                var (card1, card2) = (player1.Dequeue(), player2.Dequeue());

                if (card1 > card2)
                {
                    player1.Enqueue(card1);

                    player1.Enqueue(card2);
                }
                else
                {
                    player2.Enqueue(card2);

                    player2.Enqueue(card1);
                }
            }
        }
    }
}
