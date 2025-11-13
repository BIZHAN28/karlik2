using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public int AttackDamage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            other.gameObject.GetComponent<PlayerHealthSystem>().GetDamage(AttackDamage);
        }
    }
}
