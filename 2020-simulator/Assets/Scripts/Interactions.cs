﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.transform.parent != null) {
            if (collider.transform.parent.tag == "Karen") {
                Debug.Log("Karen is now going to chase you");
                collider.transform.GetComponentInParent<KarenController>().following = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.transform.parent != null) {
            if (collider.transform.parent.childCount > 1) {
                this.transform.GetComponentInParent<PlayerController>().maskDurability -= (5 * Time.deltaTime);
            }
        }
    }
}