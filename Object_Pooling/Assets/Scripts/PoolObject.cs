using System;
using UnityEngine;
public class PoolObject : MonoBehaviour  {
    public Pool objectPool;
    public void OnInit(Pool pool)  { objectPool = pool;  }
    //For testing...
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.activeInHierarchy)  {
            OnCleanUp();
        }
    }

    private void OnCleanUp()  { objectPool.ReturnObjectToPool(gameObject); }

    private void OnTriggerEnter(Collider other)  { OnCleanUp(); }
}
