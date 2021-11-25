using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public int poolSize = 10;
    public GameObject prefab;

    // Singleton region
    public static ObjectPooler Instance;
    private void Awake() {
        Instance = this;
    }
    // endregion

    public List<GameObject> poolList;

    private void Start() {
        poolList = new List<GameObject>();

        for (int i = 0; i < poolSize; i++) {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolList.Add(obj);
        }

    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        for (int i = 0; i < poolList.Count; i++) {
            if (!poolList[i].activeInHierarchy) {
                poolList[i].transform.position = position;
                poolList[i].transform.rotation = rotation;
                poolList[i].SetActive(true);
                IPooledObject pooledObj = poolList[i].GetComponent<IPooledObject>();
                if (pooledObj != null) {
                    pooledObj.OnObjectSpawn();
                }
            }
        }
    }
}