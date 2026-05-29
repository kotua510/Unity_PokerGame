using UnityEngine;
using System.Collections;

public class Animator_Manager : MonoBehaviour
{
    private Animator animator;
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("AnimatorÇ™Ç»Ç¢");

        audioSource = gameObject.AddComponent<AudioSource>();

        // âπó Ç‚ê›íË
        audioSource.playOnAwake = false;
        audioSource.volume = 1.0f;
        audioSource.clip = clickSound;
    }

    public void PlayAnimation(string animName)
    {
        Debug.Log($"çƒê∂äJén: {animName}");
        animator.Play(animName);
    }

    public void PlayAnimationMultiple(string animationName, int times, float interval)
    {
        StartCoroutine(PlayMultiple(animationName, times, interval));
    }

    private IEnumerator PlayMultiple(string animationName, int times, float interval)
    {
        for (int i = 0; i < times; i++)
        {
            animator.Rebind();
            animator.Update(0);
            animator.Play(animationName);
            audioSource.PlayOneShot(clickSound);
            yield return new WaitForSeconds(interval);
        }
    }

    public void Animation_object_reset()
    {
        animator.Rebind();
        animator.Update(0);
    }

}
