using System;
using System.Collections.Generic;

namespace CardMagic.Logic
{
    /// <summary>
    /// Handles shuffling logic for card arrays.
    /// Provides common shuffling operations used by different trick implementations.
    /// </summary>
    public class CardShuffler
    {
        /// <summary>
        /// Shuffles a generic array using Fisher-Yates algorithm.
        /// </summary>
        /// <typeparam name="T">Type of items in array</typeparam>
        /// <param name="items">Array to shuffle</param>
        /// <param name="iterations">Number of shuffle iterations (default 100)</param>
        public static void Shuffle<T>(T[] items, int iterations = 100)
        {
            if (items == null || items.Length == 0)
                return;

            Random rnd = new Random();
            for (int i = 0; i < iterations; i++)
            {
                int firstIndex = rnd.Next(0, items.Length);
                int secondIndex = rnd.Next(0, items.Length);

                if (firstIndex != secondIndex)
                {
                    T temp = items[firstIndex];
                    items[firstIndex] = items[secondIndex];
                    items[secondIndex] = temp;
                }
            }
        }

        /// <summary>
        /// Shuffles an integer array representing card positions.
        /// Used to generate random card order while preserving deck integrity.
        /// </summary>
        /// <param name="cardIndices">Array of card indices to shuffle</param>
        /// <param name="iterations">Number of shuffle iterations</param>
        public static void ShuffleIndices(int[] cardIndices, int iterations = 100)
        {
            Shuffle(cardIndices, iterations);
        }

        /// <summary>
        /// Gets a randomly shuffled deck of card indices (0-52).
        /// </summary>
        /// <returns>Shuffled array of card indices</returns>
        public static int[] GetShuffledDeck()
        {
            int[] deck = new int[53];
            for (int i = 0; i < 53; i++)
            {
                deck[i] = i;
            }
            Shuffle(deck);
            return deck;
        }
    }
}
