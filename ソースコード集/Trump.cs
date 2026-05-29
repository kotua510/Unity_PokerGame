using UnityEngine;
using UnityEngine.UI;

public class Trump : MonoBehaviour
{
    public GameObject cardPrefab1;
    public GameObject cardPrefab2;
    public GameObject cardPrefab3;
    public GameObject cardPrefab4;
    public GameObject cardPrefab5;
    public Transform parentCanvas;  

    private GameObject newCard1;
    private GameObject newCard2;
    private GameObject newCard3;
    private GameObject newCard4;
    private GameObject newCard5;

    public void trumpmade(Player p)
    {
        newCard1 = Instantiate(cardPrefab1, parentCanvas);
        newCard2 = Instantiate(cardPrefab2, parentCanvas);
        newCard3 = Instantiate(cardPrefab3, parentCanvas);
        newCard4 = Instantiate(cardPrefab4, parentCanvas);
        newCard5 = Instantiate(cardPrefab5, parentCanvas);

        SetCardImage(newCard1,p, 0);
        SetCardImage(newCard2,p, 1);
        SetCardImage(newCard3,p, 2);
        SetCardImage(newCard4,p, 3);
        SetCardImage(newCard5,p, 4);

    }

    private void SetCardImage(GameObject cardObject ,Player p, int hand_idx)
    {
        string resourcePath = "";
        Card card = p.hand[hand_idx];

        if (card.suit == Suit.Spade)
        {
            if (card.number == 1)
            {
                resourcePath = "trump_image/s_1";
            }
            else if (card.number == 2)
            {
                resourcePath = "trump_image/s_2";
            }
            else if (card.number == 3)
            {
                resourcePath = "trump_image/s_3";
            }
            else if (card.number == 4)
            {
                resourcePath = "trump_image/s_4";
            }
            else if (card.number == 5)
            {
                resourcePath = "trump_image/s_5";
            }
            else if (card.number == 6)
            {
                resourcePath = "trump_image/s_6";
            }
            else if (card.number == 7)
            {
                resourcePath = "trump_image/s_7";
            }
            else if (card.number == 8)
            {
                resourcePath = "trump_image/s_8";
            }
            else if (card.number == 9)
            {
                resourcePath = "trump_image/s_9";
            }
            else if (card.number == 10)
            {
                resourcePath = "trump_image/s_10";
            }
            else if (card.number == 11)
            {
                resourcePath = "trump_image/s_11";
            }
            else if (card.number == 12)
            {
                resourcePath = "trump_image/s_12";
            }
            else if (card.number == 13)
            {
                resourcePath = "trump_image/s_13";
            }

        }
        else if (card.suit == Suit.Heart)
        {
            if (card.number == 1)
            {
                resourcePath = "trump_image/h_1";
            }
            else if (card.number == 2)
            {
                resourcePath = "trump_image/h_2";
            }
            else if (card.number == 3)
            {
                resourcePath = "trump_image/h_3";
            }
            else if (card.number == 4)
            {
                resourcePath = "trump_image/h_4";
            }
            else if (card.number == 5)
            {
                resourcePath = "trump_image/h_5";
            }
            else if (card.number == 6)
            {
                resourcePath = "trump_image/h_6";
            }
            else if (card.number == 7)
            {
                resourcePath = "trump_image/h_7";
            }
            else if (card.number == 8)
            {
                resourcePath = "trump_image/h_8";
            }
            else if (card.number == 9)
            {
                resourcePath = "trump_image/h_9";
            }
            else if (card.number == 10)
            {
                resourcePath = "trump_image/h_10";
            }
            else if (card.number == 11)
            {
                resourcePath = "trump_image/h_11";
            }
            else if (card.number == 12)
            {
                resourcePath = "trump_image/h_12";
            }
            else if (card.number == 13)
            {
                resourcePath = "trump_image/h_13";
            }
        }
        else if (card.suit == Suit.Diamond)
        {
            if (card.number == 1)
            {
                resourcePath = "trump_image/d_1";
            }
            else if (card.number == 2)
            {
                resourcePath = "trump_image/d_2";
            }
            else if (card.number == 3)
            {
                resourcePath = "trump_image/d_3";
            }
            else if (card.number == 4)
            {
                resourcePath = "trump_image/d_4";
            }
            else if (card.number == 5)
            {
                resourcePath = "trump_image/d_5";
            }
            else if (card.number == 6)
            {
                resourcePath = "trump_image/d_6";
            }
            else if (card.number == 7)
            {
                resourcePath = "trump_image/d_7";
            }
            else if (card.number == 8)
            {
                resourcePath = "trump_image/d_8";
            }
            else if (card.number == 9)
            {
                resourcePath = "trump_image/d_9";
            }
            else if (card.number == 10)
            {
                resourcePath = "trump_image/d_10";
            }
            else if (card.number == 11)
            {
                resourcePath = "trump_image/d_11";
            }
            else if (card.number == 12)
            {
                resourcePath = "trump_image/d_12";
            }
            else if (card.number == 13)
            {
                resourcePath = "trump_image/d_13";
            }
        }
        else if (card.suit == Suit.Club)
        {
            if (card.number == 1)
            {
                resourcePath = "trump_image/k_1";
            }
            else if (card.number == 2)
            {
                resourcePath = "trump_image/k_2";
            }
            else if (card.number == 3)
            {
                resourcePath = "trump_image/k_3";
            }
            else if (card.number == 4)
            {
                resourcePath = "trump_image/k_4";
            }
            else if (card.number == 5)
            {
                resourcePath = "trump_image/k_5";
            }
            else if (card.number == 6)
            {
                resourcePath = "trump_image/k_6";
            }
            else if (card.number == 7)
            {
                resourcePath = "trump_image/k_7";
            }
            else if (card.number == 8)
            {
                resourcePath = "trump_image/k_8";
            }
            else if (card.number == 9)
            {
                resourcePath = "trump_image/k_9";
            }
            else if (card.number == 10)
            {
                resourcePath = "trump_image/k_10";
            }
            else if (card.number == 11)
            {
                resourcePath = "trump_image/k_11";
            }
            else if (card.number == 12)
            {
                resourcePath = "trump_image/k_12";
            }
            else if (card.number == 13)
            {
                resourcePath = "trump_image/k_13";
            }
        }

        Sprite sprite = Resources.Load<Sprite>(resourcePath);
        Image img = cardObject.GetComponent<Image>();

        if (sprite != null)
            img.sprite = sprite;
        else
            Debug.LogWarning($"画像がない: {resourcePath}");
    }
    public void trumpdelete()
    {
        newCard1.SetActive(false);
        newCard2.SetActive(false);
        newCard3.SetActive(false);
        newCard4.SetActive(false);
        newCard5.SetActive(false);
    }

    public void trumpup()
    {
        newCard1.SetActive(true);
        newCard2.SetActive(true);
        newCard3.SetActive(true);
        newCard4.SetActive(true);
        newCard5.SetActive(true);
    }
}
