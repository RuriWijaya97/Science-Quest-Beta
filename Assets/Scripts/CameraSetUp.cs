using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetUp : MonoBehaviour
{
    float originalWidth = 2960f;
    float originalHeight = 1440f;


  

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Camera>().aspect = (originalWidth/originalHeight)*(Screen.width/Screen.height);
        
    }

 
}
