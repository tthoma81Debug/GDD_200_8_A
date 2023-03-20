using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
//depending on what version of urp you have, you may need the below import instead
// using UnityEngine.Rendering.Universal;

public class CharacterLightAdjuster : MonoBehaviour
{
    // Start is called before the first frame update
    Light2D characterLight;
    bool lightIncreasing = true;
    void Start()
    {
        characterLight = GameObject.Find("CharacterLight").GetComponent<Light2D>();
        StartCoroutine(lightTwinkle());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public IEnumerator lightTwinkle()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            
            //if light is getting brighter
            if(lightIncreasing == true && characterLight.intensity <= 10f) //and not at max
            {
                characterLight.intensity += 2f; //brighten
            }
            else if(lightIncreasing == true && characterLight.intensity >10f) //if at max
            {
                lightIncreasing = false; //switch to getting darker
            }
            //if light is getting darker
            if (lightIncreasing == false && characterLight.intensity >= 0f) //and not at min
            {
                characterLight.intensity -= 2f; //darken
            }
            else if(lightIncreasing == false && characterLight.intensity < 0f) //if at min
            {
                lightIncreasing = true; //switch to getting lighter
            }
            
        }
    }
}
