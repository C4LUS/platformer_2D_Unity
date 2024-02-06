using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour
{
    public GameObject player;
    public float time_offset;
    public Vector3 pos_offset;

    private Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        transform.position =Vector3.SmoothDamp(transform.position, player.transform.position + pos_offset, ref velocity, time_offset);
    }
}
