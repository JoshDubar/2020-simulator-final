using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// Karen's script
/// </summary>
public class KarenController : Character
{
    internal Transform thisTransform;
    Animator anim;
    public bool right = true;
    private Transform target;
    public bool following;

    void Start() {
        radius = 60;
        anim = GetComponent<Animator>();  
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();      

        // Cache the transform for quicker access
        thisTransform = this.transform;
        thisTransform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.y);
    }
 
    // Update is called once per frame
    void Update() {
        if (following) {
            moveSpeed = 5.0f;
            thisTransform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * moveSpeed);
            turnDirection();
            this.transform.GetComponent<Wander>().enabled = false;
            
        }
        else {
            this.transform.GetComponent<Wander>();
            right = this.transform.GetComponent<Wander>().right;
        }
        base.radiusChange();
    }
 
    void turnDirection() {
        if (transform.position.x < target.position.x) {
            right = true;
        }
        else {
            right = false;
        }
        anim.SetBool("Right", right);
    }
}