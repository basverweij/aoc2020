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

        public static void PlayRecursive(
            Queue<int> player1,
            Queue<int> player2)
        {
            var (cards1, cards2) = (new List<int[]>(), new List<int[]>());

            while (player1.Any() && player2.Any())
            {
                if (cards1.Any(c => Enumerable.SequenceEqual(c, player1)) ||
                    cards2.Any(c => Enumerable.SequenceEqual(c, player2)))
                {
                    // player 1 wins

                    player2.Clear();

                    return;
                }

                cards1.Add(player1.ToArray());

                cards2.Add(player2.ToArray());

                var (card1, card2) = (player1.Dequeue(), player2.Dequeue());

                if (player1.Count >= card1 &&
                    player2.Count >= card2)
                {
                    // play recursive sub-game

                    var (copy1, copy2) = (new Queue<int>(player1.Take(card1)), new Queue<int>(player2.Take(card2)));

                    PlayRecursive(copy1, copy2);

                    if (copy1.Any())
                    {
                        // player 1 won sub-game

                        player1.Enqueue(card1);

                        player1.Enqueue(card2);
                    }
                    else
                    {
                        // player 2 won sub-game

                        player2.Enqueue(card2);

                        player2.Enqueue(card1);
                    }
                }
                else
                {
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
}
