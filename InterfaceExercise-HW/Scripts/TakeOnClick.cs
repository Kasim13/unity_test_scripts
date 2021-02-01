using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeOnClick : MonoBehaviour
{
    int value;
    Text txt;
    void Start()
    {
        txt = GameObject.Find("Canvas/Text").GetComponent<Text>();
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo))
            {
                ITake takeable = hitInfo.collider.GetComponent<ITake>();
                if (takeable != null)
                {
                    takeable.Take();
                    
                }                 
            }
        }
    }
}
