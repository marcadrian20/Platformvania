using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class BerserkPotion : MonoBehaviour
{
    public BerserkBuff berserkBuff;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<BuffableEntity>().AddBuff(berserkBuff.InitializeBuff(collision.gameObject));//Whenever the player collides with the potion we initialize the "buff"
        }
    }
}

