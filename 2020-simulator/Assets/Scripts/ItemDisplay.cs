﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public GameItem item;
    public int amount;
    private Vector2 screenBounds;
    public new string name;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.image;
        this.amount = item.amount;
        this.name = item.name;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player != null) {
            
            switch (name) {
                case "Pancake":
                    player.moveSpeed += 2;
                    SoundManager.PlaySound("item");
                    break;
                case "MaskBox":
                    player.maskDurability += 30f;
                    SoundManager.PlaySound("item");
                    break;
                case "KarenDestroyer":
                    DestroyKarens();
                    break;
                case "Teddy":
                    player.socialSkills += 5;
                    SoundManager.PlaySound("item");
                    break;
                case "ToiletPaper":
                    player.radius += 0.2f;
                    SoundManager.PlaySound("item");
                    break;

            }
            Destroy(gameObject);
        }
    }

    private void DestroyKarens()
    {
        object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
        List<GameObject> karens = new List<GameObject>();
        foreach (object o in obj)
        {
            GameObject g = (GameObject)o;
            if (g.name == "Karen(Clone)")
            {
                karens.Add(g);
            }
        }
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHeight = 2.0f * camHalfHeight;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        SoundManager.PlaySound("karen");
        for (int i = karens.Count - 1; i >= 0; i--)
        {
            GameObject karen = karens[i];
            float x = karen.transform.position.x;
            float y = karen.transform.position.y;
            if (screenBounds.x - camWidth < x && x < screenBounds.x && screenBounds.y - camHeight < y  && y < screenBounds.y)
            {
                Destroy(karen);
            }
        }
    }
}
