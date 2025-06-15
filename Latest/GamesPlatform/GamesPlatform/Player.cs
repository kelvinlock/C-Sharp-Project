using System.Collections.Generic;

namespace GamesPlatform
{
    public class Player
    {
        public List<Card> Hand { get; } = new List<Card>();
        public void AddCard(Card c) => Hand.Add(c);
        public int GetScore()
        {
            int sum = 0, aces = 0;
            foreach (var c in Hand)
            { sum += c.GetValue(); if (c.Rank == "A") aces++; }
            while (sum > 21 && aces-- > 0) sum -= 10;
            return sum;
        }
    }
}
