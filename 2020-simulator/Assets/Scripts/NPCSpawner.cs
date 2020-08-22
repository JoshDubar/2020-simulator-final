using UnityEngine;
using System.Collections;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npc;
    public float spawnWait;
    public int startWait;
    Vector2 screenBounds;
    Vector2 maxSpawnValues;
    Vector2 minSpawnValues;

    void Start()
    {
        StartCoroutine(Spawner());

    }

    // Update is called once per frame
    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHeight = camHalfHeight * 2.0f;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        maxSpawnValues = new Vector2(screenBounds.x + camWidth, screenBounds.y + camHeight);
        minSpawnValues = new Vector2(screenBounds.x - camWidth * 2, screenBounds.y - camHeight * 2);

    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(minSpawnValues.x, maxSpawnValues.x), Random.Range(minSpawnValues.y, maxSpawnValues.y), 1);
            Instantiate(npc, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
