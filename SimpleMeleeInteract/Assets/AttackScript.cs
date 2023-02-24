using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject targetedEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            //melee attempt detected
            if(targetedEnemy != null)
            {
                GhostHealth enemyHealth = targetedEnemy.GetComponent<GhostHealth>();
                enemyHealth.damageGhost(3);
            }
            else
            {
                Debug.Log("Melee attack but no target");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            targetedEnemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(targetedEnemy != null && collision.gameObject.CompareTag("Enemy"))
        {
            targetedEnemy = null;
        }
    }
}
