using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float turnSpeed;

    private Rigidbody2D rb;
    Vector3 lastVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(9.8f * 25f, 9.8f * 25f));
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
        lastVelocity =rb.velocity;
    }
}
