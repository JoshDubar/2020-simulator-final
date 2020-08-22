using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float radius;
    public float moveSpeed;

    protected void radiusChange() {
        // Change radius
        Transform range = this.transform.GetChild(0);
        range.localScale = new Vector2(radius, radius / 4);
    }
}
