using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodcutterMelee : MonoBehaviour
{
    // Start is called before the first frame update
    Animator woodcutterAnimator;
    AudioSource axeSwingAudio;
    GameObject axeSwingAudioObject;

    GameObject theGameManager;
    Inventory inventoryScript;

    public GameObject fireballPrefab;
    private GameObject spawnedFireball;
    private GameObject fireballSpawnPoint;
    private GameObject battleTextObject;
    private Text battleText;


    private IEnumerator fireballSpawnDelay;

    bool spawnFlag = false;

    void Start()
    {
        axeSwingAudioObject = GameObject.Find("AxeAudio");
        woodcutterAnimator = GetComponent<Animator>();
        axeSwingAudio = axeSwingAudioObject.GetComponent<AudioSource>();

        theGameManager = GameObject.Find("GameManager");
        inventoryScript = theGameManager.GetComponent<Inventory>();
        fireballSpawnPoint = GameObject.Find("ProjectileSpawnPoint");
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

                //spawn a fireball


                if (spawnFlag == false)
                {
                    StartCoroutine(fireballCoroutine());
                }

                
            }

        }
    }

    private IEnumerator fireballCoroutine()
    {
        //any code before the yield runs immediately on the frame it is called
        //yield return null;
        //any code after the yield runs on the frame after the first frame

        while (true) //infinite loop, but ok with coroutine
        {
            yield return new WaitForSeconds(2);
            if (spawnFlag == false)
            {

                spawnFlag = true;
                Debug.Log("In CoRoutine. Spawning Fireball");

                spawnedFireball = Instantiate(fireballPrefab, fireballSpawnPoint.transform.position, Quaternion.identity);
                //hurl fireball
                //runs code up to this point on first frame. Then waits 3 seconds

                //update ui text
                battleTextObject = GameObject.Find("ModeText");
                battleText = battleTextObject.GetComponent<Text>();

                battleText.text = "Fireball Deployed!!!!!!!";

                yield return new WaitForSeconds(3);
                //after 3 seconds, picks up from here
                Debug.Log("Fireball Away!");

                Rigidbody2D fireballPhysics = spawnedFireball.GetComponent<Rigidbody2D>();
                Vector3 fireballForce = new Vector3(10, 7, 0);
                fireballPhysics.AddForce(fireballForce, ForceMode2D.Impulse);


                StartCoroutine(fireballExpiration());

            }
        }
        //coroutine doesn't actually return anything (at least in the normal sense)
    }

    private IEnumerator fireballExpiration()
    {

        yield return new WaitForSeconds(3);

        Rigidbody2D fireballPhysics = spawnedFireball.GetComponent<Rigidbody2D>();
        Vector3 fireballForce = new Vector3(-15, 8, 0);
        fireballPhysics.AddForce(fireballForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(3);
        Destroy(spawnedFireball);
        spawnFlag = false;



        //yield return null;
    }
}
