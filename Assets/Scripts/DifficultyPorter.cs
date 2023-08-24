using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyPorter : MonoBehaviour
{
    public Slider difficultySlider;
    public float bombProbability;
    public float[] bounds; 
    
    public static DifficultyPorter instance;
    private void Awake() {
        instance=this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
    }

    void Update()
    {
        bombProbability=difficultySlider.value;
        if(bombProbability<0.2f){
            bounds[0]=0.25f;
            bounds[1]=1f;
        }
        else if(bombProbability>=0.2f && bombProbability<0.4f){
            bounds[0]=0.20f;
            bounds[1]=0.75f;
        }
        else if(bombProbability>=0.4f && bombProbability<0.6f){
            bounds[0]=0.17f;
            bounds[1]=0.6f;
        }
        else{
            bounds[0]=0.15f;
            bounds[1]=0.5f;
        }
    }
}
