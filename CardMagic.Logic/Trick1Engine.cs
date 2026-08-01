using System;
using System.Collections.Generic;
using System.Linq;

namespace CardMagic.Logic
{
    /// <summary>
    /// Engine for the first magic trick - 3x7 card distribution method.
    /// Handles card distribution, row selection, and prediction logic.
    /// </summary>
    public class Trick1Engine
    {
        private int[] cardDeck;           // Array of all 53 card indices
        private int[] row1;              // First row of 7 cards
        private int[] row2;              // Second row of 7 cards
        private int[] row3;              // Third row of 7 cards
        private int shuffleCount;         // Tracks number of shuffles/rounds

        /// <summary>
        /// Gets or sets the current shuffle count (number of rounds completed).
        /// </summary>
        public int ShuffleCount
        {
            get { return shuffleCount; }
            set { shuffleCount = value; }
        }

        /// <summary>
        /// Gets the cards in the first row.
        /// </summary>
        public int[] Row1
        {
            get { return row1; }
        }

        /// <summary>
        /// Gets the cards in the second row.
        /// </summary>
        public int[] Row2
        {
            get { return row2; }
        }

        /// <summary>
        /// Gets the cards in the third row.
        /// </summary>
        public int[] Row3
        {
            get { return row3; }
        }

        /// <summary>
        /// Initializes a new instance of the Trick1Engine.
        /// </summary>
        public Trick1Engine()
        {
            cardDeck = new int[53];
            row1 = new int[7];
            row2 = new int[7];
            row3 = new int[7];
            shuffleCount = 0;
            InitializeDeck();
        }

        /// <summary>
        /// Initializes the deck with all 53 card indices and shuffles.
        /// </summary>
        private void InitializeDeck()
        {
            for (int i = 0; i < 53; i++)
            {
                cardDeck[i] = i;
            }
        }

        /// <summary>
        /// Resets the trick to initial state.
        /// </summary>
        public void Reset()
        {
            shuffleCount = 0;
            InitializeDeck();
            ShuffleAndDistribute();
        }

        /// <summary>
        /// Shuffles the deck and distributes cards to three rows.
        /// </summary>
        public void ShuffleAndDistribute()
        {
            CardShuffler.Shuffle(cardDeck);
            DistributeToRows();
        }

        /// <summary>
        /// Distributes current deck cards to three rows (7 cards each).
        /// </summary>
        private void DistributeToRows()
        {
            int index = 0;
            for (int i = 0; i < 7; i++)
            {
                row1[i] = cardDeck[index++];
                row2[i] = cardDeck[index++];
                row3[i] = cardDeck[index++];
            }
        }

        /// <summary>
        /// Handles user selection of row 1 as containing their card.
        /// Reorganizes deck with selected row in the middle position.
        /// </summary>
        public void SelectRow1()
        {
            ReorganizeDeck(row2, row1, row3);
            shuffleCount++;
            ShuffleAndDistribute();
        }

        /// <summary>
        /// Handles user selection of row 2 as containing their card.
        /// Reorganizes deck with selected row in the middle position.
        /// </summary>
        public void SelectRow2()
        {
            ReorganizeDeck(row3, row2, row1);
            shuffleCount++;
            ShuffleAndDistribute();
        }

        /// <summary>
        /// Handles user selection of row 3 as containing their card.
        /// Reorganizes deck with selected row in the middle position.
        /// </summary>
        public void SelectRow3()
        {
            ReorganizeDeck(row1, row3, row2);
            shuffleCount++;
            ShuffleAndDistribute();
        }

        /// <summary>
        /// Reorganizes the deck based on user's row selection.
        /// The mathematical principle: placing selected row in middle reduces possibilities
        /// from 7 cards to 1 card after 3 rounds.
        /// </summary>
        /// <param name="firstRow">Cards to place first</param>
        /// <param name="middleRow">Selected row (placed in middle)</param>
        /// <param name="lastRow">Cards to place last</param>
        private void ReorganizeDeck(int[] firstRow, int[] middleRow, int[] lastRow)
        {
            int index = 0;

            // Place first row
            for (int i = 0; i < 7; i++)
            {
                cardDeck[index++] = firstRow[i];
            }

            // Place middle row
            for (int i = 0; i < 7; i++)
            {
                cardDeck[index++] = middleRow[i];
            }

            // Place last row
            for (int i = 0; i < 7; i++)
            {
                cardDeck[index++] = lastRow[i];
            }
        }

        /// <summary>
        /// Gets the predicted card index after all three rounds.
        /// By mathematical elimination, the card should be at position [3] in row 1.
        /// </summary>
        /// <returns>Index of predicted card (0-52)</returns>
        public int GetPredictedCard()
        {
            if (shuffleCount == 3)
            {
                return row1[3];
            }
            throw new InvalidOperationException("Prediction only available after 3 rounds of selection.");
        }

        /// <summary>
        /// Gets the instruction text for the current round.
        /// </summary>
        /// <returns>Instruction string for user</returns>
        public string GetInstruction()
        {
            switch (shuffleCount)
            {
                case 0:
                    return "Keep one Card in your mind and Click Row Button in which your card is";
                case 1:
                    return "Click Row button of your Card again";
                case 2:
                    return "Don't Worry this is Last time Click row button of your card";
                default:
                    return "Your card has been found!";
            }
        }

        /// <summary>
        /// Determines if the trick is complete (all 3 rounds done).
        /// </summary>
        /// <returns>True if trick is complete, false otherwise</returns>
        public bool IsComplete()
        {
            return shuffleCount >= 3;
        }
    }
}
