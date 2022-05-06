using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObjectMovement : MonoBehaviour
{
    public float movementValue;
    public float movementSpeed;

    public Vector3 objectPos;

    private float targetPos;

    public Vector3 pos;

    private bool isRising;
    private bool isFalling;
    // Start is called before the first frame update
    void Start()
    {
        movementValue = 0.3f;
        movementSpeed = .2f;
        objectPos = this.transform.position;
        targetPos = objectPos.y + movementValue;

    }

    // Update is called once per framef
    void Update()
    {
        //if (this.transform.position.y >= objectPos.y + movementValue)
        //{
        //    isFalling = true;
        //}

        //if (this.transform.position.y <= objectPos.y - movementValue)
        //{
        //    isFalling = false;
        //}

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
