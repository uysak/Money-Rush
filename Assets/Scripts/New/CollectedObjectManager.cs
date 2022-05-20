using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjectManager : MonoBehaviour
{
    private List<GameObject> CollectedObjectList = new List<GameObject>();
    private Vector3 targetPos;
    private float trackOffset;

    [SerializeField] GameObject MoneyBrokeParticle;
    [SerializeField] GameObject DollarSignParticle;

    private GameObject CollectibleObject;
    private GameObject PrevCollectibleObject;

    private int indexOfObject;
    private int lastGameObjectIndex;

    // Start is called before the first frame update
    void Start()
    {
        trackOffset = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        for(int index = 0; index < CollectedObjectList.Count; index++)
        {
            if(index == 0)
            {
                CollectibleObject = CollectedObjectList[index].gameObject;

                    targetPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + trackOffset);
                CollectedObjectList[index].gameObject.transform.position = Vector3.Lerp(CollectedObjectList[index].gameObject.transform.position, targetPos, 15 * Time.deltaTime);
            }
            else
            {
                CollectibleObject = CollectedObjectList[index].gameObject;
                PrevCollectibleObject = CollectedObjectList[index - 1].gameObject;

                targetPos = new Vector3(CollectedObjectList[index - 1].transform.position.x, CollectedObjectList[index - 1].gameObject.transform.position.y, CollectedObjectList[index - 1].gameObject.transform.position.z + trackOffset);
                CollectibleObject.transform.position = Vector3.Lerp(CollectedObjectList[index].gameObject.transform.position, targetPos, 15 * Time.deltaTime);
            }
        }   
    }


    public void CollideObject(GameObject CollectedObject)
    {
        CollectedObjectList.Add(CollectedObject);
        lastGameObjectIndex = CollectedObjectList.Count;
    //    Debug.Log("last gameobject index: " + lastGameObjectIndex);
    }
    public void ObstacleCollision(GameObject CollectedObject)
    {
        CollectedObjectList.Remove(CollectedObject);
        lastGameObjectIndex = CollectedObjectList.Count;
       // Debug.Log("index on list: " + CollectedObject.GetComponent<CollectibleObject>().indexOnList + "  " + "last gameobject index: " + lastGameObjectIndex);
 

        if( CollectedObject.GetComponent<CollectibleObject>().indexOnList == lastGameObjectIndex)
        {
            Debug.Log("last object detect");
            Destroy(CollectedObject);
        }
        else
        {
            Debug.Log("elseeeee");
            int deneme = CollectedObjectList.Count - CollectedObject.GetComponent<CollectibleObject>().indexOnList;
            deneme--;
            Debug.LogError(deneme);
            
            for(int i = CollectedObject.GetComponent<CollectibleObject>().indexOnList; i < CollectedObjectList.Count;i++)
            {
                Destroy(CollectedObjectList[i].gameObject);
            }

            CollectedObjectList.RemoveRange(CollectedObject.GetComponent<CollectibleObject>().indexOnList, CollectedObjectList.Count - CollectedObject.GetComponent<CollectibleObject>().indexOnList);

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
