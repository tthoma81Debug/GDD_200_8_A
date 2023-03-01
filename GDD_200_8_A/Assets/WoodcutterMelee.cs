using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcutterMelee : MonoBehaviour
{
    // Start is called before the first frame update
    Animator woodcutterAnimator;
    AudioSource axeSwingAudio;
    GameObject axeSwingAudioObject;

    GameObject theGameManager;
    Inventory inventoryScript;
    void Start()
    {
        axeSwingAudioObject = GameObject.Find("AxeAudio");
        woodcutterAnimator = GetComponent<Animator>();
        axeSwingAudio = axeSwingAudioObject.GetComponent<AudioSource>();

        theGameManager = GameObject.Find("GameManager");
        inventoryScript = theGameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            //melee attack
            woodcutterAnimator.SetBool("MeleeButtonPressed", true);
            //play axe swing audio
            axeSwingAudio.Play();

        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            //magic button
            inventoryScript.printArray(); //debugging line
            GameObject fireball = inventoryScript.find("pocket_sun_1");

            if(fireball == null)
            {
                Debug.Log("Fireball 1 is not in inventory!");
            }
            else
            {
                
                Debug.Log("Fireball 1 is in inventory");
                Debug.Log("Firing Fireball 1");
            }

        }
    }
}
