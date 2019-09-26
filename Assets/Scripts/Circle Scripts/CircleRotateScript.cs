using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotateScript : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 50f;
    private bool canRotate;
    private float angle;

    // Start is called before the first frame update
    void Awake()
    {
        canRotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canRotate){
            RotateCircle();
        }
    }

    /** 
        This function will change the z rotation of the gameobject (circle) which
        causes the gameobject to rotate.
    */
    void RotateCircle(){
        angle = transform.rotation.eulerAngles.z;
        angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,angle));
    }
}
