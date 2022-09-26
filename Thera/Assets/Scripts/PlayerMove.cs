using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3f;
    Rigidbody2D body;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, vertical, 0) * speed;

        body.MovePosition(transform.position + input * speed * Time.deltaTime);

        float horizontalRaw = Input.GetAxisRaw("Horizontal");
        float verticalRaw = Input.GetAxisRaw("Vertical");

        if (horizontalRaw != 0 || verticalRaw != 0)
        {
            transform.up = input;
        }
    }

}
