using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip makeFriendSound, pickupItemSound, karenDestroyerSound, coughSound, maskSound;
    static AudioSource audioSrc;

    void Start()
    {
        makeFriendSound = Resources.Load<AudioClip>("makeFriend");
        pickupItemSound = Resources.Load<AudioClip>("itemPickUp");
        karenDestroyerSound = Resources.Load<AudioClip>("karenDie");
        coughSound = Resources.Load<AudioClip>("cough");
        maskSound = Resources.Load<AudioClip>("MaskOff");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "friend":
                audioSrc.PlayOneShot(makeFriendSound);
                break;
            case "item":
                audioSrc.PlayOneShot(pickupItemSound);
                break;
            case "karen":
                audioSrc.PlayOneShot(karenDestroyerSound);
                break;
            case "cough":
                audioSrc.PlayOneShot(coughSound);
                break;
            case "mask":
                audioSrc.PlayOneShot(maskSound);
                break;
        }
    }
}
