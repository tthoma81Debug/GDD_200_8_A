using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieDamage : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject zombieAudioObject;
    AudioSource zombieImpact;
    int health = 10;
    void Start()
    {
        zombieAudioObject = GameObject.Find("ZombieAudio");
        zombieImpact = zombieAudioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
        if(collision.gameObject.name == "AttackBox")
        {
            Debug.Log("Damaging Zombie");
            health -= 3;
            //play impact audio
            zombieImpact.Play();
        }

        if(health <=0)
        {
            Debug.Log("Destroying zombie");

            //mark character for preservation in scene transition
            GameObject thePlayer = GameObject.Find("Woodcutter");
            DontDestroyOnLoad(thePlayer);

            //transition to new scene
            SceneManager.LoadScene("SecondLevel");

            //this is no longer needed. Scene transition will do this
            Destroy(this.gameObject);



        }
    }
}
