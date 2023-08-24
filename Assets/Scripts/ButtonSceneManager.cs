using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonSceneManager : MonoBehaviour
{
    void Start(){
        
    }

    public void LoadGame(){
        if(SceneManager.GetActiveScene().name=="MenuScene"){
            SceneManager.LoadScene("Difficulty");
        }
        else if(SceneManager.GetActiveScene().name=="Difficulty"){
            SceneManager.LoadScene("GameScene");
        }
        else if(SceneManager.GetActiveScene().name=="EndScene"){
            Destroy(mainGameAudioManager.instance.gameObject);
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void ExitGame(){
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void Update()
    {
        
    }
}
