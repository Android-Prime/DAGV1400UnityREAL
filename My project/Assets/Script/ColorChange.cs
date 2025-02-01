using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color newColor = Color.red;

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Renderer>().material.color = newColor;
    }
}
