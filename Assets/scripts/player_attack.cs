using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : entity
{
   
    public Animator anim_attack;
    public float time_attack;
    public float timer = 0.0f;

    public LayerMask layer_entity;
    public Transform check_enemy;

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButtonDown(0)) {
                if(Time.time > timer) {
                    anim_attack.SetBool("attack", true);
                    timer = Time.time + time_attack;
                    StartCoroutine(ResetAnimation());
                }
            }

    }

    IEnumerator ResetAnimation()
    {
        // Attends la fin de la durée de l'attaque avant de remettre l'animation à false
        yield return new WaitForSeconds(time_attack);
        
        // Remet l'animation à false
        anim_attack.SetBool("attack", false);
    }

     void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(check_enemy.position, 0.5f, layer_entity);
        foreach(Collider2D col in enemy)
            col.GetComponent<enemy_attack>().take_damage(character.damage);
    }
}
