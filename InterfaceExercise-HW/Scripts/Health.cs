using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ITake
{
    public int Take()
    {
        Debug.Log("Sağlık Arttı");
        Destroy(gameObject);
        return 50;
    }
}
