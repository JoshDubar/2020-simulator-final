using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBarCamera : MonoBehaviour
{
    public GameObject slider;
    public GameObject canva;
    // Update is called once per frame

    void start() {
        canva = GameObject.Find("Canvas");
        GameObject randoSlider = Instantiate(slider) as GameObject;
        randoSlider.GetComponent<FillStatusBar>().rando = this.GetComponent<RandoController>();
        randoSlider.transform.parent = canva.transform;
    }
    void Update()
    {
        ;
    }
}
