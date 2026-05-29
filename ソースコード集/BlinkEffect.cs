using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkEffect : MonoBehaviour
{
    private bool isBlinking = false; 
    private Coroutine blinkCoroutine;
    private Image image; 

    void Start()
    {
        image = GetComponent<Image>();
        if (image == null)
            Debug.LogError("Imageがない");
    }

    public void ToggleBlink()
    {
        if (isBlinking)
        {
            StopCoroutine(blinkCoroutine);
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
            isBlinking = false;
        }
        else
        {
            blinkCoroutine = StartCoroutine(Blink());
            isBlinking = true;
        }
    }

    private IEnumerator Blink()
    {
        Color c = image.color;

        while (true)
        {
            // フェードアウト
            for (float a = 1f; a >= 0f; a -= 0.1f)
            {
                c.a = a;
                image.color = c;
                yield return new WaitForSeconds(0.05f);
            }

            // フェードイン
            for (float a = 0f; a <= 1f; a += 0.1f)
            {
                c.a = a;
                image.color = c;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
