using UnityEngine;
using System.Collections;
using LOS.Event;

public class LightCollision : MonoBehaviour
{
    
    void Start()
    {


        LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
        trigger.OnNotTriggered += OnNotLit;
        trigger.OnTriggered += OnLit;

        OnNotLit();
    }

    private void OnNotLit()
    {
        //do something when not lit
    }

    private void OnLit()
    {
        //do something when lit
    }
    
}