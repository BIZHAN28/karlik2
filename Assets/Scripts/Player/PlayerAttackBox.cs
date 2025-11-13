using UnityEngine;
public class PlayerAttackBox : MonoBehaviour
{
    public int AttackDamage = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealthSystem>().GetDamage(AttackDamage);
        } else if (other.gameObject.CompareTag("CryptHitBox"))
        {
            other.gameObject.GetComponent<CryptHealthSystem>().GetDamage(AttackDamage);
        }
    }
}