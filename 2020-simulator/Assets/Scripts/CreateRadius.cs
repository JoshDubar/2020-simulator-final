using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRadius : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject radius;
    void Start()
    {
        GameObject range = Instantiate(radius) as GameObject;
        range.transform.parent = this.transform;
        range.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
