using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = rigidbody2d.position;
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
            position.y = position.y + 3.0f * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        }
    }
}