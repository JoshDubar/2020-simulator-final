﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRadius : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circle;
    public int offset;
    void Start()
    {
        GameObject range = Instantiate(circle) as GameObject;
        range.transform.parent = this.transform;
        range.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - offset);
        
        if (this.transform.tag == "Rando") {
            //range.AddComponent<DrawCircle>();
        } 
        // Green
        // Red range.GetComponent<SpriteRenderer>().colour = new Color(195, 83, 85, 50);
    }

}
