using UnityEngine;
public interface IPoolObject  {
    void PullObjectFromPool(Vector3 position);
    void ReturnObjectToPool(GameObject gameObject);
}