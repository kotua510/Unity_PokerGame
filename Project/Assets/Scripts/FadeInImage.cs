using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    [Header("フェードインにかける時間（秒）")]
    public float fadeDuration = 1.0f;
    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
        if (img != null)
        {
            Color c = img.color;
            c.a = 0f;
            img.color = c;
        }
    }
    public void StartFadeIn(Suit suit, int number)
    {
        LoadCardSprite(suit, number);
        if (img != null)
            StartCoroutine(FadeIn());
    }

    private void LoadCardSprite(Suit suit, int number)
    {
        if (img == null) return;
        
        string path = "";

        if (suit == Suit.Spade)
        {
            if (number == 1)
            {
                path = "trump_image/s_1";
            }
            else if (number == 2)
            {
                path = "trump_image/s_2";
            }
            else if (number == 3)
            {
                path = "trump_image/s_3";
            }
            else if (number == 4)
            {
                path = "trump_image/s_4";
            }
            else if (number == 5)
            {
                path = "trump_image/s_5";
            }
            else if (number == 6)
            {
                path = "trump_image/s_6";
            }
            else if (number == 7)
            {
                path = "trump_image/s_7";
            }
            else if (number == 8)
            {
                path = "trump_image/s_8";
            }
            else if (number == 9)
            {
                path = "trump_image/s_9";
            }
            else if (number == 10)
            {
                path = "trump_image/s_10";
            }
            else if (number == 11)
            {
                path = "trump_image/s_11";
            }
            else if (number == 12)
            {
                path = "trump_image/s_12";
            }
            else if (number == 13)
            {
                path = "trump_image/s_13";
            }

        }
        else if (suit == Suit.Heart)
        {
            if (number == 1)
            {
                path = "trump_image/h_1";
            }
            else if (number == 2)
            {
                path = "trump_image/h_2";
            }
            else if (number == 3)
            {
                path = "trump_image/h_3";
            }
            else if (number == 4)
            {
                path = "trump_image/h_4";
            }
            else if (number == 5)
            {
                path = "trump_image/h_5";
            }
            else if (number == 6)
            {
                path = "trump_image/h_6";
            }
            else if (number == 7)
            {
                path = "trump_image/h_7";
            }
            else if (number == 8)
            {
                path = "trump_image/h_8";
            }
            else if (number == 9)
            {
                path = "trump_image/h_9";
            }
            else if (number == 10)
            {
                path = "trump_image/h_10";
            }
            else if (number == 11)
            {
                path = "trump_image/h_11";
            }
            else if (number == 12)
            {
                path = "trump_image/h_12";
            }
            else if (number == 13)
            {
                path = "trump_image/h_13";
            }
        }
        else if (suit == Suit.Diamond)
        {
            if (number == 1)
            {
                path = "trump_image/d_1";
            }
            else if (number == 2)
            {
                path = "trump_image/d_2";
            }
            else if (number == 3)
            {
                path = "trump_image/d_3";
            }
            else if (number == 4)
            {
                path = "trump_image/d_4";
            }
            else if (number == 5)
            {
                path = "trump_image/d_5";
            }
            else if (number == 6)
            {
                path = "trump_image/d_6";
            }
            else if (number == 7)
            {
                path = "trump_image/d_7";
            }
            else if (number == 8)
            {
                path = "trump_image/d_8";
            }
            else if (number == 9)
            {
                path = "trump_image/d_9";
            }
            else if (number == 10)
            {
                path = "trump_image/d_10";
            }
            else if (number == 11)
            {
                path = "trump_image/d_11";
            }
            else if (number == 12)
            {
                path = "trump_image/d_12";
            }
            else if (number == 13)
            {
                path = "trump_image/d_13";
            }
        }
        else if (suit == Suit.Club)
        {
            if (number == 1)
            {
                path = "trump_image/k_1";
            }
            else if (number == 2)
            {
                path = "trump_image/k_2";
            }
            else if (number == 3)
            {
                path = "trump_image/k_3";
            }
            else if (number == 4)
            {
                path = "trump_image/k_4";
            }
            else if (number == 5)
            {
                path = "trump_image/k_5";
            }
            else if (number == 6)
            {
                path = "trump_image/k_6";
            }
            else if (number == 7)
            {
                path = "trump_image/k_7";
            }
            else if (number == 8)
            {
                path = "trump_image/k_8";
            }
            else if (number == 9)
            {
                path = "trump_image/k_9";
            }
            else if (number == 10)
            {
                path = "trump_image/k_10";
            }
            else if (number == 11)
            {
                path = "trump_image/k_11";
            }
            else if (number == 12)
            {
                path = "trump_image/k_12";
            }
            else if (number == 13)
            {
                path = "trump_image/k_13";
            }
        }
        Sprite cardSprite = Resources.Load<Sprite>(path);

        if (cardSprite != null)
        {
            img.sprite = cardSprite;
        }
        else
        {
            Debug.LogWarning($"カード画像がない: {path}");
        }
    }

    private IEnumerator FadeIn()
    {
        Color c = img.color;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            img.color = c;
            yield return null;
        }

        c.a = 1f;
        img.color = c;
    }
}
