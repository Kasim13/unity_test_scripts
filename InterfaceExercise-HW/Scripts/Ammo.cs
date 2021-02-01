using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour, ITake
{
    public int Take()
    {
        Debug.Log("Cephane Eklendi");
        Destroy(gameObject);
        return 20;
    }
}
