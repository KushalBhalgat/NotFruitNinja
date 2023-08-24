using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneCanvasEditor : MonoBehaviour
{
    public Text scoreText;
    public GameObject Cross1;
    public GameObject Cross2;
    public GameObject Cross3;
    public GameObject redCross1;
    public GameObject redCross2;
    public GameObject redCross3;

    public Blade bladeScript;
    void Awake()
    {
        Cross1.SetActive(true);
        Cross2.SetActive(true);
        Cross3.SetActive(true);
        redCross1.SetActive(false);
        redCross2.SetActive(false);
        redCross3.SetActive(false);
        bladeScript=GameObject.FindWithTag("Player").GetComponent<Blade>();
    }

    void Update()
    {
        scoreText.text= "SCORE : "+bladeScript.score.ToString();
        if(bladeScript.crossCount==1){
            redCross1.SetActive(true);
            Cross1.SetActive(false);

        }
        else if(bladeScript.crossCount==2){
            redCross1.SetActive(true);
            redCross2.SetActive(true);
            Cross1.SetActive(false);
            Cross2.SetActive(false);
        }
        else if(bladeScript.crossCount>=3){
            redCross1.SetActive(true);
            redCross2.SetActive(true);
            redCross3.SetActive(true);
            Cross1.SetActive(false);
            Cross2.SetActive(false);
            Cross3.SetActive(false);
        }
        
    }
}
