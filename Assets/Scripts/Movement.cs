using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpVelocity;
    public bool isJump = false;
    public float movementEase = 0.5f;
    private bool isMoving = false;
    public Transform target;
    private Rigidbody2D _RigidBody;
    private Collider2D _FootCollider;
    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody2D>();
        _FootCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "death")
            {
                transform.position = new Vector3(1.0f, 1.0f, 1.0f);
            }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            isMoving = true;
            if (movementEase < 1.25)
            {
                movementEase += 0.5f * Time.deltaTime;
            }
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed * movementEase, Space.World);
        }
        if (Input.GetKey("d"))
        {
            isMoving = true;
            if (movementEase < 1.25)
            {
                movementEase += 0.5f * Time.deltaTime;
            }
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed * movementEase, Space.World);
        }
        if (Input.GetKeyUp("a"))
        {
            isMoving = false;
        }
        if (Input.GetKeyUp("d"))
        {
            isMoving = false;
        }
        if (!isMoving)
        {
            movementEase = 0.5f;
        }
        if (Input.GetKey ("space") && !isJump)
        {
            _RigidBody.AddForce(Vector2.up * jumpVelocity);
            isJump = true;
        }
        
    }
}