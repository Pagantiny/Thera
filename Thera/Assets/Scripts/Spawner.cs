using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float minTime = 12f;
    public float maxTime = 24f;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Invoke(nameof(Spawn), Random.Range(minTime, maxTime));
    }

}
