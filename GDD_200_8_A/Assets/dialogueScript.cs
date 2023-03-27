using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject theDialoguePanel;
    Text optionOneText;
    Text optionTwoText;
    int state = 0;

    /* Value of state
     * 
     * 0 is starting
     * 1 is first choice selected
     * 2 is second choice selected
     * 3 is first choice selected then first choice again
     * 4 is first choice selected, then first choice, then first choice
     * 5 is second choice, then first choice
     * 6 is second choice, then first choice, then first choice
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 999 is closed
     */



    void Start()
    {
        theDialoguePanel = GameObject.Find("Panel");
        optionOneText = GameObject.Find("OptionOneText").GetComponent<Text>();
        optionTwoText = GameObject.Find("OptionTwoText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void optionOneClick()
    {
        //theDialoguePanel.SetActive(false);
        if(state == 0)
        {
            changeText("You have chosen the first option", "", 1);
        }
        else if(state == 2)
        {
            changeText("Thats really cool! I was hoping you would choose the second option!", "", 5);
        }
        else if(state == 5)
        {
            changeText("That zombie virus thing seems to be going around again...", "", 6);
        }
        else if(state == 1)
        {
            changeText("Thats cool. The first option will kindof work...", "", 3);
        }
        else if(state == 3)
        {
            changeText("Ya know...there is a zombie over there", "", 4);
        }

        else if(state == 6 || state == 4)
        {
            theDialoguePanel.SetActive(false);
            state = 999;
        }
    }

    public void optionTwoClick()
    {
        if (state == 0)
        {
            changeText("You have chosen the second option", "", 2);
        }
    }


    private void changeText(String firstLine, String secondLine, int newState)
    {
        optionOneText.text = firstLine;
        optionTwoText.text = secondLine;
        state = newState;
    }
}
