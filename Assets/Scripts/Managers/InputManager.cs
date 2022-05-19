using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private float horizontalInput = 270;
    public bool changed;

    private PlayerMovementController playerMovementControllerScript;

    void Start()
    {
        playerMovementControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.LogWarning(theTouch.phase.ToString());
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if(theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }
            //if(theTouch.phase == TouchPhase.Ended)
            //{
            //    horizontalInput = 270;
            //}
            else if(theTouch.phase == TouchPhase.Moved) //|| theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

             //   Debug.LogWarning(touchEndPosition.x);
                //if(Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                //{
                //    horizontalInput = 0;
                //}
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    horizontalInput = touchEndPosition.x;

                    if(x > 0)
                    {
                      //  horizontalInput = 1;
                    }
                    else
                    {
                     //   horizontalInput = -1;
                    }
                }
                
            }
        }
        
    }
    public float getHorizontalInput() 
    {
        return horizontalInput;
    }
}
