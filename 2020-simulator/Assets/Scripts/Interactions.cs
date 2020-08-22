using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.transform.parent != null) {
            if (collider.transform.parent.tag == "Karen") {
                collider.transform.GetComponentInParent<KarenWander>().following = true;
                Debug.Log("Karen is now going to chase you");
            }
            if (collider.transform.parent.tag == "Rando" && collider.transform.GetComponentInParent<Wander>().friend && collider.transform.GetComponentInParent<Wander>().canFriend)
             {
                this.transform.GetComponentInParent<PlayerController>().numFriends += 1;
                collider.transform.GetComponentInParent<Wander>().canFriend = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.transform.parent != null) {
            if (collider.transform.parent.childCount > 1) {
                this.transform.GetComponentInParent<PlayerController>().currentMaskDurability -= (5 * Time.deltaTime);
            }
            if ((collider.transform.parent.tag == "Rando") && !(collider.transform.GetComponentInParent<Wander>().friend)) {
                collider.transform.GetComponentInParent<Wander>().friendRatio += 10* Time.deltaTime;
            }
            if (collider.transform.parent.tag == "Rando" && collider.transform.GetComponentInParent<Wander>().friend && collider.transform.GetComponentInParent<Wander>().canFriend)
            {
                this.transform.GetComponentInParent<PlayerController>().numFriends += 1;
                collider.transform.GetComponentInParent<Wander>().canFriend = false;
            }
        }

    }
}
