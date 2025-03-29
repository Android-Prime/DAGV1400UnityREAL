using UnityEngine;

[RequireComponent(typeof(ParticleSystem),typeof(Collider))]
public class ParticleTrigger : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int particleAmount = 10;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            particleSystem.Emit(particleAmount);
        }
    }
}