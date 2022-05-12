using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObjMovementController : MonoBehaviour // this class control collectible objects's up and down movement effect when objects are not collected
{
    [SerializeField] float movementValue;
    [SerializeField] float movementSpeed;

    public Vector3 objectPos;

    private bool isRising;
    private bool isFalling;

    void Start()
    {
        movementValue = 0.12f;
        movementSpeed = .2f;
        objectPos = this.transform.position;
    }
    void Update()
    {
        if (this.transform.position.y <= objectPos.y + movementValue && isFalling == false)
        {
            isFalling = false;
            this.transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }
        else
            isFalling = true;

        if (this.transform.position.y >= objectPos.y - movementValue && isFalling == true)
        {
            isFalling = true;
            this.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
        }
        else
            isFalling = false;

    }
}
