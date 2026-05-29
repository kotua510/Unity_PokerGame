using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button2;
    public Button button3;
    public Button button4;
    public TextMeshProUGUI text;

    private int selectedValue = -1;
    public int SelectedValue => selectedValue;

    void Start()
    {
        button2.onClick.AddListener(() => OnButtonClicked(2));
        button3.onClick.AddListener(() => OnButtonClicked(3));
        button4.onClick.AddListener(() => OnButtonClicked(4));

    }

    void OnButtonClicked(int value)
    {
        selectedValue = value;
        Debug.Log($"{value} ‚ª‰Ÿ‚³‚ê‚½");

        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        button4.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

    }

     public void Reset_game()
    {
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        button4.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        selectedValue = -1;
    }

    public IEnumerator WaitForButtonPress()
    {
        yield return new WaitUntil(() => selectedValue != -1);
    }
}
