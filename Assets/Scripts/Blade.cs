using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;


public class Blade : MonoBehaviour
{
    
    public float minSlicingVelocity=0.01f;
    private Camera mainCamera;
    private Collider bladeCollider;
    public bool slicing;
    public Vector3 bladeDirection {get;private set;} 
    public TrailRenderer bladeTrail;
    public float sliceForce=0.1f;
    public float timer;
    public int score;
    public int crossCount;
    public Touch touch;

    private void Awake() {
        score=0;    
        timer=0f;
    }
    void Start()
    {
        mainCamera=Camera.main;
        slicing=false;
        bladeCollider=GetComponent<SphereCollider>();
        bladeTrail=GetComponentInChildren<TrailRenderer>();
    }

    void Update()
    {
        if(Input.touchCount>0){
            Touch touch =Input.GetTouch(0);
        }
        if(Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene("EndScene");
        }

        Vector3 mousepos=mainCamera.ScreenToWorldPoint(touch.position);
        mousepos.z=0f;

        Vector3 currentPosition=transform.position;
        bladeDirection=mousepos-currentPosition;
        if(bladeDirection.magnitude/Time.deltaTime>minSlicingVelocity){
            slicing=true;
        }
        else{
            slicing=false;
        }
        
        if(slicing){
            bladeCollider.enabled=true;
            bladeTrail.enabled=true;
            bladeTrail.Clear();

        }
        else{
            bladeCollider.enabled=false;
            bladeTrail.enabled=false;
        }
        transform.position=mousepos;
        if(crossCount>=3){
            timer+=Time.deltaTime;
            if(timer>1f){
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
