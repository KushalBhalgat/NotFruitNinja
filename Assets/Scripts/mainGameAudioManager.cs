using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainGameAudioManager : MonoBehaviour
{
    public static mainGameAudioManager instance;
    public AudioSource menuAudio;
    public GameObject[] notDestroyedObjects;
    private void Awake() {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start(){
    }

    void Update()
    {
        /*
        if(SceneManager.GetActiveScene().name=="MenuScene"){
            notDestroyedObjects=GameObject.FindGameObjectsWithTag("menuAudio");
            foreach(GameObject a in notDestroyedObjects){
                if(notDestroyedObjects.Length>1){
                    Destroy(a.gameObject);
                }
            }
        }
        */
        
        if(SceneManager.GetActiveScene().name=="MenuScene" && !(menuAudio.isPlaying)){
            if(!menuAudio.enabled){
                menuAudio.enabled=true;
            }
            menuAudio.Play();
        }
        else if(SceneManager.GetActiveScene().name=="GameScene"){
            if(menuAudio.isPlaying){
                menuAudio.Pause();
            }
        }
        else if(SceneManager.GetActiveScene().name=="EndScene"){
            if(!menuAudio.isPlaying){
                menuAudio.Play();
            }
        }
    }
}
