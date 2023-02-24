using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damageGhost(int incomingDamage)
    {
        health -= incomingDamage;
        Debug.Log("Ghost Hit with: " + incomingDamage);
        possiblyDestroy();
    }

    private void possiblyDestroy()
    {
        if(health <= 0)
        {
            Debug.Log("Ghost Destroyed");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Ghost took a hit but is still in the game");
        }
    }
}
