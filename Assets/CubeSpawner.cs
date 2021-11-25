using UnityEngine;

public class CubeSpawner : MonoBehaviour {

    ObjectPooler objectPooler;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate() {
        objectPooler.SpawnFromPool("Cube", transform.position, Quaternion.identity);
    }

}
