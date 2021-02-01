using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour, ITake
{
    public int Take()
    {
        Debug.Log("Enerji Kazanıldı");
        Destroy(gameObject);
        return 25;
    }
}
