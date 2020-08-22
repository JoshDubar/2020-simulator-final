using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public bool mask = false;
    public float coughRate;
    private float coreRadius = 8.0f;

    void Start() {
        // Randomly assign if the NPC has a mask on
        //int maskProbability = Random.Range(0, 10);
        //if (maskProbability > 7) {
        //    mask = true;
        //    coughRate = Random.Range(5, 10);
        //}
        coughRate = Random.Range(5, 15);
    }
    void Update() {
        // Update radius
        if (transform.childCount > 0) {
            Transform range = this.transform.GetChild(0);
            range.localScale = new Vector2(coreRadius, coreRadius/4);
        }
    }
}



