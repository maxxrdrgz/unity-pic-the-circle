using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    private Text ScoreText;
    private int score;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
    }

    /** 
        This function will increment the score variable and update the score text
    */
    public void SetScore(){
        score++;
        ScoreText.text = "" + score;
    }
}
