using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
/// <summary>
/// This makes an object move randomly in a set of directions, with some random time delay in between each decision
/// </summary>
public class Wander : MonoBehaviour
{
    internal Transform thisTransform;

    Animator anim;
 
    // The movement speed of the object
    public float moveSpeed = 0.2f;
 
    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;
 
    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.up+Vector3.right, 
                                                        Vector3.down+Vector3.right, Vector3.up+Vector3.left, Vector3.down+Vector3.left};
    internal int currentMoveDirection;
    public bool right = true;
    public int skin = 0;
    public int mask = 0;

    public int radius;

    public bool friend;

    public bool canFriend;

    public float friendRatio;
 
    // Use this for initialization
    void Start()
    {   
        radius = 10;
        friend = false;
        canFriend = true;
        friendRatio = 0;
        anim = GetComponent<Animator>();
        skin = Random.Range(0,4);
        mask = Random.Range(0,10);
        anim.SetInteger("Skin",skin);
        anim.SetInteger("Mask",mask);

        // Cache the transform for quicker access
        thisTransform = this.transform;
        thisTransform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.y);
 
        // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
 
        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (friendRatio >= 100) {
            friend = true;
        }
        if (currentMoveDirection==0||currentMoveDirection==4||currentMoveDirection==5) {
            right = true;
        } else {
            right = false;
        }
        // Move the object in the chosen direction at the set speed
        thisTransform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;
        thisTransform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, thisTransform.position.y);
 
        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);
            // Choose a movement direction, or stay in place
            ChooseMoveDirection();
        }
        anim.SetBool("Right", right);
        Transform range = this.transform.GetChild(0);
        range.localScale = new Vector2(radius, radius / 4);
    }
 
    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
}