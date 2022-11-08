using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;
    public Rigidbody2D rb;
    float x;
    bool shouldJump = false;
    public BoxCollider2D boxcollider2d;
    public LayerMask platformsLayerMask;

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            shouldJump = true;
        }
    }
    bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, extraHeight, platformsLayerMask);
        Debug.Log(raycasthit.collider);
        return raycasthit.collider != null;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movespeed * x, rb.velocity.y);
        if (shouldJump)
        {
            rb.velocity = new Vector2(0, jumpforce);
            shouldJump = false;
        }
    }
}
