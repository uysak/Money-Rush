using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectedObjectManager : MonoBehaviour
{ 

   // 77FFAC

    private List<GameObject> CollectedObjectList = new List<GameObject>();
    private Vector3 targetPos;

    [SerializeField] float trackOffsetBetweenObj;
    [SerializeField] float trackOffsetBetweenPlayerAndObj;

    [SerializeField] GameObject MoneyBrokeParticle;
    [SerializeField] GameObject DollarSignParticle;

    private GameManager gameManagerScript;

    private GameObject CollectibleObject;
    private GameObject PrevCollectibleObject;
    private GameObject PlayerObj;

    private int indexOfObject;
    private int lastGameObjectIndex;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        trackOffsetBetweenPlayerAndObj = -0.11f;
        trackOffsetBetweenObj = 0.92f;
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
                // (Mathf.Lerp(CollectibleObject.transform.position.x, this.transform.position.x, 1f)
                CollectibleObject = CollectedObjectList[index].gameObject;
                PlayerObj = this.gameObject;

                targetPos = new Vector3(PlayerObj.transform.position.x, PlayerObj.transform.position.y, Mathf.Lerp(CollectibleObject.transform.position.z, PlayerObj.transform.position.z + trackOffsetBetweenPlayerAndObj, 15 * Time.deltaTime));
                CollectibleObject.transform.position = targetPos;
            }
            else
            {
                CollectibleObject = CollectedObjectList[index].gameObject;
                PrevCollectibleObject = CollectedObjectList[index - 1].gameObject;

                targetPos = new Vector3(PrevCollectibleObject.transform.position.x, PrevCollectibleObject.transform.position.y, PrevCollectibleObject.transform.position.z + trackOffsetBetweenObj);
                CollectibleObject.transform.position =  Vector3.Lerp(CollectibleObject.gameObject.transform.position, targetPos, 15 * Time.deltaTime);
            }
        }   
    }


    public void CollideObject(GameObject CollectedObject)
    {
        if(   CollectedObjectList.Contains(CollectedObject)  )
            return;

        gameManagerScript.IncreaseScore(CollectedObject.GetComponent<CollectibleObject>().getPrice());

        CollectedObjectList.Add(CollectedObject);

        gameManagerScript.CheckPlayerRunOrCarry();

        for (int index = lastGameObjectIndex; index >= 0; index--)
        {
            CollectedObjectList[index].GetComponent<CollectibleObject>().SetBigger();
        }

        lastGameObjectIndex = CollectedObjectList.Count;
    }

    public void ObstacleCollision(GameObject CollectedObject)
    {
        gameManagerScript.DecreaseScore(CollectedObject.GetComponent<CollectibleObject>().getPrice());
        gameManagerScript.ShakeCamera();
        CollectedObject.GetComponent<CollectibleObject>().SetSmall();
        CollectedObjectList.Remove(CollectedObject);

        lastGameObjectIndex = CollectedObjectList.Count;
       

        if( CollectedObject.GetComponent<CollectibleObject>().indexOnList == lastGameObjectIndex)
        {
            CollectedObject.GetComponent<CollectibleObject>().SetSmall();
        }
        else
        {
            for(int i = CollectedObject.GetComponent<CollectibleObject>().indexOnList; i < CollectedObjectList.Count;i++)
            {
                Debug.Log("Object which must destroy: " + CollectedObjectList[i].name);
                CollectedObjectList[i].GetComponent<CollectibleObject>().SetSmall();
                CollectedObjectList.RemoveAt(i);
                gameManagerScript.DecreaseScore(CollectedObject.GetComponent<CollectibleObject>().getPrice());
                
            }

            lastGameObjectIndex = CollectedObjectList.Count;
        }
    }

    public void FinishLineCollision(GameObject CollectedObject)
    {
        Instantiate(DollarSignParticle, CollectedObject.transform.position, CollectedObject.transform.rotation);
        lastGameObjectIndex = CollectedObjectList.Count;
        lastGameObjectIndex--;
        CollectedObjectList.Remove(CollectedObject);
        Destroy(CollectedObject);
    }


    public int getCollectedObjectCount()
    {
        return CollectedObjectList.Count;
    }

    public void DestroyAllCollectedObjects()
    {
        foreach(GameObject obj in CollectedObjectList)
        {
            obj.GetComponent<CollectibleObject>().SetSmall();
        }
    }
}
