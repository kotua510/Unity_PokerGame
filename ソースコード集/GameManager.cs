using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ButtonManager buttonManager;
    public Choise_ButtunManager c_BM;
    public End_result_Manajer e_r;
    public Trump t_p;
    public Change_player c_p;
    public Animator_Manager a_m1;
    public Animator_Manager a_m2;
    public Animator_Manager a_m3;
    public Animator_Manager a_m4;

    public Canvas canvas;
    public Canvas canvas2;

    public FadeInImage image11;
    public FadeInImage image12;
    public FadeInImage image13;
    public FadeInImage image14;
    public FadeInImage image15;
    public FadeInImage image21;
    public FadeInImage image22;
    public FadeInImage image23;
    public FadeInImage image24;
    public FadeInImage image25;
    public FadeInImage image31;
    public FadeInImage image32;
    public FadeInImage image33;
    public FadeInImage image34;
    public FadeInImage image35;
    public FadeInImage image41;
    public FadeInImage image42;
    public FadeInImage image43;
    public FadeInImage image44;
    public FadeInImage image45;

    public GameObject playerre1;
    public GameObject playerre2;
    public GameObject playerre3;
    public GameObject playerre4;

    public GameObject end_button1;
    public GameObject end_button2;

    public int player1rastmoney = 1000;
    public int player2rastmoney = 1000;
    public int player3rastmoney = 1000;
    public int player4rastmoney = 1000;

    public RetryButton1 retryButton1;
    public RetryButton2 retryButton2;

    public List<Player> players = new List<Player>();
    public static GameManager Instance;
    public Deck deck;
    List<Player> toRemove = new List<Player>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        deck = new Deck();
        deck.Shuffle();
        StartCoroutine(GameLoop());
    }

    public (string winnername, int winnerIndex, HandResult winnerHand) GetWinnerInfo(List<Player> players)
    {
        if (players == null || players.Count == 0)
            return (null, -1, null);

        if (players.Count == 1)
        {
            var onlyPlayer = players[0];
            var onlyHand = HandEvaluator.Evaluate(onlyPlayer.hand);
            return (onlyPlayer.name, 1, onlyHand); // Indexを1からスタートとする
        }

        string winnername = players[0].name;
        int winnerIndex = 0;
        HandResult winnerHand = HandEvaluator.Evaluate(players[0].hand);

        for (int i = 1; i < players.Count; i++)
        {
            var currentHand = HandEvaluator.Evaluate(players[i].hand);
            int result = HandEvaluator.CompareHands(players[winnerIndex], players[i]);

            if (result < 0)
            {
                winnerIndex = i;
                winnerHand = currentHand;
            }
        }

        winnername = players[winnerIndex].name;
        return (winnername, winnerIndex + 1, winnerHand);
    }

    IEnumerator WaitForRetry(RetryButton1 retryButton1, RetryButton2 retryButton2, System.Action<bool> onResult)
    {
        while (!retryButton1.isPressed1 && !retryButton2.isPressed2)
        {
            yield return null;
        }

        // どちらが押されたか
        bool isRetry = retryButton1.isPressed1;
        onResult?.Invoke(isRetry);
    }

    IEnumerator GameLoop()
    {
        while (true)
        {   

        Debug.Log("ゲーム開始");
        // ボタンが押されるまで待機
        yield return StartCoroutine(buttonManager.WaitForButtonPress());

        // 押されたボタンの値を取得
        int chosenValue = buttonManager.SelectedValue;

        Debug.Log("プレイヤー生成");
        for (int i = 1; i <= chosenValue; i++)
        {
            players.Add(new Player("player" + i));
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = players.Count - 1; j >= 0; j--)
            {
                players[j].DrawCard(deck);
            }
        }

        int playersint = players.Count;
        if (playersint == 1)
        {
            a_m1.PlayAnimationMultiple("p1_in", 5, 1.0f);
        }
        if (playersint == 2)
        {
            a_m1.PlayAnimationMultiple("p1_in", 5, 1.0f);
            a_m2.PlayAnimationMultiple("p2_in", 5, 1.0f);
        }
        if (playersint == 3)
        {
            a_m1.PlayAnimationMultiple("p1_in", 5, 1.0f);
            a_m2.PlayAnimationMultiple("p2_in", 5, 1.0f);
            a_m3.PlayAnimationMultiple("p3_in", 5, 1.0f);
        }
        if (playersint == 4)
        {
            a_m1.PlayAnimationMultiple("p1_in", 5, 1.0f);
            a_m2.PlayAnimationMultiple("p2_in", 5, 1.0f);
            a_m3.PlayAnimationMultiple("p3_in", 5, 1.0f);
            a_m4.PlayAnimationMultiple("p4_in", 5, 1.0f);
        }
        

        yield return new WaitForSeconds(6.0f);

            a_m1.Animation_object_reset();
            a_m2.Animation_object_reset();
            a_m3.Animation_object_reset();
            a_m4.Animation_object_reset();


            for (int i = players.Count - 1; i >= 0; i--)
        {
            players[i].ShowHand();
        }

        foreach (var p in players.ToList())
        {
            if (p.name == "player1")
            {
                p.money = player1rastmoney;
                }   
            if (p.name == "player2")
            {
                p.money = player2rastmoney;
            }
            if (p.name == "player3")
            {
                p.money = player3rastmoney;
            }
            if (p.name == "player4")
            {
                p.money = player4rastmoney;
            }
        }

        List<Player> toRemove = new List<Player>();

            // 以下BETフェーズ
            toRemove.Clear();

        int index = 1;
        foreach (var p in players.ToList())
        {
                
            c_p.ResetSelection();
            c_p.confi_player(p);
            yield return StartCoroutine(c_p.WaitForButtonPress());

            c_BM.ResetSelection();
            List<GameObject> betTexts = c_BM.bet_money_text();
            t_p.trumpmade(p);
            var bettext = c_BM.bet_text();
            var betButton =  c_BM.CreateButton("bet", p, 1);
            var passButton = c_BM.CreateButton("pass", p, 1);
            var dropButton = c_BM.CreateButton("drop", p, 1);
                yield return StartCoroutine(c_BM.WaitForButtonPress0());
                if (c_BM.selectedValue == "bet")
                {
                    Destroy(betButton);
                    Destroy(passButton);
                    Destroy(dropButton);
                    yield return StartCoroutine(c_BM.WaitForButtonPress());
                }
                // pass か drop の処理
                else
                {
                    Destroy(betButton);
                    Destroy(passButton);
                    Destroy(dropButton);
                }
                t_p.trumpdelete();
                foreach (var txt in betTexts)
                {
                    Destroy(txt);
                }
                Destroy(bettext);

                if (c_BM.SelectedValue == "pass")
            {
                Debug.Log($"{p.name} はパスした");
            }
            else if (c_BM.SelectedValue == "drop")
            {
                Debug.Log($"{p.name} はdropした");
                toRemove.Add(p);
            }

            index++;
        }

        foreach (var p in toRemove)
        {
            players.Remove(p);
                if (p.name == "player1")
                {
                    player1rastmoney = p.money;
                }
                if (p.name == "player2")
                {
                    player2rastmoney = p.money;
                }
                if (p.name == "player3")
                {
                    player3rastmoney = p.money;
                }
                if (p.name == "player4")
                {
                    player4rastmoney = p.money;
                }
            }

        

        // 以下交換フェーズ
        toRemove.Clear();

        index = 1;
        foreach (var p in players.ToList())
        {
            c_p.ResetSelection();
            c_p.confi_player(p);
            yield return StartCoroutine(c_p.WaitForButtonPress());

            c_BM.ResetSelection_trump();
            c_BM.OnTrumpButton_reset(p);
                List<GameObject> betTexts =  c_BM.bet_money_text();
            var chantext = c_BM.chan_text();
            var chanbutton1 = c_BM.CreateChanButtun("change", p);
            var chanbutton2 = c_BM.CreateChanButtun("pass", p);
                List<GameObject> trumpButtons =  c_BM.CreateButtonTrump(p);
            yield return StartCoroutine(c_BM.WaitForButtonPress_trump());

                Destroy(chanbutton1);
                Destroy(chanbutton2);
                foreach (var txt in betTexts)
                {
                    Destroy(txt);
                }
                foreach (var btn in trumpButtons)
                {
                    Destroy(btn);
                }
                Destroy(chantext);

                index++;
        }

        // 最終BETフェーズ
        toRemove.Clear();

        index = 1;
        foreach (var p in players.ToList())
        {
            c_p.ResetSelection();
            c_p.confi_player(p);
            yield return StartCoroutine(c_p.WaitForButtonPress());

            c_BM.ResetSelection();
            List<GameObject> betTexts2 = c_BM.bet_money_text();
            t_p.trumpmade(p);
            var bet_text2 = c_BM.bet_text2();
            var betButton2 = c_BM.CreateButton("bet", p, 2);
            var dropButton2 = c_BM.CreateButton("drop", p, 2);
                yield return StartCoroutine(c_BM.WaitForButtonPress0());
                if (c_BM.selectedValue == "bet")
                {
                    Destroy(betButton2);
                    Destroy(dropButton2);
                    yield return StartCoroutine(c_BM.WaitForButtonPress());
                }
                else
                {
                    Destroy(betButton2);
                    Destroy(dropButton2);
                }
                t_p.trumpdelete();

                if (c_BM.SelectedValue == "drop")
            {
                Debug.Log($"{p.name} はdropした");
                toRemove.Add(p);
            }
            else
            {
                Debug.Log($"{p.name} はベットした");
            }
                foreach (var txt in betTexts2)
                {
                    Destroy(txt);
                }
                Destroy(bet_text2);

                index++;
        }

        foreach (var p in toRemove)
        {
            players.Remove(p);
                if (p.name == "player1")
                {
                    player1rastmoney = p.money;
                }
                if (p.name == "player2")
                {
                    player2rastmoney = p.money;
                }
                if (p.name == "player3")
                {
                    player3rastmoney = p.money;
                }
                if (p.name == "player4")
                {
                    player4rastmoney = p.money;
                }
            }


        int playerscount = players.Count;
            Debug.Log($"残りプレイヤー数: {playerscount}");
            if (playerscount != 0 )
            {
                foreach (Player p in players)
                {
                    if (p.name == "player1")
                    {
                        playerre1.SetActive(true);
                        image11 = Instantiate(image11, canvas2.transform);
                        image11.gameObject.SetActive(true);
                        image11.StartFadeIn(p.hand[0].suit, p.hand[0].number);
                    }
                    if (p.name == "player3")
                    {

                        playerre3.SetActive(true);
                        image21 = Instantiate(image21, canvas2.transform);
                        image21.gameObject.SetActive(true);
                        image21.StartFadeIn(p.hand[0].suit, p.hand[0].number);
                    }
                    if (p.name == "player2")
                    {
                        playerre2.SetActive(true);
                        image31 = Instantiate(image31, canvas2.transform);
                        image31.gameObject.SetActive(true);
                        image31.StartFadeIn(p.hand[0].suit, p.hand[0].number);
                    }
                    if (p.name == "player4")
                    {
                        playerre4.SetActive(true);
                        image41 = Instantiate(image41, canvas2.transform);
                        image41.gameObject.SetActive(true);
                        image41.StartFadeIn(p.hand[0].suit, p.hand[0].number);
                    }
                }


                yield return new WaitForSeconds(1.0f);

                foreach (Player p in players)
                {
                    if (p.name == "player1")
                    {
                        image12 = Instantiate(image12, canvas2.transform);
                        image12.gameObject.SetActive(true);
                        image12.StartFadeIn(p.hand[1].suit, p.hand[1].number);
                    }
                    if (p.name == "player3")
                    {

                        image22 = Instantiate(image22, canvas2.transform);
                        image22.gameObject.SetActive(true);
                        image22.StartFadeIn(p.hand[1].suit, p.hand[1].number);

                    }
                    if (p.name == "player2")
                    {
                        image32 = Instantiate(image32, canvas2.transform);
                        image32.gameObject.SetActive(true);
                        image32.StartFadeIn(p.hand[1].suit, p.hand[1].number);

                    }
                    if (p.name == "player4")
                    {

                        image42 = Instantiate(image42, canvas2.transform);
                        image42.gameObject.SetActive(true);
                        image42.StartFadeIn(p.hand[1].suit, p.hand[1].number);

                    }
                }


                yield return new WaitForSeconds(1.0f);


                foreach (Player p in players)
                {
                    if (p.name == "player1")
                    {

                        image13 = Instantiate(image13, canvas2.transform);
                        image13.gameObject.SetActive(true);
                        image13.StartFadeIn(p.hand[2].suit, p.hand[2].number);

                    }
                    if (p.name == "player3")
                    {

                        image23 = Instantiate(image23, canvas2.transform);
                        image23.gameObject.SetActive(true);
                        image23.StartFadeIn(p.hand[2].suit, p.hand[2].number);

                    }
                    if (p.name == "player2")
                    {

                        image33 = Instantiate(image33, canvas2.transform);
                        image33.gameObject.SetActive(true);
                        image33.StartFadeIn(p.hand[2].suit, p.hand[2].number);
                    }
                    if (p.name == "player4")
                    {

                        image43 = Instantiate(image43, canvas2.transform);
                        image43.gameObject.SetActive(true);
                        image43.StartFadeIn(p.hand[2].suit, p.hand[2].number);

                    }
                }


                yield return new WaitForSeconds(1.0f);

                foreach (Player p in players)
                {
                    if (p.name == "player1")
                    {
                        image14 = Instantiate(image14, canvas2.transform);
                        image14.gameObject.SetActive(true);
                        image14.StartFadeIn(p.hand[3].suit, p.hand[3].number);

                    }
                    if (p.name == "player3")
                    {
                        image24 = Instantiate(image24, canvas2.transform);
                        image24.gameObject.SetActive(true);
                        image24.StartFadeIn(p.hand[3].suit, p.hand[3].number);

                    }
                    if (p.name == "player2")
                    {
                        image34 = Instantiate(image34, canvas2.transform);
                        image34.gameObject.SetActive(true);
                        image34.StartFadeIn(p.hand[3].suit, p.hand[3].number);
                    }
                    if (p.name == "player4")
                    {

                        image44 = Instantiate(image44, canvas2.transform);
                        image44.gameObject.SetActive(true);
                        image44.StartFadeIn(p.hand[3].suit, p.hand[3].number);
                    }
                }

                yield return new WaitForSeconds(1.0f);

                foreach (Player p in players)
                {
                    if (p.name == "player1")
                    {
                        image15 = Instantiate(image15, canvas2.transform);
                        image15.gameObject.SetActive(true);
                        image15.StartFadeIn(p.hand[4].suit, p.hand[4].number);
                    }
                    if (p.name == "player3")
                    {
                        image25 = Instantiate(image25, canvas2.transform);
                        image25.gameObject.SetActive(true);
                        image25.StartFadeIn(p.hand[4].suit, p.hand[4].number);
                    }
                    if (p.name == "player2")
                    {
                        image35 = Instantiate(image35, canvas2.transform);
                        image35.gameObject.SetActive(true);
                        image35.StartFadeIn(p.hand[4].suit, p.hand[4].number);
                    }
                    if (p.name == "player4")
                    {
                        image45 = Instantiate(image45, canvas2.transform);
                        image45.gameObject.SetActive(true);
                        image45.StartFadeIn(p.hand[4].suit, p.hand[4].number);
                    }
                }

                yield return new WaitForSeconds(7.0f);
                playerre1.SetActive(false);
                playerre2.SetActive(false);
                playerre3.SetActive(false);
                playerre4.SetActive(false);
                image11.gameObject.SetActive(false);
                image12.gameObject.SetActive(false);
                image13.gameObject.SetActive(false);
                image14.gameObject.SetActive(false);
                image15.gameObject.SetActive(false);
                image21.gameObject.SetActive(false);
                image22.gameObject.SetActive(false);
                image23.gameObject.SetActive(false);
                image24.gameObject.SetActive(false);
                image25.gameObject.SetActive(false);
                image31.gameObject.SetActive(false);
                image32.gameObject.SetActive(false);
                image33.gameObject.SetActive(false);
                image34.gameObject.SetActive(false);
                image35.gameObject.SetActive(false);
                image41.gameObject.SetActive(false);
                image42.gameObject.SetActive(false);
                image43.gameObject.SetActive(false);
                image44.gameObject.SetActive(false);
                image45.gameObject.SetActive(false);

                yield return new WaitForSeconds(1.0f);

                var (winnername, winnerIndex, winnerHand) = GetWinnerInfo(players);

                Debug.Log($"勝者: {winnerIndex}");
                Debug.Log($"役: {winnerHand.rank}");
                c_BM.result_text(winnername, winnerHand.rank);

                yield return new WaitForSeconds(5.0f);

                c_BM.result_text_reset();

                e_r.end_result1(players);
                yield return new WaitForSeconds(1.5f);
                e_r.end_result2(players);
                yield return new WaitForSeconds(1.5f);
                e_r.end_result3(players);
                yield return new WaitForSeconds(1.5f);
                foreach (var p in players)
                {
                    players[winnerIndex - 1].money += (p.bet_money1 + p.bet_money2);
                }
                players[winnerIndex - 1].money += (players[winnerIndex - 1].bet_money1 + players[winnerIndex - 1].bet_money2);
                e_r.end_result4(players);
                yield return new WaitForSeconds(1.0f);
                foreach (var p in players)
                {
                    p.bet_money1 = 0;
                    p.bet_money2 = 0;

                    if (p.name == "player1")
                    {
                        player1rastmoney = p.money;
                    }
                    if (p.name == "player2")
                    {
                        player2rastmoney = p.money;
                    }
                    if (p.name == "player3")
                    {
                        player3rastmoney = p.money;
                    }
                    if (p.name == "player4")
                    {
                        player4rastmoney = p.money;
                    }

                }
                Debug.Log($"p1の残り金額: {player1rastmoney}");
                Debug.Log($"p2の残り金額: {player2rastmoney}");
                Debug.Log($"p3の残り金額: {player3rastmoney}");
                Debug.Log($"p4の残り金額: {player4rastmoney}");
            }

            if (playerscount == 0)
            {
                c_BM.result_text0();
            }

            yield return new WaitForSeconds(5.0f);

            c_BM.result_text_reset();

            end_button1.SetActive(true);
        end_button2.SetActive(true);
            Debug.Log($"1prees{retryButton1.isPressed1}");
            Debug.Log($"2prees{retryButton2.isPressed2}");
            Debug.Log($"1flug{retryButton1.isRetryRequested}");

            bool isRetry = false;

            yield return StartCoroutine(WaitForRetry(retryButton1, retryButton2, result => isRetry = result));


            if (isRetry)
            {
                Debug.Log("やめるを選択、終了");
            }

            Debug.Log("リトライを選択、再開");
            e_r.end_esult_reset();
            end_button1.SetActive(false);
            end_button2.SetActive(false);
            deck = new Deck();
            deck.Shuffle();
            players.Clear();
            retryButton1.Reset_ret();
            retryButton2.Reset_ret();
            buttonManager.Reset_game();

        }

    }
}

