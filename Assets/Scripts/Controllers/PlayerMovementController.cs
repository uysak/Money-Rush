using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float horizontalInputTouch;
    private float horizontalInputKeyboard;
    [SerializeField] float horizontalMovementSpeed;
    [SerializeField] float VerticalMovementSpeed;
    private InputManager inputManagerScript;

    private void Start()
    {
        inputManagerScript = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
    }
    void Update()
    {
        Move2();
        Run();
        CheckBorder();
    }

    private void CheckBorder()
    {
        if (this.transform.position.x > 4)
        {
            this.transform.position = new Vector3(4, this.transform.position.y, this.transform.position.z);
        }
        else if (this.transform.position.x < -5)
        {
            this.transform.position = new Vector3(-5, this.transform.position.y, this.transform.position.z);
        }
    }

    private void Move()
    {

        horizontalInputKeyboard = Input.GetAxis("Horizontal");
        horizontalInputTouch =  Mathf.Lerp(horizontalInputKeyboard, inputManagerScript.getHorizontalInput(),0.3f);



        if(horizontalInputKeyboard != 0)
        {
            this.transform.Translate(horizontalInputKeyboard * horizontalMovementSpeed * Time.deltaTime,
                         0,
                         VerticalMovementSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(horizontalInputTouch * horizontalMovementSpeed * Time.deltaTime,
                         0,
                         VerticalMovementSpeed * Time.deltaTime);
        }

    }

    private void Run()
    {
        this.transform.Translate(0,
                        0,
                        VerticalMovementSpeed * Time.deltaTime);
    }

    public void Move2()
    {
        horizontalInputKeyboard = Input.GetAxis("Horizontal");
        if (horizontalInputKeyboard != 0)
        {
            this.transform.Translate(horizontalInputKeyboard * horizontalMovementSpeed * Time.deltaTime,
                         0,
                         VerticalMovementSpeed * Time.deltaTime);
        }
        else
        {

        
            horizontalInputTouch = map(inputManagerScript.getHorizontalInput(), 40, 750, -4, 5);
            this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, horizontalInputTouch, 2 * Time.deltaTime), this.transform.position.y, this.transform.position.z);
        }
    }

    float map(float val, float iMin, float iMax, float oMin, float oMax)
    {

        return (val - iMin) * (oMax - oMin) / (iMax - iMin) + oMin;
    }
    
}
    