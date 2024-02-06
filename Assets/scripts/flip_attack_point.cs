using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_attack_point : MonoBehaviour
{
    // Référence au SpriteRenderer du personnage
    public SpriteRenderer characterSpriteRenderer;

    // Update is called once per frame
    void Update()
    {
       
        bool isCharacterFlipped = characterSpriteRenderer.flipX;

        if (isCharacterFlipped)
            transform.localPosition = new Vector3(-Mathf.Abs(transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
        else
            transform.localPosition = new Vector3(Mathf.Abs(transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
    }
}

