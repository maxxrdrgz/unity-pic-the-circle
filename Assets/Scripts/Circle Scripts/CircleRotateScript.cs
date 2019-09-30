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
        StartCoroutine(ChangeRotation());
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

    /** 
        This function will change the rotation speed and the rotation direction
        every 1 to 3 seconds. The rotation speed is also chosen at a random
        speed between 50 and 100.

        @param {IEnumerator} returns random delay between 1 and 3 seconds
    */
    IEnumerator ChangeRotation(){
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        if(Random.Range(0, 2) > 0){
            rotationSpeed = Random.Range(50, 100);
        }else{
            rotationSpeed = -Random.Range(50, 100);
        }
        StartCoroutine(ChangeRotation());
    }
}
