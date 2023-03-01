using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject theGameManager;
    Inventory inventoryScript;
    GameObject inventorySpot1;
    void Start()
    {
        theGameManager = GameObject.Find("GameManager");
        inventoryScript = theGameManager.GetComponent<Inventory>();
        inventorySpot1 = GameObject.Find("InventorySpot1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " ran into trigger");

        if(collision.gameObject.name == "Woodcutter")
        {
            addToInventory();
        }
    }

    public void addToInventory()
    {
        //if the array is not yet full, we can add to inventory
        if(inventoryScript.currentOpenSpot <= inventoryScript.lastSpot)
        {
            //add to inventory
            inventoryScript.theInventory[inventoryScript.currentOpenSpot] = this.gameObject;
            inventoryScript.currentOpenSpot++;

            Debug.Log("added " + this.gameObject.name + " to inventory");

            //Destroy(this.gameObject);

            //makes pickup invisible
            SpriteRenderer thisRenderer = GetComponent<SpriteRenderer>();
            thisRenderer.enabled = false;

            //moves pickup to visual inventory spot

            //would need to make object a child of the parent
            //this.gameObject.transform.position = inventorySpot1.transform.position;
            //thisRenderer.enabled = true;

            inventorySpot1.GetComponent<SpriteRenderer>().sprite = thisRenderer.sprite;


        }
        else
        {
            Debug.Log("inventory full. not adding");
        }
    }
}
