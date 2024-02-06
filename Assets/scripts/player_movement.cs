using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float move_speed;
    public float jump_force;
    private bool is_jumping;
    private bool is_grounded;
    public Transform groundcheck_right;
    public Transform groundcheck_left;

    public Animator anim;


    public Rigidbody2D rb;

    public SpriteRenderer sp_rd;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        is_grounded = Physics2D.OverlapArea(groundcheck_left.position, groundcheck_right.position);

        float move = Input.GetAxis("Horizontal") * move_speed * Time.deltaTime;
        if(Input.GetButtonDown("Jump") && is_grounded)
            is_jumping = true;
        
        flip(rb.velocity.x);
        float abs = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("speed", abs);
        move_player(move);
    }

    void move_player(float _move)
    {
        Vector3 target = new Vector2(_move, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref velocity, .05f);

        if(is_jumping == true) {
            rb.AddForce(new Vector2(0f, jump_force));
            is_jumping = false;
        }
    }


    void flip(float x) {

        if(x > 0.1f)
            sp_rd.flipX = false;
        else if (x < -0.1)
            sp_rd.flipX = true;
    }

}
