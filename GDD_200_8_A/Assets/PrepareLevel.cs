using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareLevel : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject thePlayer;
    void Start()
    {
        thePlayer = GameObject.Find("Woodcutter");
        thePlayer.transform.position = this.transform.position; //position player at starting spot
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
