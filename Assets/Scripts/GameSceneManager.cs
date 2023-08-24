using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSceneManager : MonoBehaviour
{

    public int storeScore;
    public static GameSceneManager instance;
    private void Awake(){
        instance=this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update(){
        if(SceneManager.GetActiveScene().name=="GameScene"){
            storeScore=GameObject.FindWithTag("Player").GetComponent<Blade>().score;
        }
    }
}
