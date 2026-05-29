using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    public List<Card> cards = new List<Card>();

    public Deck()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            for (int i = 1; i <= 13; i++)
            {
                cards.Add(new Card { suit = suit, number = i });
            }
        }
    }

    public void Shuffle()
    {
        System.Random rnd = new System.Random();
        cards = cards.OrderBy(x => rnd.Next()).ToList();
    }

    public Card Draw()
    {
        if (cards.Count == 0) return null;
        Card c = cards[0];
        cards.RemoveAt(0);
        return c;
    }
}
