using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughScript : MonoBehaviour
{
    public GameObject cough;
    public int isRunning = 1;
    public float numberOfSeconds;
    private SpriteRenderer sprite;

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
        GameObject a = Instantiate(cough) as GameObject;
        sprite = a.GetComponent<SpriteRenderer>();
        a.transform.parent = this.transform;
    }
}
