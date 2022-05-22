using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectedObjectManager : MonoBehaviour
{
    private List<GameObject> CollectedObjectList = new List<GameObject>();
    private Vector3 targetPos;
    [SerializeField] float trackOffset;
    [SerializeField] float trackOffset2;

    [SerializeField] GameObject MoneyBrokeParticle;
    [SerializeField] GameObject DollarSignParticle;

    private GameObject CollectibleObject;
    private GameObject PrevCollectibleObject;

    private int indexOfObject;
    private int lastGameObjectIndex;

    // Start is called before the first frame update
    void Start()
    {
        trackOffset2 = -0.11f;
        trackOffset = 0.92f;
    }

    // Update is called once per frame
    void Update()
    {
        for(int index = 0; index < CollectedObjectList.Count; index++)
        {

           

            if (CollectedObjectList[index].gameObject == null)
            {
                CollectedObjectList.RemoveAt(index);
            }

            if(index == 0)
            {
                CollectibleObject = CollectedObjectList[index].gameObject;

          //      targetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + trackOffset2);  //0.09345f  // 0.005345f
          //      CollectibleObject.transform.position = Vector3.Lerp(CollectibleObject.transform.position, targetPos,15f * Time.deltaTime);

                CollectibleObject.transform.position = new Vector3(Mathf.Lerp(CollectibleObject.transform.position.x, this.transform.position.x, 1f), this.transform.position.y, Mathf.Lerp(CollectibleObject.transform.position.z, this.transform.position.z + trackOffset2, 15 * Time.deltaTime));
            }
            else
            {
                CollectibleObject = CollectedObjectList[index].gameObject;
                PrevCollectibleObject = CollectedObjectList[index - 1].gameObject;

                targetPos = new Vector3(PrevCollectibleObject.transform.position.x, PrevCollectibleObject.transform.position.y, PrevCollectibleObject.transform.position.z + trackOffset);
                CollectibleObject.transform.position =  Vector3.Lerp(CollectibleObject.gameObject.transform.position, targetPos, 15 * Time.deltaTime);
            }
        }   
    }


    public void CollideObject(GameObject CollectedObject)
    {
        if(  CollectedObjectList.Contains(CollectedObject)    )
            return;

        CollectedObjectList.Add(CollectedObject);

        for(int index = lastGameObjectIndex; index >= 0; index--)
        {
            CollectedObjectList[index].GetComponent<CollectibleObject>().SetBigger();
        }
        lastGameObjectIndex = CollectedObjectList.Count;
    }

    public void ObstacleCollision(GameObject CollectedObject)
    {
        Debug.Log(CollectedObject.name);
        CollectedObjectList.Remove(CollectedObject);
        lastGameObjectIndex = CollectedObjectList.Count;
       

        if( CollectedObject.GetComponent<CollectibleObject>().indexOnList == lastGameObjectIndex)
        {
            CollectedObject.GetComponent<CollectibleObject>().SetSmall();
        }
        else
        {
            Debug.Log("Not Last Obj");
            Debug.Log(" Object which collide" + CollectedObject.name);
            Debug.Log(" and its index: " + CollectedObject.GetComponent<CollectibleObject>().indexOnList);

            for(int i = CollectedObject.GetComponent<CollectibleObject>().indexOnList; i < CollectedObjectList.Count;i++)
            {
                Debug.Log("Object which must destroy: " + CollectedObjectList[i].name);
                CollectedObjectList[i].GetComponent<CollectibleObject>().SetSmall();
                CollectedObjectList.RemoveAt(i);
            }
            CollectedObject.GetComponent<CollectibleObject>().SetSmall();
        }

    }

    public void FinishLine(GameObject CollectedObject)
    {
        lastGameObjectIndex = CollectedObjectList.Count;
        lastGameObjectIndex--;
        CollectedObjectList.Remove(CollectedObject);
        Destroy(CollectedObject);
    }


    public int getCollectedObjectCount()
    {
        return CollectedObjectList.Count;
    }
}
