using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_attack : entity
{
    [SerializeField] private float attack_cooldown;
    [SerializeField] private BoxCollider2D box_collider;
    [SerializeField] private LayerMask Player;

    [SerializeField] private float range;
    [SerializeField] private float collider_distance;
    [SerializeField] private SpriteRenderer en_rd;
    [SerializeField] private float save_range;

    [SerializeField] private Animator att_anim;
    [SerializeField] private enemy_movement en_mov;
    public Transform check_player;

    public Collider2D col_player;

    private float cooldown_timer = Mathf.Infinity;
    // Update is called once per frame
    private void Update()
    {
        cooldown_timer += Time.deltaTime;
        //Attack if player in sight
        if (Player_in_sight()) {
            if(cooldown_timer >= attack_cooldown)
            {
                cooldown_timer = 0;
                att_anim.SetTrigger("attack");
            }
        }

        if (en_mov != null)
            en_mov.enabled = !Player_in_sight();

        
    }

    private bool Player_in_sight()
    {
        float direction = Mathf.Sign(en_rd.flipX ? -1 : 1);
        RaycastHit2D hit = Physics2D.BoxCast(box_collider.bounds.center + transform.right * (range = en_rd.flipX ? -range : range) * collider_distance,
            new Vector3(box_collider.bounds.size.x * (range = en_rd.flipX ? -range : range), box_collider.bounds.size.y, box_collider.bounds.size.z)
            ,0 ,Vector2.left , 0, Player);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box_collider.bounds.center + transform.right * (range = en_rd.flipX ? -range : range) * collider_distance, 
        new Vector3(box_collider.bounds.size.x * (range = en_rd.flipX ? -range : range), box_collider.bounds.size.y, box_collider.bounds.size.z));
    }

    void attack_player()
    {
        col_player = Physics2D.OverlapCircle(check_player.position, 0.5f, Player);
        col_player.GetComponent<player_attack>().take_damage(character.damage);
        print(character.damage);
    }
}
