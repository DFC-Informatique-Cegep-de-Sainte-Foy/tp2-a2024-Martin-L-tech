using System;

namespace TP2
{
    public class Game
    {
        #region Constants
        public const int HEART = 0;
        public const int DIAMOND = 1;
        public const int SPADE = 2;
        public const int CLUB = 3;

        public const int ACE = 0;
        public const int TWO = 1;
        public const int THREE = 2;
        public const int FOUR = 3;
        public const int FIVE = 4;
        public const int SIX = 5;
        public const int SEVEN = 6;
        public const int EIGHT = 7;
        public const int NINE = 8;
        public const int TEN = 9;
        public const int JACK = 10;
        public const int QUEEN = 11;
        public const int KING = 12;

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int NUM_CARDS_IN_HAND = 3;

        public const int FACES_SCORE = 10;
        public const int ACES_SCORE = 11;

        public const int MAX_SCORE = 31;
        public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
        public const int ALL_FACES_SCORE = 30;
        public const int ONLY_FACES_SCORE = 28;
        public const int SAME_COLOR_SEQUENCE_SCORE = 28;
        public const int SEQUENCE_SCORE = 26;
        public const int SAME_COLOR_SCORE = 24;
        #endregion

        public static int GetSuitFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int suitNumber = index / NUM_CARDS_PER_SUIT;
            return suitNumber;
        }
        public static int GetValueFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int value = index % NUM_CARDS_PER_SUIT;
            return value;
        }

        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            // PROF : À COMPLETER.
            ModifyAvailableCards(cardValues, selectedCards, availableCards);
            //Choisit (relance) les cartes que le joueur ne veut pas garder.
            bool[] newAvailableCards = CopyArrayInNewArray(availableCards);
            for (int i = 0; i < NUM_CARDS_IN_HAND; i++)
            {
                if (!selectedCards[i])
                {
                    cardValues[i] = ChooseOneAvailableCard(newAvailableCards);
                }
            }
        }
        public static int GetScoreFromCardValue(int cardValue)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les différentes combinaisons.
        // Référez-vous aux tests pour les noms de fonctions appropriés.
        // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
        // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
        // de tests avec vos noms de fonctions).



        //Modifie le tableau des cartes disponibles en fonctions du tableau des cartes sélectionnées et de 
        //l'indice respectif de ces dernières.
        public static void ModifyAvailableCards(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (selectedCards[i])
                {
                    availableCards[cardValues[i]] = false;
                }
                else
                {
                    availableCards[cardValues[i]] = true;
                }
            }
        }

        //Choisit une carte (retourne son indice entre 0 et (NUM_CARDS - 1) parmi les
        //cartes disponibles et la rend ensuite "temporairement" non disponible
        //pour d'éventuels autres choix de cartes pour la même relance.
        public static int ChooseOneAvailableCard(bool[] availableCards)
        {
            int nbAvailableCards = ComputeNumberOfAvailableCards(availableCards);
            Random random = new Random();
            int cardValue = random.Next(0, nbAvailableCards);
            int newCardValue = cardValue;
            for (int i=0; i < cardValue + 1;i++)
            {
                if (!(availableCards[i]))
                {
                    newCardValue++;
                }
            }
            availableCards[newCardValue] = false;
            return newCardValue;
        }

        public static int ComputeNumberOfAvailableCards(bool[] availableCards)
        {
            int nbAvailableCards = 0;
            for(int i = 0;i < availableCards.Length;i++)
            {
                if(availableCards[i])
                {
                    nbAvailableCards++;
                }
            }
            return nbAvailableCards;
        }

        public static bool[] CopyArrayInNewArray(bool[] originalArray)
        {
            bool[] newArray = new bool[originalArray.Length];
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = originalArray[i];
            }
            return newArray;
        }

        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }
    }
}
