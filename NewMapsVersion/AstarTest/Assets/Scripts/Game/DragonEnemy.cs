using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOS.Event;

public class DragonEnemy : MonoBehaviour
{
    private float range = 5.0f;
    public float smooth = 1.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    private Transform heroPos;
    private Rigidbody rb;
    private LOSEventTrigger trigger;
    private bool freeze = false;

    private void OnNotLit()
    {
        freeze = false;
        rb.isKinematic = true;
    }

    private void OnLit()
    {
        freeze = true;
        rb.isKinematic = false;

    }

    void Start()
    {
        heroPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        trigger = this.gameObject.GetComponent<LOSEventTrigger>();
        trigger.OnNotTriggered += OnNotLit;
        trigger.OnTriggered += OnLit;
    }

    // Update is called once per frame
    void Update()
    {
        if (!freeze)
        {
            float distance = Vector3.Distance(transform.position, heroPos.position);
            //If the distance is smaller than the walkingDistance
            if (distance < range)
            {
                //Move the enemy towards the player with smoothdamp
                transform.position = Vector3.SmoothDamp(transform.position, heroPos.position, ref smoothVelocity, smooth);
            }
        }
    }
}
