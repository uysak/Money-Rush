using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] float horizontalMovementSpeed;
    [SerializeField] float VerticalMovementSpeed;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        this.transform.Translate(horizontalInput * horizontalMovementSpeed * Time.deltaTime,
                                 0,
                                 VerticalMovementSpeed * Time.deltaTime);
    }
}
