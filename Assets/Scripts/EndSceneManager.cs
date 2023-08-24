using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
    }

    void Update()
    {
        scoreText.text="YOUR SCORE : " + GameSceneManager.instance.storeScore.ToString();
    }
}
