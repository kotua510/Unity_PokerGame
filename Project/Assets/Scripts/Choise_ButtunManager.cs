using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Choise_ButtunManager : MonoBehaviour
{
    public GameObject buttonPrefab; 
    public Transform buttonParent;  
    public GameObject buttonPrefab_bet;
    public GameObject buttonPrefab_up;
    public GameObject buttonPrefab_down;
    public GameObject buttonPrefab_up2;
    public GameObject buttonPrefab_down2;
    public GameObject buttonPrefab_up3;
    public GameObject buttonPrefab_down3;
    public GameObject trump1;
    public GameObject trump2;
    public GameObject trump3;
    public GameObject trump4;
    public GameObject trump5;
    public GameObject text1Prefab;
    public GameObject text2Prefab;
    public GameObject text3Prefab;
    public GameObject text4Prefab;
    public AudioClip clickSound;
    private AudioSource audioSource;
    private GameObject resultText;
    public GameObject bet_money1Prefab;

    public string selectedValue = null;
    private bool decade_value = false;
    private bool chanbtn_value = false;
    private bool change_value = false;
    private bool[] change_trumps = new bool[5];
    public string SelectedValue => selectedValue;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        audioSource.clip = clickSound;
        
    }
    public GameObject CreateButton(string index, Player player, int bettrun)
    {
        GameObject newButton = Instantiate(buttonPrefab, buttonParent);
        newButton.name = $"Button{index}";
        Text buttonText = newButton.GetComponentInChildren<Text>();
        buttonText.text = $"{index}";
        RectTransform rect = newButton.GetComponent<RectTransform>();
        Button btn = newButton.GetComponent<Button>();

        switch (index)
        {
            case "bet":
                rect.anchoredPosition = new Vector2(-500, -300);
                btn.onClick.AddListener(() => {
                    audioSource.PlayOneShot(clickSound);
                    OnButtonClicked(index, player, bettrun);
                });
                break;

            case "pass":
                rect.anchoredPosition = new Vector2(500, -300);
                btn.onClick.AddListener(() => {
                    audioSource.PlayOneShot(clickSound);
                    OnButtonClicked(index, player, bettrun);
                });
                break;

            case "drop":
                rect.anchoredPosition = new Vector2(0, -300);
                btn.onClick.AddListener(() => {
                    audioSource.PlayOneShot(clickSound);
                    OnButtonClicked(index, player, bettrun);
                });
                break;
        }

        return newButton;
    }






    public void CreateButton_bet(string bet_money, Player player, int bettrun)
    {
        GameObject newButton_bet = Instantiate(buttonPrefab_bet, buttonParent);
        newButton_bet.name = $"Button bet";

        GameObject newButton_up = Instantiate(buttonPrefab_up, buttonParent);
        newButton_up.name = $"Button up";

        GameObject newButton_down = Instantiate(buttonPrefab_down, buttonParent);
        newButton_down.name = $"Button down";

        GameObject newButton_up2 = Instantiate(buttonPrefab_up2, buttonParent);
        newButton_up2.name = $"Button up";

        GameObject newButton_down2 = Instantiate(buttonPrefab_down2, buttonParent);
        newButton_down2.name = $"Button down";

        GameObject newButton_up3 = Instantiate(buttonPrefab_up3, buttonParent);
        newButton_up3.name = $"Button up";

        GameObject newButton_down3 = Instantiate(buttonPrefab_down3, buttonParent);
        newButton_down3.name = $"Button down";


        Button btn_bet = newButton_bet.GetComponent<Button>();
        btn_bet.onClick.AddListener(() => {
            audioSource.PlayOneShot(clickSound);
            OnButtonClicked_bet(player,newButton_bet,newButton_up,newButton_down, newButton_up2, newButton_down2, newButton_up3, newButton_down3);
            Debug.Log($"{player.name} はbetした");
        });

        Button btn_up = newButton_up.GetComponent<Button>();
        btn_up.onClick.AddListener(() => {
            OnButtonClicked_up(player, newButton_bet, bettrun);
            audioSource.PlayOneShot(clickSound);
        });

        Button btn_down = newButton_down.GetComponent<Button>();
        btn_down.onClick.AddListener(() => {
            audioSource.PlayOneShot(clickSound);
            OnButtonClicked_down(player, newButton_bet, bettrun);
        });

        Button btn_up2 = newButton_up2.GetComponent<Button>();
        btn_up2.onClick.AddListener(() => {
            OnButtonClicked_up2(player, newButton_bet, bettrun);
            audioSource.PlayOneShot(clickSound);
        });

        Button btn_down2 = newButton_down2.GetComponent<Button>();
        btn_down2.onClick.AddListener(() => {
            audioSource.PlayOneShot(clickSound);
            OnButtonClicked_down2(player, newButton_bet, bettrun);
        });

        Button btn_up3 = newButton_up3.GetComponent<Button>();
        btn_up3.onClick.AddListener(() => {
            OnButtonClicked_up3(player, newButton_bet, bettrun);
            audioSource.PlayOneShot(clickSound);
        });

        Button btn_down3 = newButton_down3.GetComponent<Button>();
        btn_down3.onClick.AddListener(() => {
            audioSource.PlayOneShot(clickSound);
            OnButtonClicked_down3(player, newButton_bet, bettrun);
        });


    }

    public void OnButtonClicked(string value, Player player,int bettrun)
    {
        selectedValue = value;
        Debug.Log($"ボタン {value} が押された");

        switch (selectedValue)
        {
            case "bet":
                // BET用の金額ボタンなどを生成
                CreateButton_bet("100", player, bettrun);
                break;

            case "pass":
                Debug.Log($"{player.name} はパスした");
                break;

            case "drop":
                Debug.Log($"{player.name} はドロップした");
                break;
        }
    }

    public void OnButtonClicked_bet(Player player, GameObject newButton_bet, GameObject newButton_up, GameObject newButton_down, GameObject newButton_up2, GameObject newButton_down2, GameObject newButton_up3, GameObject newButton_down3)
    {
        Debug.Log($"betが押された");

        decade_value = true;
            Destroy(newButton_bet);
        Destroy(newButton_up);
        Destroy(newButton_down);
        Destroy(newButton_up2);
        Destroy(newButton_down2);
        Destroy(newButton_up3);
        Destroy(newButton_down3);
    }

    public void OnButtonClicked_up(Player player, GameObject newButton_bet, int bettrun)
    {
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        Debug.Log($"upが押された");
        if (bettrun == 1)
        {
            player.Bet1(10);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.Bet2(10);
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public void OnButtonClicked_up2(Player player, GameObject newButton_bet, int bettrun)
    {
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        Debug.Log($"upが押された");
        if (bettrun == 1)
        {
            player.Bet1(100);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.Bet2(100);
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public void OnButtonClicked_up3(Player player, GameObject newButton_bet, int bettrun)
    {
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        Debug.Log($"upが押された");
        if (bettrun == 1)
        {
            player.Bet1(1000);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.Bet2(1000);
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public void OnButtonClicked_down(Player player, GameObject newButton_bet, int bettrun)
    {
        Debug.Log($"downが押された");
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        if (bettrun == 1)
        {
            player.dis_Bet1(10);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.dis_Bet2(10); 
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public void OnButtonClicked_down2(Player player, GameObject newButton_bet, int bettrun)
    {
        Debug.Log($"downが押された");
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        if (bettrun == 1)
        {
            player.dis_Bet1(100);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.dis_Bet2(100);
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public void OnButtonClicked_down3(Player player, GameObject newButton_bet, int bettrun)
    {
        Debug.Log($"downが押された");
        Text buttonText = newButton_bet.GetComponentInChildren<Text>();
        if (bettrun == 1)
        {
            player.dis_Bet1(1000);
            buttonText.text = ($"{player.bet_money1}");
        }
        else if (bettrun == 2)
        {
            player.dis_Bet2(1000);
            buttonText.text = ($"{player.bet_money2}");
        }
    }

    public IEnumerator WaitForButtonPress0()
    {
        yield return new WaitUntil(() => selectedValue == "bet" || selectedValue == "pass" || selectedValue == "drop");
    }

    public IEnumerator WaitForButtonPress()
    {
        yield return new WaitUntil(() => selectedValue == "pass" || decade_value == true || selectedValue == "drop");
        Debug.Log($"選ばれた値: {selectedValue} / 決定: {decade_value}");
    }
    public void ResetSelection()
    {
        selectedValue = null;
        decade_value = false;
    }

    public GameObject CreateChanButtun(string index, Player player)
    {
        GameObject newchanbuttun = Instantiate(buttonPrefab, buttonParent);
        newchanbuttun.name = $"Button{index}";
        Text decadeText = newchanbuttun.GetComponentInChildren<Text>();
        decadeText.text = $"{index}";
        RectTransform rect = newchanbuttun.GetComponent<RectTransform>();
        // indexによって座標を切り替える
        switch (index)
        {
            case "change":
                rect.anchoredPosition = new Vector2(-500, -300);
                Button chanBtn = newchanbuttun.GetComponent<Button>();
                chanBtn.onClick.AddListener(() =>
                {
                    OnButtonClicked_change(player);
                    audioSource.PlayOneShot(clickSound);
                });

                break;
            case "pass":
                rect.anchoredPosition = new Vector2(500, -300);
                Button passBtn = newchanbuttun.GetComponent<Button>();
                passBtn.onClick.AddListener(() =>
                {
                    OnButtonClicked_chanpass(index, player);
                    audioSource.PlayOneShot(clickSound);
                });
                break;
            default:

                break;
        }

        return newchanbuttun;
    }

public List<GameObject> CreateButtonTrump(Player player)
{
        List<GameObject> createdTrumpButtons = new List<GameObject>();
        for (int i = 0; i < player.hand.Count; i++)
    {
            GameObject prefabToUse = null;

            if (i == 0) prefabToUse = trump1;
            else if (i == 1) prefabToUse = trump2;
            else if (i == 2) prefabToUse = trump3;
            else if (i == 3) prefabToUse = trump4;
            else if (i == 4) prefabToUse = trump5;

            GameObject newTrump = Instantiate(prefabToUse, buttonParent);

            Card card = player.hand[i];

        string path = "";
        

            if (card.suit == Suit.Spade)
            {
                if (card.number == 1)
                {
                    path = "trump_image/s_1";
                }
                else if (card.number == 2)
                {
                    path = "trump_image/s_2";
                }
                else if (card.number == 3)
                {
                    path = "trump_image/s_3";
                }
                else if (card.number == 4)
                {
                    path = "trump_image/s_4";
                }
                else if (card.number == 5)
                {
                    path = "trump_image/s_5";
                }
                else if (card.number == 6)
                {
                    path = "trump_image/s_6";
                }
                else if (card.number == 7)
                {
                    path = "trump_image/s_7";
                }
                else if (card.number == 8)
                {
                    path = "trump_image/s_8";
                }
                else if (card.number == 9)
                {
                    path = "trump_image/s_9";
                }
                else if (card.number == 10)
                {
                    path = "trump_image/s_10";
                }
                else if (card.number == 11)
                {
                    path = "trump_image/s_11";
                }
                else if (card.number == 12)
                {
                    path = "trump_image/s_12";
                }
                else if (card.number == 13)
                {
                    path = "trump_image/s_13";
                }

            }
            else if (card.suit == Suit.Heart)
            {
                if (card.number == 1)
                {
                    path = "trump_image/h_1";
                }
                else if (card.number == 2)
                {
                    path = "trump_image/h_2";
                }
                else if (card.number == 3)
                {
                    path = "trump_image/h_3";
                }
                else if (card.number == 4)
                {
                    path = "trump_image/h_4";
                }
                else if (card.number == 5)
                {
                    path = "trump_image/h_5";
                }
                else if (card.number == 6)
                {
                    path = "trump_image/h_6";
                }
                else if (card.number == 7)
                {
                    path = "trump_image/h_7";
                }
                else if (card.number == 8)
                {
                    path = "trump_image/h_8";
                }
                else if (card.number == 9)
                {
                    path = "trump_image/h_9";
                }
                else if (card.number == 10)
                {
                    path = "trump_image/h_10";
                }
                else if (card.number == 11)
                {
                    path = "trump_image/h_11";
                }
                else if (card.number == 12)
                {
                    path = "trump_image/h_12";
                }
                else if (card.number == 13)
                {
                    path = "trump_image/h_13";
                }
            }
            else if (card.suit == Suit.Diamond)
            {
                if (card.number == 1)
                {
                    path = "trump_image/d_1";
                }
                else if (card.number == 2)
                {
                    path = "trump_image/d_2";
                }
                else if (card.number == 3)
                {
                    path = "trump_image/d_3";
                }
                else if (card.number == 4)
                {
                    path = "trump_image/d_4";
                }
                else if (card.number == 5)
                {
                    path = "trump_image/d_5";
                }
                else if (card.number == 6)
                {
                    path = "trump_image/d_6";
                }
                else if (card.number == 7)
                {
                    path = "trump_image/d_7";
                }
                else if (card.number == 8)
                {
                    path = "trump_image/d_8";
                }
                else if (card.number == 9)
                {
                    path = "trump_image/d_9";
                }
                else if (card.number == 10)
                {
                    path = "trump_image/d_10";
                }
                else if (card.number == 11)
                {
                    path = "trump_image/d_11";
                }
                else if (card.number == 12)
                {
                    path = "trump_image/d_12";
                }
                else if (card.number == 13)
                {
                    path = "trump_image/d_13";
                }
            }
            else if (card.suit == Suit.Club)
            {
                if (card.number == 1)
                {
                    path = "trump_image/k_1";
                }
                else if (card.number == 2)
                {
                    path = "trump_image/k_2";
                }
                else if (card.number == 3)
                {
                    path = "trump_image/k_3";
                }
                else if (card.number == 4)
                {
                    path = "trump_image/k_4";
                }
                else if (card.number == 5)
                {
                    path = "trump_image/k_5";
                }
                else if (card.number == 6)
                {
                    path = "trump_image/k_6";
                }
                else if (card.number == 7)
                {
                    path = "trump_image/k_7";
                }
                else if (card.number == 8)
                {
                    path = "trump_image/k_8";
                }
                else if (card.number == 9)
                {
                    path = "trump_image/k_9";
                }
                else if (card.number == 10)
                {
                    path = "trump_image/k_10";
                }
                else if (card.number == 11)
                {
                    path = "trump_image/k_11";
                }
                else if (card.number == 12)
                {
                    path = "trump_image/k_12";
                }
                else if (card.number == 13)
                {
                    path = "trump_image/k_13";
                }
            }

            Sprite cardSprite = Resources.Load<Sprite>(path);

            if (cardSprite == null)
        {
            Debug.LogWarning($"カード画像がない: {path}");
        }

        Image buttonImage = newTrump.GetComponent<Image>();
        if (buttonImage != null && cardSprite != null)
        {
            buttonImage.sprite = cardSprite;
        }

        Text buttonText = newTrump.GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = "";
        }

        int index = i;
        Button button = newTrump.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnTrumpButtonClicked(player, index));
        }

            createdTrumpButtons.Add(newTrump);
        }
        return createdTrumpButtons;
    }


public void OnTrumpButtonClicked(Player player, int index)
    {
       change_trumps[index] = !change_trumps[index];
        Debug.Log($"トランプ{index}のboolは{change_trumps[index]}");
    }

    public void OnTrumpButton_reset(Player player)
    {
        for (int i = 4; i >= 0; i--)
        {
            change_trumps[i] = false;
        }
    }

    public void OnButtonClicked_change(Player player)
    {
        for (int i = 4; i >= 0; i--)
        {
            if (change_trumps[i])
            {
                player.hand.RemoveAt(i);
                player.DrawCard(GameManager.Instance.deck);
            }
        }

        foreach (Card c in player.hand)
        {
            Debug.Log($"{c.suit} の {c.number}");
        }
        change_value = true;

    }

    public void OnButtonClicked_chanpass(string value, Player player)
    {
        Debug.Log($"{value} が押された");
        Debug.Log($"{player.name} は交換をパスした");
        chanbtn_value = true;
    }


    public IEnumerator WaitForButtonPress_trump()
    {
        yield return new WaitUntil(() => chanbtn_value == true || change_value == true);
    }

    public void ResetSelection_trump()
    {
        chanbtn_value = false;
        change_value = false;

    }

    public GameObject bet_text()
    {
        GameObject newText = Instantiate(text1Prefab, buttonParent);
        return newText;
    }

    public GameObject bet_text2()
    {
        GameObject newText2 = Instantiate(text3Prefab, buttonParent);
        return newText2;
    }

    public void result_text( string winner, HandRank hand_rank )
    {
        resultText = Instantiate(text4Prefab, buttonParent);

        TextMeshProUGUI tmp = resultText.GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = $"Winner :{winner}\nhand    : {hand_rank}";

    }

    public void result_text0()
    {
        resultText = Instantiate(text4Prefab, buttonParent);

        TextMeshProUGUI tmp = resultText.GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = $"Winner : No one there\nhand    : nothing";

    }

    public void result_text_reset()
    {
        resultText.SetActive(false);
    }


    public GameObject chan_text()
    {
        GameObject chanText = Instantiate(text2Prefab, buttonParent);
        return chanText;
    }

    public List<GameObject> bet_money_text()
    {
        // 戻り値用のリストを作成
        List<GameObject> createdTexts = new List<GameObject>();

        // プレイヤーリストを取得
        List<Player> players = GameManager.Instance.players;

        Vector2 startPos = new Vector2(-500, 310);

        for (int i = 0; i < players.Count; i++)
        {
            Player player = players[i];
            GameObject betMoneyTextObj = Instantiate(bet_money1Prefab, buttonParent);
            betMoneyTextObj.name = $"BetMoneyText_{player.name}";

            TextMeshProUGUI textUI = betMoneyTextObj.GetComponent<TextMeshProUGUI>();
            textUI.text = $"{player.name}\nBet : {player.bet_money1 + player.bet_money2}\nmoney : {player.money} ";

            RectTransform rect = betMoneyTextObj.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(startPos.x + (350 * i), startPos.y);

            // 作ったオブジェクトをリストに追加
            createdTexts.Add(betMoneyTextObj);
        }

        return createdTexts;
    }







}