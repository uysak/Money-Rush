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
        Move();
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
        Debug.LogWarning("calis");
        this.transform.Translate(inputManagerScript.getHorizontalInput() / 100, 0, 0); //+= Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x + inputManagerScript.getHorizontalInput() / 50, 0f,0f),0.5f);
        inputManagerScript.changed = false;   
    }

}
    