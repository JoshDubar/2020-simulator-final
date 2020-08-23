using System.Collections;
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

    void Update() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float screenAspect = (float)Screen.width/(float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        if (transform.position.x < (screenBounds.x - camWidth * 2) || transform.position.x > (screenBounds.x + camWidth) || transform.position.y > screenBounds.y + camHalfHeight) {
            
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider) {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player != null) {
            switch (name) {
                case "Pancake":
                    player.energy += amount;
                    break;
                case "MaskBox":
                    player.maskDurability += amount;
                    break;
                case "KarenDestroyer":
                    player.energy += amount;
                    break;
                case "Teddy":
                    player.socialSkills += amount;
                    break;
                case "ToiletPaper":
                    player.radius += amount;
                    break;

            }
            Destroy(gameObject);
        }
    }
}
