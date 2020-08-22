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
        numberOfSeconds = this.gameObject.GetComponent<NPC>().coughRate;
    }

    public IEnumerator Wait()
    {
        isRunning = 0;
        yield return new WaitForSeconds(numberOfSeconds);
        if (this.gameObject.GetComponent<Wander>().mask < 4)
        {
            renderCough();
        }
        isRunning = 1;
    }

    private void renderCough()
    {
        GameObject a = Instantiate(cough) as GameObject;
        a.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        sprite = a.GetComponent<SpriteRenderer>();
        a.transform.parent = this.transform;
        if (this.gameObject.GetComponent<Wander>().right == false)
        {
            sprite.flipX = true;
            a.transform.position = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y + 0.12f);
        }       
        else
        {
            a.transform.position = new Vector2(this.transform.position.x + 0.5f, this.transform.position.y + 0.12f);
        }
    }
}
