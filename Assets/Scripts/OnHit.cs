using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHit : MonoBehaviour
{
    //is it going to destroy the incoming object?
    public bool destroy = false;
    public string hitTag = "";
    public UnityEvent onTriggerEnter;

    void OnTriggerEnter2D(Collider2D col)
    {
        //if hitTag matches incoming object's tag OR hitTag is set to nothing
        if(hitTag == col.tag ||
            hitTag == "")
        {
            if(destroy)
            {
                //Destroy it!
                Destroy(col.gameObject);
            }
            //Run Unity Event
            onTriggerEnter.Invoke();

        }
    }
}
