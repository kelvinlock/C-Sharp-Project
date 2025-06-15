using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GamesPlatform
{
    public class Deck
    {
        private Stack<Card> cards;
        private static Random rng = new Random();
        public Deck()
        {
            var list = new List<Card>();
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "A","2","3","4","5","6","7","8","9","10","J","Q","K" };
            foreach (var s in suits) foreach (var r in ranks) list.Add(new Card { Suit = s, Rank = r });
            cards = new Stack<Card>(list.OrderBy(_ => rng.Next()));
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                MessageBox.Show("牌堆沒牌了，不能再抽牌。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return cards.Pop();
        }
        public int CardsRemaining => cards.Count;
        public List<int> GetRemainingValues() => cards.Select(c => c.GetValue()).ToList();
    }
}
