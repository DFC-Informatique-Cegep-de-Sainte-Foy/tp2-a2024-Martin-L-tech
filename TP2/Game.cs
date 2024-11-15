using System;
using System.Runtime.CompilerServices;

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
            int scoreOfCard = 0;
            switch (cardValue)
            {
                case ACE:
                    scoreOfCard = ACES_SCORE;
                    break;
                case TWO:
                    scoreOfCard = 2;
                    break;
                case THREE:
                    scoreOfCard = 3;
                    break;
                case FOUR:
                    scoreOfCard = 4;
                    break;
                case FIVE:
                    scoreOfCard = 5;
                    break;
                case SIX:
                    scoreOfCard = 6;
                    break;
                case SEVEN:
                    scoreOfCard = 7;
                    break;
                case EIGHT:
                    scoreOfCard = 8;
                    break;
                case NINE:
                    scoreOfCard = 9;
                    break;
                case TEN:
                    scoreOfCard = 10;
                    break;
                case JACK:
                    scoreOfCard = FACES_SCORE;
                    break;
                case QUEEN:
                    scoreOfCard = FACES_SCORE;
                    break;
                case KING:
                    scoreOfCard = FACES_SCORE;
                    break;
            }
            return scoreOfCard;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int handScore = 0;
            int[] cardSuits = new int[cardIndexes.Length];
            int[] cardValues = new int[cardIndexes.Length];
            int[] cardScores = new int[cardIndexes.Length];
            for (int i = 0;i < cardIndexes.Length; ++i)
            {
                cardSuits[i] = GetSuitFromCardIndex(cardIndexes[i]);
                cardValues[i] = GetValueFromCardIndex(cardIndexes[i]);
                cardScores[i] = GetScoreFromCardValue(cardIndexes[i]);
            }

            return handScore;
        }

        //******************************************************************************************************
        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les différentes combinaisons.
        // Référez-vous aux tests pour les noms de fonctions appropriés.
        // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
        // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
        // de tests avec vos noms de fonctions).

        #region Fonctions pour DrawFaces

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

        #endregion // Fin région Fonctions pour DrawFaces

        #region Fonctions pour GetHandScore

        public static int GetHighestCardValue(int[] values)
        {
            int highestCardValue = 0;
            for (int i = 0;i < values.Length; i++)
            {
                if (values[i] == ACE)
                {
                    highestCardValue = ACE;
                    return highestCardValue;
                }
                if (values[i] > highestCardValue)
                {
                    highestCardValue = values[i];
                }
            }
            return highestCardValue;
        }

        //**************************************************************************

        public static bool HasOnlySameColorCards(int[] suits)
        {
            bool hasOnlySameColorCards = false;
            if(VerifyIfNonExistingSuitPresent(suits))
            {
                return false;
            }
            int[] suitsCount = GetArrayOfSuitsCount(suits);
            if ((suitsCount[HEART] == 0) && (suitsCount[DIAMOND] == 0))
            {
                hasOnlySameColorCards = true;
            }
            if ((suitsCount[SPADE] == 0) && (suitsCount[CLUB] == 0))
            {
                hasOnlySameColorCards = true;
            }
            return hasOnlySameColorCards;
        }

        // Les trois (3) fonctions qui suivent servent pour la fonction
        // HasOnlySameColorCards.

        public static int ComputeNumberOfCardsInSuit(int[] suits, int suit)
        {
            int nbCardsInSuit = 0;
            for (int i = 0; i < suits.Length; i++)
            {
                if (suits[i] == suit)
                    nbCardsInSuit++;
            }
        return nbCardsInSuit;
        }

        public static int[] GetArrayOfSuitsCount(int[] suits)
        {
            int[] suitsCount = new int[NUM_SUITS];
            suitsCount[HEART] = ComputeNumberOfCardsInSuit(suits, HEART);
            suitsCount[DIAMOND] = ComputeNumberOfCardsInSuit(suits, DIAMOND);
            suitsCount[SPADE] = ComputeNumberOfCardsInSuit(suits, SPADE);
            suitsCount[CLUB] = ComputeNumberOfCardsInSuit(suits, CLUB);
            return suitsCount;
        }

        public static bool VerifyIfNonExistingSuitPresent(int[] suits)
        {
            bool isNonExistingSuitPresent = false;
            for (int i = 0;i < suits.Length; ++i)
            {
                if (suits[i] > CLUB)
                {
                    return true;
                }
            }
            return isNonExistingSuitPresent;
        }

        //*****************************************************************************

        public static bool HasAllSameCardValues(int[] values)
        {
            bool hasAllSameCardValues = false;
            int count = 0;
            for (int i = 1; i < values.Length; ++i)
            {
                if (values[i] == values[0])
                {
                    count++;
                }
            }
            if (count == (values.Length - 1))
            {
                hasAllSameCardValues = true;
            }
            return hasAllSameCardValues;
        }

        //**********************************************************************

        public static bool HasSequence(int[] values)
        {
            bool hasSequence = false;
            //On crée un nouveau tableau plutôt que de modifier le tableau
            //initial en utilisant une fonction de copie similaire à celle que j'avais  
            //créée pour la fonction DrawFaces mais qui diffère pour le type de tableau 
            //traité (int[] plutôt que bool[]). Cela nous permet d'éviter que l'on mélange  
            //les cartes, ce qui pourrait avoir des conséquences désagréables dans le jeu  
            //(si on modifie le tableau initial, une carte sélectionnée risque peut-être  
            //de ne plus l'être à cause du tri (permutation des cartes) et vice-versa...). 
            //Bref, on ne prend pas de risque.
            int[] copyOfValues = CopyArrayInNewArrayOfInt(values);
            SortWithBubbleSort(copyOfValues);
            int lowestValue = copyOfValues[0];
            int count = 1;
            for (int i = 1;i < copyOfValues.Length;++i)
            {
                if(copyOfValues[i] == lowestValue + i)
                {
                    count++;
                }
            }
            if (count == (copyOfValues.Length))
            {
                hasSequence = true;
            }

            return hasSequence;
        }

        //Les deux (2) fonctions suivantes servent pour la fonction HasSequence

        //Voici le code de la fonction que j'avais codée à l'exercice 20. J'ai
        //modifié son nom pour qu'il commence par un verbe et je l'utilise parce qu'elle
        //a passé les tests de l'exercice 20. J'ai laissé la précondition même si elle
        // n'est pas nécessaire pour ce travail.
        public static void SortWithBubbleSort(int[] numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentException("Array can't be null");
            }
            int count = 0;
            do
            {
                count = 0;
                for (int i = 0; i < numbers.Length - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int max = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = max;
                        count++;
                    }
                }

            }
            while (count > 0);
        }

        public static int[] CopyArrayInNewArrayOfInt(int[] originalArray)
        {
            int[] newArray = new int[originalArray.Length];
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = originalArray[i];
            }
            return newArray;
        }

        //*****************************************************************************

        public static bool HasAllFaces(int[] values)
        {
            bool isJackPresent = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == JACK)
                {
                    isJackPresent = true;
                }
            }
            return (isJackPresent && HasSequence(values));
        }

        public static bool HasOnlyFaces(int[] values)
        {
            bool hasOnlyFaces = false;
            int count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if ((values[i] == JACK) || (values[i] == QUEEN) || (values[i] == KING))
                {
                    count++;
                }
            }
            if (count == values.Length)
            {
                hasOnlyFaces = true;
            }
            return hasOnlyFaces;
        }

        public static bool HasSameColorSequence(int[] values, int[] suits)
        {
            return (HasSequence(values) && HasOnlySameColorCards(suits));
        }


        //*****************************************************************************

        #endregion // Fin région Fonctions pour GetHandScore

        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }
    }
}
