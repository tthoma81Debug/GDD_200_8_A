using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem theSystem;
    void Start()
    {
        theSystem = GetComponent<ParticleSystem>();

        StartCoroutine(stopTimer());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator stopTimer()
    {
        yield return new WaitForSeconds(4);
        ParticleSystem.EmissionModule theEmissionSystem = theSystem.emission;
        theEmissionSystem.enabled = false;

    }
}
