using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Button shootButton;

    [SerializeField]
    private GameObject needle;
    private GameObject[] needles;
    private float needleDistance = 0.5f;
    private int needleIndex;
    [SerializeField]
    private int howManyNeedles;

    private void Awake() {
        MakeSingleton();
        SetupButton();
    }

    private void Start() {
        CreateNeedles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /** 
        Creates singleton of the GameManager instance object
    */
    void MakeSingleton(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }

    /** 
        Adds an onclick event to the shoot button, that being ShootTheNeedle()
    */
    void SetupButton(){
        shootButton.onClick.AddListener(() => ShootTheNeedle());
    }

    /** 
        This function will call the FireTheNeedle() function of a needle
        gameobject stored in the needles array. When there are no more needles
        to activate, all event listeners are removed from the shoot button.
    */
    public void ShootTheNeedle(){
        needles[needleIndex].GetComponent<NeedleMovement>().FireTheNeedle();
        needleIndex++;
        if(needleIndex == needles.Length){
            print("finished");
            shootButton.onClick.RemoveAllListeners();
        }
    }

    /** 
        Given the howManyNeedles integer, this function will instantiate all of
        the needle gameobjects
    */
    void CreateNeedles(){
        needles = new GameObject[howManyNeedles];
        Vector3 temp = transform.position;
        for(int i = 0; i < needles.Length; i++){
            needles[i] = Instantiate(needle, temp, Quaternion.identity) as GameObject;
            temp.y -= needleDistance;
        }
    }

    /** 
        This function can instantiate one needle at a time
    */
    public void InstantiateNeedle(){
        Instantiate(needle, transform.position, Quaternion.identity);
    }
}
