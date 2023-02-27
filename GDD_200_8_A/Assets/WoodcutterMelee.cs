using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcutterMelee : MonoBehaviour
{
    // Start is called before the first frame update
    Animator woodcutterAnimator;
    AudioSource axeSwingAudio;
    GameObject axeSwingAudioObject;
    void Start()
    {
        axeSwingAudioObject = GameObject.Find("AxeAudio");
        woodcutterAnimator = GetComponent<Animator>();
        axeSwingAudio = axeSwingAudioObject.GetComponent<AudioSource>();
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
    }
}
