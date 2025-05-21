/*using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp17
{
    internal class Program
    {
        public class Card
        {
            public int value;
            public Card(int v)
            {
                this.value = v;
            }
        }
        public static void GetNewCards(int amount, List <Card> hand, List <Card> remainingCards)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                Thread.Sleep(100);
                int v = rnd.Next(0, remainingCards.Count());
                Card addingCard = remainingCards[v];
                hand.Add(addingCard);
                remainingCards.Remove(remainingCards[v]);
            }
        }
        static void Main(string[] args)
        {
            List<Card> allcards = new List<Card>(36);
            for (int i = 0; i < 9; i++)
            {
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
            }
            List <Card> hand1 = new List<Card>(5);
            List <Card> hand2 = new List<Card>(5);
            GetNewCards(5, hand1, allcards);
            GetNewCards(5, hand2, allcards);
            Console.WriteLine("Player 1's cards:\n");
            foreach (Card card in hand1)
            {
                Console.WriteLine(card.value);
            }
            Console.WriteLine();
            Console.WriteLine("Player 2's cards:\n");
            foreach (Card card in hand2)
            {
                Console.WriteLine(card.value);
            }
            Console.WriteLine();
            int totalSum = 0;
            bool chng1 = true;
            bool rplc1 = true;
            bool chng2 = true;
            bool rplc2 = true;
            int lastTurn = 0;
            while (totalSum < 60)
            {
                bool usedC1 = false;
                if (chng1 == true)
                {
                    Console.WriteLine("Want to switch your hand with player 2, player 1? (true/false)\n");
                    bool choice = bool.Parse(Console.ReadLine());
                    if (choice == true)
                    {
                        chng1 = false;
                        usedC1 = true;
                        List<Card> handbackup = hand1;
                        hand1 = hand2;
                        hand2 = handbackup;
                    }
                }
                if (rplc1 == true && lastTurn != 0 && usedC1 == false)
                {
                    Console.WriteLine("Want to replicate player 2's last turn, player 1? (true/false)\n");
                    bool choice = bool.Parse(Console.ReadLine());
                    if (choice == true)
                    {
                        rplc1 = false;
                        totalSum += lastTurn;
                    }
                    else
                    {
                        Console.WriteLine("Choose your card, player 1\n");
                        int playingCard1value = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        totalSum += playingCard1value;
                        foreach (Card card in hand1)
                        {
                            if (card.value == playingCard1value)
                            {
                                hand1.Remove(card);
                                break;
                            }
                        }
                        GetNewCards(1, hand1, allcards);
                        lastTurn = playingCard1value;
                    }
                }
                else if (usedC1 == false)
                {
                    Console.WriteLine("Choose your card, player 1\n");
                    int playingCard1value = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    totalSum += playingCard1value;
                    foreach (Card card in hand1)
                    {
                        if (card.value == playingCard1value)
                        {
                            hand1.Remove(card);
                            break;
                        }
                    }
                    GetNewCards(1, hand1, allcards);
                    lastTurn = playingCard1value;
                }
                if (totalSum > 50)
                {
                    Console.WriteLine("Player 2 WON!\n");
                    return;
                }
                bool usedC2 = false;
                if (chng2 == true)
                {
                    Console.WriteLine("Want to switch your hand with player 1, player 2? (true/false)\n");
                    bool choice = bool.Parse(Console.ReadLine());
                    if (choice == true)
                    {
                        chng2 = false;
                        usedC2 = true;
                        List<Card> handbackup = hand1;
                        hand1 = hand2;
                        hand2 = handbackup;
                    }
                }
                if (rplc2 == true && lastTurn != 0 && usedC2 == false)
                {
                    Console.WriteLine("Want to replicate player 2's last turn, player 1? (true/false)\n");
                    bool choice = bool.Parse(Console.ReadLine());
                    if (choice == true)
                    {
                        rplc2 = false;
                        totalSum += lastTurn;
                    }
                    else
                    {
                        Console.WriteLine("Choose your card, player 2\n");
                        int playingCard2value = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        totalSum += playingCard2value;
                        foreach (Card card in hand2)
                        {
                            if (card.value == playingCard2value)
                            {
                                hand2.Remove(card);
                                break;
                            }
                        }
                        GetNewCards(1, hand2, allcards);
                        lastTurn = playingCard2value;
                    }
                }
                else if (usedC2  == false)
                {
                    Console.WriteLine("Choose your card, player 2\n");
                    int playingCard2value = int.Parse(Console.ReadLine());
                    Console.WriteLine("");
                    totalSum += playingCard2value;
                    foreach (Card card in hand2)
                    {
                        if (card.value == playingCard2value)
                        {
                            hand2.Remove(card);
                            break;
                        }
                    }
                    GetNewCards(1, hand2, allcards);
                    lastTurn = playingCard2value;
                }
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"Total sum now: {totalSum}\n");
                Console.WriteLine("Player 1's cards:\n");
                foreach (Card card in hand1)
                {
                    Console.WriteLine(card.value);
                }
                Console.WriteLine();
                Console.WriteLine("Player 2's cards:\n");
                foreach (Card card in hand2)
                {
                    Console.WriteLine(card.value);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Player 1 WON!");
        }
    }
}*/
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleApp17
{
    internal class Program
    {
        public class Card
        {
            public int value;
            public Card(int v)
            {
                this.value = v;
            }
        }
        public static void GetNewCards(int amount, List<Card> hand, List<Card> remainingCards)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                Thread.Sleep(100);
                int v = rnd.Next(0, remainingCards.Count());
                Card addingCard = remainingCards[v];
                hand.Add(addingCard);
                remainingCards.Remove(remainingCards[v]);
            }
        }
        public class Turn
        {
            public int playerNumber;
            public bool replicateAvaliable;
            public bool changeAvaliable;
            public List<Card> hand;
            public int lastTurn;
            public event Action<string> MessageHandler;
            public Turn(int playerNumber, bool replicateAvaliable, bool changeAvaliable, List<Card> hand, int lastTurn)
            {
                this.playerNumber = playerNumber;
                this.replicateAvaliable = replicateAvaliable;
                this.changeAvaliable = changeAvaliable;
                this.hand = hand;
                this.lastTurn = lastTurn;
            }
            public int MakeATurn(string input, List<Card> allcards, ref int totalSum)
            {
                while (true)
                {
                    if (int.TryParse(input, out int cardValue))
                    {
                        foreach (Card card in hand)
                        {
                            if (card.value == cardValue)
                            {
                                MessageHandler?.Invoke($"Player {playerNumber} played a {cardValue} card.");
                                hand.Remove(card);
                                GetNewCards(1, hand, allcards);
                                totalSum += cardValue;
                                return cardValue;
                            }
                            else if (card == hand.Last())
                            {
                                MessageHandler?.Invoke($"Player {playerNumber} doesn't have such a card.");
                                return 0;
                            }
                        }
                    }
                    else if (input == "replicate")
                    {
                        if (replicateAvaliable)
                        {
                            if (lastTurn != 0)
                            {
                                MessageHandler?.Invoke($"Player {playerNumber} copies other player's move.");
                                totalSum += lastTurn;
                                replicateAvaliable = false;
                                return 20;
                            }
                            else
                            {
                                MessageHandler?.Invoke($"Player {playerNumber} can't copy other player's move because of his last turn.");
                                return 0;
                            }
                        }
                        else
                        {
                            MessageHandler?.Invoke($"Player {playerNumber} doesn't posess this powerup.");
                            return 0;
                        }
                    }
                    else if (input == "change")
                    {
                        if (changeAvaliable)
                        {
                            MessageHandler?.Invoke($"Player {playerNumber} exchanges his deck with the other player.");
                            changeAvaliable = false;
                            return 30;
                        }
                        else
                        {
                            MessageHandler?.Invoke($"Player {playerNumber} doesn't posess this powerup.");
                            return 0;
                        }
                    }
                    else if (input == "idle")
                    {
                        MessageHandler?.Invoke($"Player {playerNumber} chooses to do nothing.");
                        return 40;
                    }
                    else
                    {
                        MessageHandler?.Invoke("Invalid Command.");
                        return 0;
                    }
                }
            }
        }
        private static void ShowOnConsole(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            List<Card> allcards = new List<Card>(36);
            for (int i = 0; i < 9; i++)
            {
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
                allcards.Add(new Card(i + 1));
            }
            List<Card> hand1 = new List<Card>(5);
            List<Card> hand2 = new List<Card>(5);
            GetNewCards(5, hand1, allcards);
            GetNewCards(5, hand2, allcards);
            Console.WriteLine("Player 1's cards:\n");
            foreach (Card card in hand1)
            {
                Console.WriteLine(card.value);
            }
            Console.WriteLine("PowerUp 1: replicate other persons move");
            Console.WriteLine("PowerUp 2: exchange decks with other person");
            Console.WriteLine();
            Console.WriteLine("Player 2's cards:\n");
            foreach (Card card in hand2)
            {
                Console.WriteLine(card.value);
            }
            Console.WriteLine("PowerUp 1: replicate other persons move");
            Console.WriteLine("PowerUp 2: exchange decks with other person");
            Console.WriteLine();
            Console.WriteLine("Rules: first to 60 wins, type the value of the card you want to play (it will be added to the sum). Or, if you want, you can use one of this two powerups:");
            Console.WriteLine("PowerUp 1: replicate other persons move (type 'replicate').");
            Console.WriteLine("PowerUp 2: exchange decks with other person (type 'change').");
            Console.WriteLine("Or, you can just do nothing (type 'idle').");
            Console.WriteLine("Good luck!");
            Console.WriteLine();
            int totalSum = 0;
            Turn turn1 = new Turn(1, true, true, hand1, 0);
            turn1.MessageHandler += ShowOnConsole;
            Turn turn2 = new Turn(2, true, true, hand2, 0);
            turn2.MessageHandler += ShowOnConsole;
            while (totalSum < 60)
            {
                Console.WriteLine("Player 1, your turn\n");
                while (true)
                {
                    int madeTurn = turn1.MakeATurn(Console.ReadLine(), allcards, ref totalSum);
                    switch(madeTurn)
                    {
                        case 0:
                            break;
                        case 20:
                            turn2.lastTurn = turn1.lastTurn;
                            break;
                        case 30:
                            List<Card> hand1Backup = turn1.hand;
                            turn1.hand = turn2.hand;
                            turn2.hand = hand1Backup;
                            turn2.lastTurn = 0;
                            break;
                        case 40:
                            turn2.lastTurn = 0;
                            break;
                        default:
                            turn2.lastTurn = madeTurn;
                            break;
                    }
                    if (madeTurn != 0)
                    {
                        break;
                    }
                }
                if (totalSum >= 60)
                {
                    Console.WriteLine("Player 2 won!\n");
                    return;
                }
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"Total sum now: {totalSum}\n");
                Console.WriteLine("Player 1's cards:\n");
                foreach (Card card in turn1.hand)
                {
                    Console.WriteLine(card.value);
                }
                if (turn1.replicateAvaliable == true)
                {
                    Console.WriteLine("PowerUp 1: replicate other persons move");
                }
                if (turn1.changeAvaliable == true)
                {
                    Console.WriteLine("PowerUp 2: exchange decks with other person");
                }
                Console.WriteLine();
                Console.WriteLine("Player 2's cards:\n");
                foreach (Card card in turn2.hand)
                {
                    Console.WriteLine(card.value);
                }
                if (turn2.replicateAvaliable == true)
                {
                    Console.WriteLine("PowerUp 1: replicate other persons move");
                }
                if (turn2.changeAvaliable == true)
                {
                    Console.WriteLine("PowerUp 2: exchange decks with other person");
                }
                Console.WriteLine();
                Console.WriteLine("Player 2, your turn\n");
                while (true)
                {
                    int madeTurn = turn2.MakeATurn(Console.ReadLine(), allcards, ref totalSum);
                    switch (madeTurn)
                    {
                        case 0:
                            break;
                        case 20:
                            turn1.lastTurn = turn2.lastTurn;
                            break;
                        case 30:
                            List<Card> hand1Backup = turn1.hand;
                            turn1.hand = turn2.hand;
                            turn2.hand = hand1Backup;
                            turn1.lastTurn = 0;
                            break;
                        case 40:
                            turn1.lastTurn = 0;
                            break;
                        default:
                            turn1.lastTurn = madeTurn;
                            break;
                    }
                    if (madeTurn != 0)
                    {
                        break;
                    }
                }
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"Total sum now: {totalSum}\n");
                Console.WriteLine("Player 1's cards:\n");
                foreach (Card card in turn1.hand)
                {
                    Console.WriteLine(card.value);
                }
                if (turn1.replicateAvaliable == true)
                {
                    Console.WriteLine("PowerUp 1: replicate other persons move");
                }
                if (turn1.changeAvaliable == true)
                {
                    Console.WriteLine("PowerUp 2: exchange decks with other person");
                }
                Console.WriteLine();
                Console.WriteLine("Player 2's cards:\n");
                foreach (Card card in turn2.hand)
                {
                    Console.WriteLine(card.value);
                }
                if (turn2.replicateAvaliable == true)
                {
                    Console.WriteLine("PowerUp 1: replicate other persons move");
                }
                if (turn2.changeAvaliable == true)
                {
                    Console.WriteLine("PowerUp 2: exchange decks with other person");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Player 1 WON!\n");
        }
    }
}