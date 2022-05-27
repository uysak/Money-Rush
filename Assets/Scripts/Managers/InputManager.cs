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
        //TouchScreen();
        Mouse();
    }


    private void Mouse()
    {
        if(Input.GetMouseButton(0)){
            horizontalInput = map(Input.mousePosition.x, 0, 500, -5, 4);
        }
    }



    private void TouchScreen()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved) //|| theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    horizontalInput = map(touchEndPosition.x, 20, 750, -5, 4);                
                }
            }
        }
    }

    public float getHorizontalInput() 
    {
        return horizontalInput;
    }

    float map(float val, float iMin, float iMax, float oMin, float oMax)
    {

        return (val - iMin) * (oMax - oMin) / (iMax - iMin) + oMin;
    }

}
