using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GameItem")]
public class GameItem : ScriptableObject
{
    public new string name;
    public Sprite image;
    public int amount;

    

}
