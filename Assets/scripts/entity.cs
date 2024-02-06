using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{
    public GameObject obj_destroy;
    [System.Serializable]
    public class Character 
    {
        public int health;
        public int health_max;
        public int damage;
    }

    public Character character;

    public void take_damage(int _damage)
    {
        character.health -= _damage;
        if (character.health <= 0) 
        {
            Destroy(obj_destroy);
        }
    }
}
