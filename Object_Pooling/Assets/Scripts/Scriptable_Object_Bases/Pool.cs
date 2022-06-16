using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Pool", order = 0)]
public class Pool : ScriptableObject, IPoolObject  {
    public string poolName;
    public int poolID;
    public GameObject objectToPool;
    public int poolSize;
    private Queue<GameObject> objectHolder;
    public Queue<GameObject> GetObjectHolder {
        get { return objectHolder; }
    }
    public void InitializePool()  {
        //Generate an id to be inserted into the pool manager dictionary...
        if (poolID == null || poolID == 0) { poolID = GetInstanceID(); }
        //Initialize the object Queue...
        objectHolder = new Queue<GameObject>();
        GameObject poolHolder = new GameObject();
        poolHolder.name = poolName;
        //Instantiate the corresponding pool objects...
        for (int i = 0; i < poolSize; i++)  {
            GameObject go = Instantiate(objectToPool, Vector3.zero, Quaternion.identity, poolHolder.transform);
            go.GetComponent<PoolObject>()?.OnInit(this);
            go.SetActive(false);
            objectHolder.Enqueue(go);
        }
    }
    //Use object from pool...
    public void PullObjectFromPool(Vector3 position) {
        GameObject objectToSpawn = objectHolder.Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.SetActive(true);
    }
    //Dispatch object from pool...
    public void ReturnObjectToPool(GameObject gameObject)  {
        gameObject.SetActive(false);
        objectHolder.Enqueue(gameObject);
    }
}