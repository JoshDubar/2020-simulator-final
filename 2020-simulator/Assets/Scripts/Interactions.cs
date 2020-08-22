using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.transform.parent == null) {
            ;
        }
        else if (collider.transform.parent.tag == "Karen") {
            Debug.Log("Karen is now going to chase you");
        }
        else if (collider.transform.parent.tag == "Rando") {
            Debug.Log("Hopefully he/she is not coughing on you");
        }
    }
}
