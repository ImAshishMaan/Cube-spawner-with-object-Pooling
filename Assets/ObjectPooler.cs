using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {
    /*[System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }*/

    public int poolSize = 10;
    public GameObject prefab;

    // Singleton region
    public static ObjectPooler Instance;
    private void Awake() {
        Instance = this;
    }
    // endregion

    //public List<Pool> pools;
    //public Dictionary<string, Queue<GameObject>> poolDict;

    public List<GameObject> poolList;

    private void Start() {
        //poolDict = new Dictionary<string, Queue<GameObject>>();

        poolList = new List<GameObject>();

        //foreach (Pool pool in pools) {
            //Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++) {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false);
                //objectPool.Enqueue(obj);
                poolList.Add(obj);
            }

            //poolDict.Add(pool.tag, objectPool);

        //}
    }

    public void SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        //if (!poolDict.ContainsKey(tag)) {
        //    Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
        //    return null;
        //}
        //GameObject objectToSpawn = poolDict[tag].Dequeue();

        for(int i=0; i< poolList.Count; i++) {
            if (!poolList[i].activeInHierarchy) {
                poolList[i].transform.position = position;
                poolList[i].transform.rotation = rotation;
                poolList[i].SetActive(true);
                IPooledObject pooledObj = poolList[i].GetComponent<IPooledObject>();
                if(pooledObj != null) {
                    pooledObj.OnObjectSpawn();
                }
                //Deactivate(i);
            }
        }
        
        //objectToSpawn.SetActive(true);
        //objectToSpawn.transform.position = position;
        //objectToSpawn.transform.rotation = rotation;

        //IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        //if (pooledObj != null) {
        //    pooledObj.OnObjectSpawn();
        //}

        //poolDict[tag].Enqueue(objectToSpawn);

        //return objectToSpawn;
    }
    private void Deactivate(int i) {
        
    }

    private void Destroy(int i) {

        poolList[i].SetActive(false);
    }

}
