using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    // 227.7
    private GameObject playerObj;
    public bool walkToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning(Vector3.Distance(this.transform.position, playerObj.transform.position));
        this.transform.LookAt(playerObj.transform);

        if(walkToPlayer == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, playerObj.transform.position, 0.1f * Time.deltaTime);
            CheckDistance();
        }
    }


    public void CheckDistance()
    {
        if(Vector3.Distance(this.transform.position,playerObj.transform.position) < 5)
        {
            walkToPlayer = false;
        }
    }

    public void WalkToPlayer()
    {
        walkToPlayer = true;
    }

}
