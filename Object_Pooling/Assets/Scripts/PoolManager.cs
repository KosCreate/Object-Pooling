using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolManager : MonoBehaviour  {
    [SerializeField] private List<Pool> scriptable_Pools = new List<Pool>();
    private Dictionary<int, Pool> _pools = new Dictionary<int, Pool>();
    private List<int> poolIDs = new List<int>();
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnSphereRadius;
    private void Start() => Initialization();

    private void Update() {
        //For testing...
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Generate());
        }
    }
    //For testing...
    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(1.0f);
        int random = Random.Range(0, poolIDs.Count);
        int rndID = poolIDs[random];
        Debug.Log($"POOL SELECTED : {rndID}");
        if (_pools.ContainsKey(rndID)) {
            for (int i = 0; i < _pools[rndID].poolSize; i++) {
                _pools[rndID].PullObjectFromPool(GetRandomPos());
            }
        }
    }
    void Initialization()  {
           for (int i = 0; i < scriptable_Pools.Count; i++)  {
            scriptable_Pools[i].InitializePool();
            Debug.Log(scriptable_Pools[i].poolID);
            _pools.Add(scriptable_Pools[i].poolID, scriptable_Pools[i]);
            poolIDs.Add(scriptable_Pools[i].poolID);
           }

           int random = Random.Range(0, poolIDs.Count);
           int rndID = poolIDs[random];
           Debug.Log($"POOL SELECTED : {rndID}");
           if (_pools.ContainsKey(rndID)) {
               for (int i = 0; i < _pools[rndID].poolSize; i++) {
                   _pools[rndID].PullObjectFromPool(GetRandomPos());
               }
           }
       }
       private Vector3 GetRandomPos()  {
        Vector3 randPos = Random.insideUnitCircle * spawnSphereRadius;
        return randPos;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnSphereRadius);        
    }
}