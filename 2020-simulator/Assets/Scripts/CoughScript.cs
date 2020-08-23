using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughScript : MonoBehaviour
{
    public GameObject cough;
    public int isRunning = 1;
    public float numberOfSeconds;
    private SpriteRenderer sprite;
    private Vector2 screenBounds;
    // Update is called once per frame
    void Update() {
        int randomNum = Random.Range(1, 12);
        if (isRunning == 1 && randomNum%3 == 0) 
        {
            StartCoroutine(Wait());
        }
        numberOfSeconds = Random.Range(5, 15);
    }

    public IEnumerator Wait()
    {
        isRunning = 0;
        yield return new WaitForSeconds(numberOfSeconds);
        if (this.gameObject.tag == "Karen") {
            renderCough();
        }
        else if (this.gameObject.tag == "Rando" && this.gameObject.GetComponent<RandoController>().mask < 4) {
            renderCough();
        }
        isRunning = 1;
    }

    private void renderCough() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHeight = 2.0f * camHalfHeight;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        float x = transform.position.x, y = transform.position.y;
        if (screenBounds.x - camWidth < x && x < screenBounds.x && screenBounds.y - camHeight < y && y < screenBounds.y)
        {
            SoundManager.PlaySound("cough");
            GameObject a = Instantiate(cough) as GameObject;
            sprite = a.GetComponent<SpriteRenderer>();
            a.transform.parent = this.transform;
        }
    }
}
