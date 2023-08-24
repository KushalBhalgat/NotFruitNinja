using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explode;
    public bool over=false;
    public float timer;
    public GameObject explosionEffect;

    public GameObject[] crossses;
    public GameObject[] redcrosses;
    public AudioSource explosionAudio;

    public int bombStrikeCounter;
    void Start(){
        timer=0f;
        explosionAudio=GetComponent<AudioSource>();
        bombStrikeCounter=0;
    }

    void Update()
    {
        if(over){
            timer+=Time.deltaTime;
            if(timer>=1.5f){
                timer=0;
                SceneManager.LoadScene("EndScene");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player") && bombStrikeCounter==0){
            bombStrikeCounter++;
            explosionEffect.SetActive(true);
            explosionAudio.Play();
            over=true;
            crossses = GameObject.FindGameObjectsWithTag("crossses");
            foreach(GameObject cross in crossses){
               cross.SetActive(false);
            }
            
        }
    }
}
