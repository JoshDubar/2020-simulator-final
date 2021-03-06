﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Character
{
    private const float DEFAULT_SPEED = 10.0f;
    private const bool DEFAULT_DIRECTION = true;
    public bool right = DEFAULT_DIRECTION;
    public int socialSkills;
    public float maskDurability;
    public int friends;
    public bool mask = true;
    private float innerRadius;
    public bool alive;
    Animator anim;
    PlayerUI playerUI;

    void Start() {
        alive = true;
        innerRadius = radius;
        moveSpeed = DEFAULT_SPEED;
        socialSkills = 10;
        maskDurability = 100;
        radius = 10;
        friends = 0;
        anim = GetComponent<Animator>();
        anim.SetBool("Mask",mask);
        playerUI = GetComponent<PlayerUI>();
    }

    void Update() {
        if (!alive) {
            HighScore.UpdateHighScore(friends);
            SceneManager.LoadScene("GameOver");
        }
        conditions();
        base.radiusChange();
        innerRadiusChange();
        innerRadiusColor();
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
        //if (Input.GetKey(KeyCode.LeftShift)) {
        //    moveSpeed = DEFAULT_SPEED * 2.5f;
        //} 
        //else {
        //    moveSpeed = DEFAULT_SPEED;
        //}       
        transform.position = new Vector3(pos.x, pos.y, pos.y);
        bool isMask = mask;
        mask = (maskDurability > 0);
        if (!mask && isMask)
        {
            SoundManager.PlaySound("mask");
        }
        anim.SetBool("Right", right);
        anim.SetBool("Moving",moving);
        anim.SetBool("Mask",mask);
        setStats();


    }

    // Update is called once per frame
    void setStats()
    {
        if (maskDurability>=0) {
            playerUI.maskHealth.text = ((int)maskDurability).ToString() + "%";
        } else {
            playerUI.maskHealth.text = "0%";
        }
        playerUI.radius.text = (((int)radius)*0.15).ToString() + "m";
        playerUI.numFriends.text = friends.ToString();
    }

    void innerRadiusChange() {
        // Change radius for the inner circle of the player
        foreach (Transform child in transform) {
            if (child.CompareTag("InnerRadius")) {
                child.localScale = new Vector2(innerRadius / 9, innerRadius / 36);
            }
        }
    }

    void innerRadiusColor() {
        foreach (Transform child in transform) {
            if (child.CompareTag("InnerRadius")) {
                if (this.mask) {
                    child.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.blue);
                }
                else {
                    child.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
                }
            }
        }
    }

    void conditions() {
        if (maskDurability > 100) {
            maskDurability = 100;
        }
        if (socialSkills < 0) {
            socialSkills = 0;
        }
        if (radius < 2.5f) {
            radius = 2.5f;
        }
    }
}
