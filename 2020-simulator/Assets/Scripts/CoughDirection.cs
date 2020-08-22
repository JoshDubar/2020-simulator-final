using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoughDirection : MonoBehaviour
{
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        float x_offset = this.transform.parent.localScale.x;
        float y_offset = this.transform.parent.localScale.y;
        
        // Coughing for Rando
        if (this.transform.parent.tag == "Rando") {
            if (this.GetComponentInParent<RandoController>().right == false ) {
                sprite.flipX = true;
                this.transform.position = new Vector2(this.transform.parent.position.x - 2, this.transform.parent.position.y + 2);
            }
            else {
                sprite.flipX = false;
                this.transform.position = new Vector2(this.transform.parent.position.x + 2, this.transform.parent.position.y + 2);
            }
        }
        // Coughing for Karen
        else if (this.transform.parent.tag == "Karen") {
            if (this.GetComponentInParent<KarenController>().right == false) {
                sprite.flipX = true;
                this.transform.position = new Vector2(this.transform.parent.position.x - x_offset*2, this.transform.parent.position.y + y_offset*10);
            }
            else {
                sprite.flipX = false;
                this.transform.position = new Vector2(this.transform.parent.position.x + x_offset*2, this.transform.parent.position.y + y_offset*10);
            }
        }
        else {
            Destroy(this);
        }
    }
}
