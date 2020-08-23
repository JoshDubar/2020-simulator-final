﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : Character
{
    private const float DEFAULT_SPEED = 10.0f;
    private const bool DEFAULT_DIRECTION = true;
    public bool right = DEFAULT_DIRECTION;
    public int energy;
    public int socialSkills;
    public float maskDurability;
    public int friends;
    public bool mask = true;
    Animator anim;
    PlayerUI playerUI;

    void Start() {
        moveSpeed = DEFAULT_SPEED;
        energy = 0;
        socialSkills = 0;
        maskDurability = 100;
        radius = 10;
        friends = 0;
        anim = GetComponent<Animator>();
        anim.SetBool("Mask",mask);
        playerUI = GetComponent<PlayerUI>();
    }

    void Update() {
        Vector3 pos = transform.position;
        bool moving = true;
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow)) {
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
                pos.y += moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
                pos.y -= moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
                right = false;
                pos.x -= moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
                right = true;
                pos.x += moveSpeed * Time.deltaTime;
            }
        } 
        else {
            moving = false;
        }
        if (Input.GetKey(KeyCode.LeftShift)) {
            moveSpeed = DEFAULT_SPEED * 2.5f;
        } 
        else {
            moveSpeed = DEFAULT_SPEED;
        }       
        transform.position = new Vector3(pos.x, pos.y, pos.y);
        anim.SetBool("Right", right);
        anim.SetBool("Moving",moving);
        setStats();
        base.radiusChange();
    }

    // Update is called once per frame
    void setStats()
    {
        playerUI.maskHealth.text = ((int)maskDurability).ToString() + "%";
        playerUI.radius.text = (radius*0.15).ToString() + "m";
        playerUI.numFriends.text = friends.ToString();
    }
}
