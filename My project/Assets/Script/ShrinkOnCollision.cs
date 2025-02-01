using UnityEngine;

public class ShrinkOnCollision : MonoBehaviour
{
    public float shrinkFactor = 0.9f;

    void OnCollisionEnter(Collision collision)
    {
        transform.localScale *= shrinkFactor;
    }

}
