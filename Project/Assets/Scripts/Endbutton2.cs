using UnityEngine;

public class RetryButton2 : MonoBehaviour
{
    public bool isPressed2 = false;
    public void OnClickRetry()
    {
        isPressed2 = true;
    }

    public void Reset_ret()
    {
        isPressed2 = false;
    }

}