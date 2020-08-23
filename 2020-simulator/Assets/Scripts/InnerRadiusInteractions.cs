using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerRadiusInteractions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.parent != null)
        {
            if (collider.transform.parent.tag == "Karen")
            {
                Debug.Log("Karen is now going to chase you");
                collider.transform.GetComponentInParent<KarenController>().following = true;
                collider.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Transform NPC = collider.transform;
        if (NPC.parent != null)
        {
            if (NPC.parent.childCount > 1)
            {
                if (this.transform.GetComponentInParent<PlayerController>().mask)
                {
                    this.transform.GetComponentInParent<PlayerController>().maskDurability -= (15 * Time.deltaTime);
                }
                else
                {
                    this.transform.GetComponentInParent<PlayerController>().alive = false;
                }
            }
            else
            {
                this.transform.GetComponentInParent<PlayerController>().maskDurability -= 5 * Time.deltaTime;
            }
        }
    }
}