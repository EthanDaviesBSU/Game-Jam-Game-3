using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpSpeed;
    public float jumpVelocity;
    public bool isJump = false;
    private float inAir = 1;
    public Transform target;
    private Rigidbody2D _RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * moveSpeed * inAir, Space.World);
        }
        if (Input.GetKey("d"))

        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed * inAir, Space.World);
        }

        if (Input.GetKey ("space") && !isJump)
        {
            _RigidBody.AddForce(Vector2.up * jumpVelocity);
                isJump = true;
        }

        if(isJump == true)
        {
            inAir = 0.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Floor")
            {
                isJump = false;
                inAir = 1f;

            }
        }
}
