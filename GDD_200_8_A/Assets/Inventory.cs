using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] theInventory;
    public int currentOpenSpot; //the next spot in inventory
    public int lastSpot; //last valid spot in inventory
    void Start()
    {
        currentOpenSpot = 0;
        lastSpot = 9;
        theInventory = new GameObject[10];

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public GameObject find(string gameObjectToFind) //returns gameobject if found, null if not found
    {


        bool foundObject = false;
        int spotOfObject = -1;
        GameObject thingToReturn = null;

        if(currentOpenSpot <= 0)
        {
            Debug.Log("inventory empty. Cannot search");
        }
        else
        {
            for (int i = 0; i < currentOpenSpot; i++)
            {
                if (theInventory[i].name == gameObjectToFind)
                {
                    //we have found the gameObject
                    foundObject = true;
                    spotOfObject = i;
                }
            }
        }
        

        //if we found something, return it, otherwise return null

        if(foundObject == true)
        {
            thingToReturn = theInventory[spotOfObject];
        }
        else
        {
            //found nothing, so don't change thingToReturn
        }

        return thingToReturn;

    }

    public void printArray()
    {
        for(int i = 0; i < theInventory.Length; i++)
        {
            if(theInventory[i] != null)
            {
                Debug.Log("Position at " + i + " contains " + theInventory[i].name);
            }
        }
    }
}
