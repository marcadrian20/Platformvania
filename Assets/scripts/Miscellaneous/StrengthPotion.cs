using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class StrengthPotion : MonoBehaviour
{
    public StrengthBuff strengthBuff;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<BuffableEntity>().AddBuff(strengthBuff.InitializeBuff(collision.gameObject));
        }
    }
}
