using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public int itemValue = 1;
    public GameItem item;

    private void OnTriggerEnter2D(Collider2D collider) {
        PlayerController player = collider.GetComponent<PlayerController>();
        if (player) {

            Destroy(gameObject);
        }
        
    }
}
