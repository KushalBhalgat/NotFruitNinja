using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudioManager : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        
    }
}
