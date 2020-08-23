using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendInteraction : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D collider) {
        Debug.Log("WTF");
        Transform NPC = collider.transform;
        if (NPC.parent != null) {
            if (NPC.parent.tag == "Rando" && !NPC.GetComponentInParent<RandoController>().friend) {
                if (NPC.GetComponentInParent<RandoController>().friendRatio >= 101) {
                    NPC.GetComponentInParent<RandoController>().friend = true;
                    this.transform.GetComponentInParent<PlayerController>().friends += 1;
                    Debug.Log("You have a new friend");
                    NPC.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
                    NPC.GetComponent<LineRenderer>().enabled = false;
                }
                else {
                    Debug.Log("You're developing your friendship");
                    NPC.GetComponent<DrawCircle>().activate = true;
                    NPC.GetComponent<DrawCircle>().rate += (this.transform.GetComponentInParent<PlayerController>().socialSkills * Time.deltaTime);
                    NPC.GetComponentInParent<RandoController>().friendRatio = NPC.GetComponent<DrawCircle>().index;
                    Debug.Log(NPC.GetComponent<DrawCircle>().rate);
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
