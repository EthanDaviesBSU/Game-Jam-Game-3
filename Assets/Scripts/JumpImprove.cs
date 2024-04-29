using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpImprove : MonoBehaviour
{
    public float fastFalling = 4f;
    public float LowJump = 2.5f;

    private Rigidbody2D _RigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
       if (_RigidBody.velocity.y < 0)
       {
        _RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fastFalling - 1) * Time.deltaTime;
       }else if (_RigidBody.velocity.y > 0 && !Input.GetKey ("space"))
       {
        _RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (LowJump - 1) * Time.deltaTime;
       }
    }
}