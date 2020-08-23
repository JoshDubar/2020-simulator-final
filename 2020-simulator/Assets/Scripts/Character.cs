using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float radius;
    public float moveSpeed;
    protected const float SCALE = 4;

    protected void radiusChange() {
        // Change radius
        foreach (Transform child in transform) {
            if (child.CompareTag("Radius")) {
                child.localScale = new Vector2(radius, radius / SCALE);
            }
        }
    }
}
