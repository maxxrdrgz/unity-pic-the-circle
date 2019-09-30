using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleHeadScript : MonoBehaviour
{
    /** 
        This function will detect collision between two needle head gameobjects.
        If true, the game ends.

        @params {Collider2D} The other Collider2D involved in this collision.
     */
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Needle Head"){
            print("Game Over");
            Time.timeScale = 0f;
        }
    }
}
