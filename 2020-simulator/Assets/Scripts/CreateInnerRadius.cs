using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInnerRadius : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject circle;
    public int offset;
    void Start()
    {
        GameObject range = Instantiate(circle) as GameObject;
        range.transform.parent = this.transform;
        range.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - offset);
        range.transform.SetSiblingIndex(1);
    }

}
