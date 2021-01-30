using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Music.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
