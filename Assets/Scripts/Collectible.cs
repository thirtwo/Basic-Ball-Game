using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Tooltip("0 for speed, 1 for jump force.")]
    public int collectibleType;
    public void Collected()
    {
        gameObject.SetActive(false);
    }
}
