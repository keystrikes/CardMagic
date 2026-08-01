using System;
using System.Collections.Generic;

namespace CardMagic.Logic
{
    /// <summary>
    /// Engine for the second magic trick - pair-based prediction method.
    /// Handles card pairing, shuffling, and pair selection tracking.
    /// </summary>
    public class Trick2Engine
    {
        private int[] cardDeck;              // Array of all 53 card indices
        private int[][] cardPairs;          // 10 pairs of cards
        private int selectedPairIndex;      // Index of the pair selected by user
        private bool isInitialized;

        /// <summary>
        /// Gets the card pairs (10 pairs of 2 cards each).
        /// </summary>
        public int[][] CardPairs
        {
            get { return cardPairs; }
        }

        /// <summary>
        /// Gets or sets the index of the selected pair.
        /// </summary>
        public int SelectedPairIndex
        {
            get { return selectedPairIndex; }
            set { selectedPairIndex = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Trick2Engine.
        /// </summary>
        public Trick2Engine()
        {
            cardDeck = new int[53];
            cardPairs = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                cardPairs[i] = new int[2];
            }
            selectedPairIndex = -1;
            isInitialized = false;
        }

        /// <summary>
        /// Initializes the deck and creates pairs of cards.
        /// </summary>
        public void Initialize()
        {
            InitializeDeck();
            ShuffleAndCreatePairs();
            isInitialized = true;
        }

        /// <summary>
        /// Initializes the deck with all 53 card indices.
        /// </summary>
        private void InitializeDeck()
        {
            for (int i = 0; i < 53; i++)
            {
                cardDeck[i] = i;
            }
        }

        /// <summary>
        /// Shuffles the deck and distributes cards into 10 pairs.
        /// </summary>
        public void ShuffleAndCreatePairs()
        {
            CardShuffler.Shuffle(cardDeck);
            CreatePairs();
        }

        /// <summary>
        /// Creates 10 pairs from the first 20 cards in the deck.
        /// </summary>
        private void CreatePairs()
        {
            int index = 0;
            for (int i = 0; i < 10; i++)
            {
                cardPairs[i][0] = cardDeck[index++];
                cardPairs[i][1] = cardDeck[index++];
            }
        }

        /// <summary>
        /// Records the pair selected by the user.
        /// </summary>
        /// <param name="pairIndex">Index of the selected pair (0-9)</param>
        public void SelectPair(int pairIndex)
        {
            if (pairIndex < 0 || pairIndex >= 10)
                throw new ArgumentOutOfRangeException(nameof(pairIndex), "Pair index must be between 0 and 9");

            selectedPairIndex = pairIndex;
        }

        /// <summary>
        /// Shuffles pairs and reorganizes them.
        /// The trick maintains tracking of the selected pair through strategic repositioning.
        /// </summary>
        public void ShufflePairs()
        {
            if (!isInitialized || selectedPairIndex == -1)
                throw new InvalidOperationException("Initialize and select a pair before shuffling.");

            CardShuffler.Shuffle(cardPairs);
        }

        /// <summary>
        /// Gets the predicted pair (should be reconstructed based on tracking logic).
        /// </summary>
        /// <returns>Array containing the two card indices of the predicted pair</returns>
        public int[] GetPredictedPair()
        {
            if (selectedPairIndex < 0 || selectedPairIndex >= cardPairs.Length)
                throw new InvalidOperationException("No valid pair has been selected.");

            return cardPairs[selectedPairIndex];
        }

        /// <summary>
        /// Gets the current state of all pairs (for display purposes).
        /// </summary>
        /// <returns>Copy of the current card pairs</returns>
        public int[][] GetCurrentPairs()
        {
            int[][] copy = new int[cardPairs.Length][];
            for (int i = 0; i < cardPairs.Length; i++)
            {
                copy[i] = new int[2];
                Array.Copy(cardPairs[i], copy[i], 2);
            }
            return copy;
        }

        /// <summary>
        /// Resets the engine to initial state.
        /// </summary>
        public void Reset()
        {
            selectedPairIndex = -1;
            isInitialized = false;
            Initialize();
        }

        /// <summary>
        /// Gets instruction text for the current phase.
        /// </summary>
        /// <returns>Instruction string for user</returns>
        public string GetInstruction()
        {
            if (!isInitialized)
                return "Keep one Pair in mind and click on Shuffle button to shuffle cards.";

            if (selectedPairIndex == -1)
                return "Select a pair to remember, then click Shuffle.";

            return "The prediction will be revealed!";
        }
    }
}
