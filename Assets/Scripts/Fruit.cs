using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;
    private Collider fruitCollider;
    private Rigidbody fruitBody;
    private ParticleSystem juice;
    public int crossCount;
    private GameObject[] fruits;
    public Blade blade;
    private float timer;

    public AudioSource juiceAudio;
    public AudioSource strikeAudio;

    private void Awake() {
        fruitCollider=GetComponent<Collider>();
        fruitBody =GetComponent<Rigidbody>();
        juice= GetComponentInChildren<ParticleSystem>();
        blade=GameObject.FindWithTag("Player").GetComponent<Blade>();
        timer=0f;
    }

    
    private void slicer(Vector3 direction,Vector3 position, float Force){
        whole.SetActive(false);
        sliced.SetActive(true);
        juice.Play();
        juiceAudio.Play();
        fruitCollider.enabled=false;
        sliced.transform.rotation=Quaternion.Euler(0f,0f,Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg);
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices){
            slice.velocity=fruitBody.velocity;
            slice.AddForceAtPosition(direction*Force,position,ForceMode.Impulse);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            this.gameObject.tag="dead";
            Blade blade= other.GetComponent<Blade>();
            blade.score++;
            slicer(blade.bladeDirection,blade.transform.position,blade.sliceForce);
        }
        if(other.CompareTag("deathZone") && this.gameObject.tag=="fruit" && timer>=3f){
            blade.crossCount++;
            strikeAudio.Play();
            if(timer>4f){
                Destroy(this.gameObject);
            }
            timer=0f;
        }
        else if(other.CompareTag("deathZone") && this.gameObject.tag=="dead"){
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        timer+=Time.deltaTime;
    }
}
