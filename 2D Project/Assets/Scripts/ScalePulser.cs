using UnityEngine;

public class ScalePulser : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float maxScale = 1.5f;
    public float minScale = 0.5f;

    public void Pulse()
    {
        float scale = Mathf.PingPong(Time.time * pulseSpeed, maxScale - minScale);
        transform.localScale = new Vector3(scale, scale, scale);
    }

}
