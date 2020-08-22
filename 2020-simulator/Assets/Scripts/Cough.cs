using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cough : MonoBehaviour
{
    public GameObject cough;
    public int isRunning = 1;
    public float numberOfSeconds;
    private SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
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
        renderCough();
        isRunning = 1;
    }

    private void renderCough() {
        GameObject a = Instantiate(cough) as GameObject;
        sprite = a.GetComponent<SpriteRenderer>();
        a.transform.parent = this.transform;
        float x_offset = this.transform.localScale.x;
        float y_offset = this.transform.localScale.y;
        
        // Coughing for Rando
        if (this.gameObject.tag == "Rando") {
            if (this.gameObject.GetComponent<Wander>().right == false ) {
                sprite.flipX = true;
                a.transform.position = new Vector2(this.transform.position.x - x_offset, this.transform.position.y + y_offset);
            }
            else {
                a.transform.position = new Vector2(this.transform.position.x + x_offset, this.transform.position.y + y_offset);
            }
        }
        // Coughing for Karen
        else if (this.gameObject.tag == "Karen") {
            if (this.gameObject.GetComponent<KarenWander>().right == false) {
                sprite.flipX = true;
                a.transform.position = new Vector2(this.transform.position.x - x_offset*2, this.transform.position.y + y_offset*10);
            }
            else {
                a.transform.position = new Vector2(this.transform.position.x + x_offset*2, this.transform.position.y + y_offset*10);
            }
        }
    }
}
