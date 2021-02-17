using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Tooltip("0 for speed, 1 for jump force, 2 for money")]
    public int collectibleType;
    public void Collected()
    {
        gameObject.SetActive(false);
    }
}
