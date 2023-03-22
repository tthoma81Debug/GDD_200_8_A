using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodcutterPointClick : MonoBehaviour
{
    // Start is called before the first frame update
    Camera theCamera;
    GameObject cameraObject;
    Vector3 destinationPosition;
    //Vector3 woodcutterPosition;
    Transform woodcutterTransform;

    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        theCamera = cameraObject.GetComponent<Camera>();
        destinationPosition = GameObject.Find("Woodcutter").transform.position;
        //woodcutterPosition = GameObject.Find("Woodcutter").transform.position;
        woodcutterTransform = GameObject.Find("Woodcutter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

           // Debug.Log(this.gameObject.name + " has been clicked");
           // Debug.Log("The mouse position is " + Input.mousePosition);
            Vector3 actualClickPosition = theCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Which, in the game world is " + actualClickPosition);



            RaycastHit2D hit = Physics2D.Raycast(actualClickPosition, Vector2.up);



            if (hit.transform != null)
            {
                //Our custom method. 
                //CurrentClickedGameObject(raycastHit.transform.gameObject);
                Debug.Log("hit " + hit.transform.name);
                Debug.Log(hit.transform.position);
                destinationPosition = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, theCamera.nearClipPlane));
                Debug.Log("target position" + destinationPosition);
            }
            else
            {
                Debug.Log("Click detected and ray is cast but nothing there");
            }

            destinationPosition = theCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, theCamera.nearClipPlane));

        }

        if (Input.GetKey(KeyCode.J))
        {
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, destinationPosition, Time.deltaTime * 5f);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            //then cast a ray from the woodcutter to the right
            Vector2 rayCastDirection = new Vector2(1f, 0f);
            //Vector2 startingSpot = new Vector2(woodcutterPosition.x + 1.7f, woodcutterPosition.y + 0.2f);
            Vector2 startingSpot = new Vector2(woodcutterTransform.position.x + 1.7f, woodcutterTransform.position.y + 0.2f);

            RaycastHit2D hit = Physics2D.Raycast(startingSpot, rayCastDirection);


            if (hit.transform != null)
            {
                Debug.Log("Detected an object to the right of the woodcutter");
                Debug.Log("It is " + hit.transform.gameObject.name);

                //float distanceAway = hit.transform.position.x - woodcutterPosition.x;
                float distanceAway = hit.transform.position.x - woodcutterTransform.position.x;

                if (distanceAway <= 5)
                {
                    Debug.Log("Woah! That zombie is close!");
                }
                else
                {
                    Debug.Log("more than 5 units away. We are ok for now");
                }

            }
        }

    }

    public void OnMouseDown()
    {



        




    }
}
