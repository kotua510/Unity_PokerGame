using UnityEngine;

public class RetryButton1 : MonoBehaviour
{
    public bool isRetryRequested = true;
    public bool isPressed1 = false;
    public void OnClickRetry()
    {
        isRetryRequested = false;
        isPressed1 = true;
}

    public void Reset_ret()
    {
        isRetryRequested = true;
        isPressed1 = false;
    }
}