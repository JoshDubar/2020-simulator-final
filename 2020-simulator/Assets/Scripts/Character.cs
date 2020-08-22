using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected bool alive;
    [SerializeField] protected float radius;
    private bool overlap;
    protected SpriteRenderer sprite;

    // Start is called before the first frame update
    protected virtual void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        move();
    }

    protected virtual void move() {
        ;
    }


}
