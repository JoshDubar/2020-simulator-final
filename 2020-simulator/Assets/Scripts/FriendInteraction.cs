using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInteraction : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collider) {
        Transform NPC = collider.transform;
        if (NPC.parent != null) {
            if (NPC.parent.tag == "Rando" && !NPC.GetComponentInParent<RandoController>().friend) {
                if (NPC.GetComponentInParent<RandoController>().friendRatio >= 100) {
                    NPC.GetComponentInParent<RandoController>().friend = true;
                    this.transform.GetComponentInParent<PlayerController>().friends += 1;
                    Debug.Log("You have a new friend");
                    NPC.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
                }
                else {
                    Debug.Log("You're developing your friendship");
                    NPC.GetComponentInParent<RandoController>().friendRatio += (this.transform.GetComponentInParent<PlayerController>().socialSkills * Time.deltaTime);
                    NPC.GetComponent<DrawCircle>().activate = true;

                    NPC.GetComponent<DrawCircle>().rate += (this.transform.GetComponentInParent<PlayerController>().socialSkills * Time.deltaTime);
                    //Debug.Log(NPC.GetComponent<DrawCircle>().rate);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        Transform NPC = collider.transform;
        if (NPC.parent != null && NPC.parent.tag == "Rando" && !NPC.GetComponentInParent<RandoController>().friend) {
            NPC.GetComponent<DrawCircle>().activate = false;
        }
    }
}
