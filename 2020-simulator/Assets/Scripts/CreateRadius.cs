using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRadius : MonoBehaviour
{
    // Start is called before the first frame update
<<<<<<< HEAD
    public GameObject circle;

=======
    public GameObject radius;
>>>>>>> 3aff802611063af85cba43d833772f7fb989f879
    public int offset;
    void Start()
    {
        GameObject range = Instantiate(circle) as GameObject;
        range.transform.parent = this.transform;
        range.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - offset);
    }

}
