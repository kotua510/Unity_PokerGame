using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum HandRank
{
    HighCard = 1,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFlush
}

public class HandResult
{
    public HandRank rank;
    public List<int> mainValues;
    public List<int> kickers;    
}

public static class HandEvaluator
{
    public static HandResult Evaluate(List<Card> hand)
    {
        var result = new HandResult();
        var suits = hand.Select(c => c.suit).ToList();
        var nums = hand.Select(c => c.number == 1 ? 14 : c.number).OrderBy(n => n).ToList(); // A‚ğ1‚©14‚Æ‚µ‚Äˆµ‚¤

        bool isFlush = suits.Distinct().Count() == 1;
        bool isStraight = IsStraight(nums);

        var groups = hand
            .GroupBy(c => c.number == 1 ? 14 : c.number)
            .OrderByDescending(g => g.Count())
            .ThenByDescending(g => g.Key)
            .ToList();

        int maxCount = groups[0].Count();

        // –ğ‚Ì”»’è
        if (isFlush && isStraight && nums.Max() == 14 && nums.Min() == 10)
        {
            result.rank = HandRank.RoyalFlush;
            result.mainValues = new List<int> { 14 };
        }
        else if (isFlush && isStraight)
        {
            result.rank = HandRank.StraightFlush;
            result.mainValues = new List<int> { nums.Max() };
        }
        else if (maxCount == 4)
        {
            result.rank = HandRank.FourOfAKind;
            result.mainValues = new List<int> { groups[0].Key };
            result.kickers = groups.Skip(1).SelectMany(g => g).Select(c => c.number).ToList();
        }
        else if (maxCount == 3 && groups.Count == 2)
        {
            result.rank = HandRank.FullHouse;
            result.mainValues = new List<int> { groups[0].Key, groups[1].Key };
        }
        else if (isFlush)
        {
            result.rank = HandRank.Flush;
            result.mainValues = nums.OrderByDescending(n => n).ToList();
        }
        else if (isStraight)
        {
            result.rank = HandRank.Straight;
            result.mainValues = new List<int> { nums.Max() };
        }
        else if (maxCount == 3)
        {
            result.rank = HandRank.ThreeOfAKind;
            result.mainValues = new List<int> { groups[0].Key };
            result.kickers = groups.Skip(1).SelectMany(g => g).Select(c => c.number).OrderByDescending(n => n).ToList();
        }
        else if (maxCount == 2 && groups.Count == 3)
        {
            result.rank = HandRank.TwoPair;
            result.mainValues = groups.Where(g => g.Count() == 2).Select(g => g.Key).OrderByDescending(n => n).ToList();
            result.kickers = groups.Where(g => g.Count() == 1).SelectMany(g => g).Select(c => c.number).ToList();
        }
        else if (maxCount == 2)
        {
            result.rank = HandRank.OnePair;
            result.mainValues = new List<int> { groups[0].Key };
            result.kickers = groups.Skip(1).SelectMany(g => g).Select(c => c.number).OrderByDescending(n => n).ToList();
        }
        else
        {
            result.rank = HandRank.HighCard;
            result.mainValues = nums.OrderByDescending(n => n).ToList();
        }

        return result;
    }

    private static bool IsStraight(List<int> nums)
    {
        var sorted = nums.Distinct().OrderBy(n => n).ToList();

        if (sorted.Count != 5)
            return false;

       bool normal = sorted[4] - sorted[0] == 4;

        bool wheel = sorted.Contains(14) && sorted[0] == 2 && sorted[3] == 5;

        return normal || wheel;
    }

    public static int CompareHands(Player a, Player b)
    {
        var handA = Evaluate(a.hand);
        var handB = Evaluate(b.hand);

        // –ğ‚Ì‹­‚³‚ğ”äŠr
        if (handA.rank != handB.rank)
            return handA.rank.CompareTo(handB.rank);

        // ƒƒCƒ“’l‚ğ”äŠr
        for (int i = 0; i < Mathf.Min(handA.mainValues.Count, handB.mainValues.Count); i++)
        {
            if (handA.mainValues[i] != handB.mainValues[i])
                return handA.mainValues[i].CompareTo(handB.mainValues[i]);
        }

        if (handA.kickers != null && handB.kickers != null)
        {
            for (int i = 0; i < Mathf.Min(handA.kickers.Count, handB.kickers.Count); i++)
            {
                if (handA.kickers[i] != handB.kickers[i])
                    return handA.kickers[i].CompareTo(handB.kickers[i]);
            }
        }

        // Š®‘S‚É“¯‚¶‚È‚çˆø‚«•ª‚¯
        return 0;
    }
}
