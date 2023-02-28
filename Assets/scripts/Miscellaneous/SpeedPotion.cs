using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
public class SpeedPotion : MonoBehaviour
{
    public SpeedBuff speedBuff;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.GetComponent<BuffableEntity>().AddBuff(speedBuff.InitializeBuff(collision.gameObject));
        }
    }
}
