using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemy : MonoBehaviour
{
    private float xFactor = 0;
    private float yFactor = 0;
    private int speed = 10;
    private float range = 5.0f;
    private float smooth = 1.0f;
    private Vector3 smoothVelocity = Vector3.zero;
    private Transform heroPos;

    void Start()
    {
        heroPos = GameObject.Find("RubyHitdown").transform;
        //myPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        //Look at the player
        //transform.LookAt(heroPos);
        //Calculate distance between player
        float distance = Vector3.Distance(transform.position, heroPos.position);
        //If the distance is smaller than the walkingDistance
        if (distance < range)
        {
            //Move the enemy towards the player with smoothdamp
            transform.position = Vector3.SmoothDamp(transform.position, heroPos.position, ref smoothVelocity, smooth);
        }




        /*
        Vector2 position = transform.position;
        float dist = Vector2.Distance(position, heroPos);

        if (dist <= range)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(heroPos), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        

        // if player is in scope of flashlight
        
        float charX = GameObject.Find("RubyRunDown1").transform.position.x;
        float charY = GameObject.Find("RubyRunDown1").transform.position.y;
        float diffX = Mathf.Abs(charX - position.x);
        float diffY = Mathf.Abs(charY - position.y);
        position.x = position.x - 0.01f * 1;
        position.y = position.y - 0.01f * 1;
        transform.position = position;*/
    }
}
