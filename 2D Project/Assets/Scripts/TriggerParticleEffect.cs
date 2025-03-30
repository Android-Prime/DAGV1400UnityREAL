using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem),typeof(Collider))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public int firstEmissionAmount = 10;
    public int secondEmissionAmount = 20;
    public int  thirdEmissionAmount = 30;
    public float delayBetweenEmissions = 0.5f;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        particleSystem.Emit(firstEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        particleSystem.Emit(secondEmissionAmount);
        yield return new WaitForSeconds(delayBetweenEmissions);
        
        particleSystem.Emit(thirdEmissionAmount);
    }
}