using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    // Start is called before the first frame update
    ParticleSystem theSystem;
    void Start()
    {
        theSystem = GetComponent<ParticleSystem>();
        StartCoroutine(stopSimulation());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator stopSimulation()
    {
        yield return new WaitForSeconds(4);
        ParticleSystem.ExternalForcesModule ext = theSystem.externalForces;

        ext.enabled = false;
        Debug.Log("Stopped");

    }

}
