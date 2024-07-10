using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideController : MonoBehaviour
{
    public float glideGravityScale = 0.5f;
    public float normalGravityScale = 1.0f;
    public float glideControl = 2.0f;

    private Rigidbody rb;
    private bool isGliding = false;
    private float initialDrag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialDrag = rb.drag;
    }

    public void HandleGlide(bool jumpIsHeld, bool jumpWasReleased)
    {
        if (jumpIsHeld && rb.velocity.y < 0)
        {
            isGliding = true;
        }

        if (jumpWasReleased || rb.velocity.y >= 0)
        {
            isGliding = false;
        }
    }

    void FixedUpdate()
    {
        if (isGliding)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y, -glideControl), rb.velocity.z);
            rb.drag = glideGravityScale;
        }
        else
        {
            rb.drag = initialDrag;
        }
    }
}
