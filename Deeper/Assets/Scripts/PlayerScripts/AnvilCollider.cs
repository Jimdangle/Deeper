using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        GameObject colObj = col.gameObject;

        //Collide with Obstacle
        if (colObj.tag == "Obstacle")
        {
            Debug.Log("Took damage");
        }
        if (colObj.tag == "End")
        {
            Debug.Log("made it to the end");
        }
    }
}
