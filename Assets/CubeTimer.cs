
using UnityEngine;

public class CubeTimer : MonoBehaviour
{
    [SerializeField] private float timer = 3f;

    private void OnEnable() {
        Invoke("DeactivateCube", Random.Range(0, timer));
    }

    private void DeactivateCube() {
        if (gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
        }
    }
}
