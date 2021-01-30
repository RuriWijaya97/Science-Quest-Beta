using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    float originalWidth = 1920f;
    float originalHeight = 1080f;


  

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Camera>().aspect = (originalWidth/originalHeight)*(Screen.width/Screen.height);
        
    }

 
}
