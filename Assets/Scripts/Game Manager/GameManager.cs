using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Button shootButton;

    [SerializeField]
    private GameObject needle;
    private GameObject[] needles;
    private float needleDistance = 1.5f;
    private int needleIndex;
    [SerializeField]
    private int howManyNeedles;

    private void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
