using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Change_player : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject textPrefab;
    public Transform confiParent;
    private bool end = false;
    public AudioClip clickSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        audioSource.clip = clickSound;

    }

    public void confi_player(Player player)
    {
        GameObject confi_Button = Instantiate(buttonPrefab, confiParent);
        confi_Button.name = $"confi_Button";

        GameObject newText = Instantiate(textPrefab, confiParent);
        TextMeshProUGUI text = newText.GetComponent<TextMeshProUGUI>();
        text.text = $"Are you {player.name}?";

        Button btn = confi_Button.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            audioSource.PlayOneShot(clickSound);
            Destroy(confi_Button);
            Destroy(newText);
            end = true;
        });
    }


    public IEnumerator WaitForButtonPress()
    {
        // BETŠ®—¹‚©PASS‘I‘ð‚Ü‚Å‘Ò‚Â
        yield return new WaitUntil(() => end == true);
    }


    public void ResetSelection()
    {
        end = false;
    }
}
