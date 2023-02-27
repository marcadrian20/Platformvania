using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class BlindnessEffect : MonoBehaviour
{
    public BlindnessDebuff blindnessDebuff;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<BuffableEntity>().AddBuff(blindnessDebuff.InitializeBuff(collision.gameObject));
        }
    }
}
