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

    private void Run()
    {
        this.transform.Translate(0,
                        0,
                        VerticalMovementSpeed * Time.deltaTime);
    }

    public void Move()
    {
        horizontalInputTouch = inputManagerScript.getHorizontalInput();
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, horizontalInputTouch, 2 * Time.deltaTime), this.transform.position.y, this.transform.position.z);   
    }


    
}
    