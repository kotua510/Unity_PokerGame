using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class End_result_Manajer : MonoBehaviour
{
    public GameObject remo_p1;
    public GameObject remo_p2;
    public GameObject remo_p3;
    public GameObject remo_p4;
    public GameObject remo_bet1;
    public GameObject remo_bet2;
    public GameObject remo_bet3;
    public GameObject remo_bet4;
    public GameObject remo_most1;
    public GameObject remo_most2;
    public GameObject remo_most3;
    public GameObject remo_most4;
    public GameObject remo_mobint1;
    public GameObject remo_mobint2;
    public GameObject remo_mobint3;
    public GameObject remo_mobint4;
    public GameObject remo_moaint1;
    public GameObject remo_moaint2;
    public GameObject remo_moaint3;
    public GameObject remo_moaint4;
    public GameObject remo_arrow1;
    public GameObject remo_arrow2;
    public GameObject remo_arrow3;
    public GameObject remo_arrow4;
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        audioSource.clip = clickSound;
        remo_p1.SetActive(false);
    }

    public List<Player> players = new List<Player>();

    public void end_result1(List<Player> players)
    {
        foreach (Player p in players)
        {
            if (p.name == "player1")
            {
                remo_p1.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player2")
            {
                remo_p2.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player3")
            {
                remo_p3.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player4")
            {
                remo_p4.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
        }
    }

    public void end_result2(List<Player> players)
    {
        foreach (Player p in players)
        {
            if (p.name == "player1")
            {
                TextMeshProUGUI bet1 = remo_bet1.GetComponent<TextMeshProUGUI>();
                bet1.text = $"Bet : {p.bet_money1 + p.bet_money2}";
                remo_bet1.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player2")
            {
                TextMeshProUGUI bet2 = remo_bet2.GetComponent<TextMeshProUGUI>();
                bet2.text = $"Bet : {p.bet_money1 + p.bet_money2}";
                remo_bet2.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player3")
            {
                TextMeshProUGUI bet3 = remo_bet3.GetComponent<TextMeshProUGUI>();
                bet3.text = $"Bet : {p.bet_money1 + p.bet_money2}";
                remo_bet3.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player4")
            {
                TextMeshProUGUI bet4 = remo_bet4.GetComponent<TextMeshProUGUI>();
                bet4.text = $"Bet : {p.bet_money1 + p.bet_money2}";
                remo_bet4.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
        }
    }

    public void end_result3(List<Player> players)
    {
        foreach (Player p in players)
        {
            if (p.name == "player1")
            {
                TextMeshProUGUI bint1 = remo_mobint1.GetComponent<TextMeshProUGUI>();
                bint1.text = $"{p.bmoney}";
                remo_mobint1.SetActive(true);
                remo_most1.SetActive(true);
                remo_arrow1.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player2")
            {
                TextMeshProUGUI bint2 = remo_mobint2.GetComponent<TextMeshProUGUI>();
                bint2.text = $"{p.bmoney}";
                remo_mobint2.SetActive(true);
                remo_most2.SetActive(true);
                remo_arrow2.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player3")
            {
                TextMeshProUGUI bint3 = remo_mobint3.GetComponent<TextMeshProUGUI>();
                bint3.text = $"{p.bmoney}";
                remo_mobint3.SetActive(true);
                remo_most3.SetActive(true);
                remo_arrow3.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player4")
            {
                TextMeshProUGUI bint4 = remo_mobint4.GetComponent<TextMeshProUGUI>();
                bint4.text = $"{p.bmoney}";
                remo_mobint4.SetActive(true);
                remo_most4.SetActive(true);
                remo_arrow4.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
        }
    }

    public void end_result4(List<Player> players)
    {
        foreach (Player p in players)
        {
            if (p.name == "player1")
            {
                TextMeshProUGUI aint1 = remo_moaint1.GetComponent<TextMeshProUGUI>();
                aint1.text = $"{p.money}";
                remo_moaint1.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player2")
            {
                TextMeshProUGUI aint2 = remo_moaint2.GetComponent<TextMeshProUGUI>();
                aint2.text = $"{p.money}";
                remo_moaint2.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player3")
            {
                TextMeshProUGUI aint3 = remo_moaint3.GetComponent<TextMeshProUGUI>();
                aint3.text = $"{p.money}";
                remo_moaint3.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
            if (p.name == "player4")
            {
                TextMeshProUGUI aint4 = remo_moaint4.GetComponent<TextMeshProUGUI>();
                aint4.text = $"{p.money}";
                remo_moaint4.SetActive(true);
                audioSource.PlayOneShot(clickSound);
            }
        }
    }

    public void end_esult_reset()
    {
        remo_p1.SetActive(false);
        remo_p2.SetActive(false);
        remo_p3.SetActive(false);
        remo_p4.SetActive(false);
        remo_bet1.SetActive(false);
        remo_bet2.SetActive(false);
        remo_bet3.SetActive(false);
        remo_bet4.SetActive(false);
        remo_most1.SetActive(false);
        remo_most2.SetActive(false);
        remo_most3.SetActive(false);
        remo_most4.SetActive(false);
        remo_mobint1.SetActive(false);
        remo_mobint2.SetActive(false);
        remo_mobint3.SetActive(false);
        remo_mobint4.SetActive(false);
        remo_moaint1.SetActive(false);
        remo_moaint2.SetActive(false);
        remo_moaint3.SetActive(false);
        remo_moaint4.SetActive(false);
        remo_arrow1.SetActive(false);
        remo_arrow2.SetActive(false);
        remo_arrow3.SetActive(false);
        remo_arrow4.SetActive(false);
    }
}


