using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float DEFAULT_SPEED = 10.0f;
    private const bool DEFAULT_DIRECTION = true;
    public float speed = DEFAULT_SPEED;
    public bool right = DEFAULT_DIRECTION;
    public int energy;
    public int socialSkills;
    public int maskDurability;
    public int radius;
    public bool mask = true;
    Animator anim;

    void Start() {
        energy = 0;
        socialSkills = 0;
        maskDurability = 100;
        radius = 10;
        anim = GetComponent<Animator>();
        anim.SetBool("Mask",mask);
    }

    void Update() {
        Vector3 pos = transform.position;
        bool moving = true;
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") ||
        Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || 
        Input.GetKey(KeyCode.RightArrow)) {
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
                right = false;
                pos.x -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
                right = true;
                pos.x += speed * Time.deltaTime;
            }
        } else {
            moving = false;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = DEFAULT_SPEED * 2.5f;
        } else {
            speed = DEFAULT_SPEED;
        }       
        transform.position = new Vector3(pos.x, pos.y, pos.y);
        anim.SetBool("Right", right);
        anim.SetBool("Moving",moving);

        // Change radius
        Transform range = this.transform.GetChild(0);
        range.localScale = new Vector2(radius, radius / 4);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Test");
    }
}
