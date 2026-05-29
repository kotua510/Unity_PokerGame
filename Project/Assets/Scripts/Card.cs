using UnityEngine;
using System;

[Serializable]
public class Card
{
    public Suit suit;
    public int number;
    public bool isFaceUp;
}

public enum Suit { Spade, Heart, Diamond, Club }

