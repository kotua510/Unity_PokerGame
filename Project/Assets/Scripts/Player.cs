using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public string name;
    public List<Card> hand = new List<Card>();
    public int money;
    public int bet_money1 = 0;
    public int bet_money2 = 0;
    public int bmoney;

    public Player(string name, int money = 1000, int bet_money1 = 0, int bet_money2 = 0, int bmoney = 1000)
    {
        this.name = name;
        this.money = money;
        this.bet_money1 = bet_money1;
        this.bet_money2 = bet_money2;
        this.bmoney = bmoney;
    }

    public void DrawCard(Deck deck)
    {
        Card drawn = deck.Draw();
        if (drawn != null)
        {
            hand.Add(drawn);
            Debug.Log($"{name} ‚Í {drawn.suit} ‚Ì {drawn.number} ‚ðˆø‚¢‚½");
        }
    }

    public void ShowHand()
    {
        string handStr = string.Join(", ", hand.Select(c => $"{c.suit}{c.number}"));
        Debug.Log($"{name} ‚ÌŽèŽD: {handStr}");
    }

    public void Choise1()
    {
        
    }

    public void Bet1(int amount)
    {
        if (money >= amount)
        {
            bet_money1 += amount;
            money -= amount;
        }   
    }

    public void dis_Bet1(int amount)
    {
        if (0 < bet_money1)
        {
            bet_money1 -= amount;
            if (bet_money1 < 0)
            {
                amount += bet_money1;
                bet_money1 = 0;
            }
            money += amount;
            Debug.Log($"{name} ‚Í {amount} ƒxƒbƒg‚µ‚½ Žc‹à: {money}");
        }
        else
        {
            Debug.Log($"Š|‚¯‹à‚Í0");
        }
    }

    public void Bet2(int amount)
    {
        if (money >= amount)
        {

            bet_money2 += amount;
            money -= amount;
        }  
    }

    public void dis_Bet2(int amount)
    {
        if (0 < bet_money2)
        {

            bet_money2 -= amount;
            if (bet_money2 < 0)
            {
                amount += bet_money2;
                bet_money2 = 0;
            }
            money += amount;
        }
        else
        {
            Debug.Log($"Š|‚¯‹à‚Í0");
        }
    }
}

