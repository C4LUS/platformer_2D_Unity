using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed;
    public Transform[] wai_points;
    private Transform target;
    private int dest = 0;
    private bool is_paused = false;
    private float time_paused;
    public float timer;
    public Animator en_anim;

    public SpriteRenderer en_sr;
    // Start is called before the first frame update
    void Start()
    {
        target = wai_points[0];
    }

    // Update is called once per frame

    private void OnDisable()
    {
        en_anim.SetBool("can_move", false);
    }
    void Update()
    {
        
        if(!is_paused) {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if(Vector3.Distance(transform.position, target.position) < 0.3f) 
            {
                is_paused = true;
                en_anim.SetBool("can_move", false);
                time_paused = 0.0f;
            }
        } else {
            time_paused += Time.deltaTime;
            if(time_paused >= timer) {
                en_anim.SetBool("can_move", true);
                is_paused = false;
                en_sr.flipX = !en_sr.flipX;
                dest = (dest + 1) % wai_points.Length;
                target = wai_points[dest];
            }
        }
    }
}
