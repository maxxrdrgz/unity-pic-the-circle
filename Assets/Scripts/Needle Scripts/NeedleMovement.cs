using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject needlebody;
    private bool canFireNeedle, touchedTheCircle;
    private float forceY = 5f;
    private Rigidbody2D rbody;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        needlebody.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canFireNeedle){
            rbody.velocity = new Vector2(0, forceY);
        }else{
            rbody.velocity = new Vector2(0, 0);
        }
    }

    /** 
        this function will set the needle body gameobject to be active, change
        the gameobjects rigidbody to be dynamic and set the bool canfireneedle
        to true
    */
    public void FireTheNeedle(){
        needlebody.SetActive(true);
        rbody.isKinematic = false;
        canFireNeedle = true;
    }

    /** 
        This function will detect collision between the needle body and the
        circle. If there was a collision, sets canfire needle to false,
        touchecThecircle to true and changes the rigidbody to be kinematic.

        @params {Collider2D} The other Collider2D involved in this collision.
     */
    private void OnTriggerEnter2D(Collider2D other) {
        if(touchedTheCircle){
            return;
        }

        if(other.tag == "Circle"){
            canFireNeedle = false;
            touchedTheCircle = true;
            rbody.isKinematic = true;
            gameObject.transform.SetParent(other.transform);

            if(ScoreManager.instance != null){
                ScoreManager.instance.SetScore();
            }

        }
    }
}
