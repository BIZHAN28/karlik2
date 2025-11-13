using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackCooldown = 1f;
    [SerializeField]
    private int _attackDamage = 10;
    private float _attackCooldownTimer;
    private Animator _animator;
    private bool _isAttacking = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        transform.GetChild(1).GetComponent<EnemyAttackBox>().AttackDamage = _attackDamage;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            _isAttacking = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            _isAttacking = false;
        }
    }
    void Update()
    {
        if (_isAttacking)
        {
            _attackCooldownTimer -= Time.deltaTime;
            if (_attackCooldownTimer <= 0)
            {
                _animator.SetTrigger("attack");
                _attackCooldownTimer = _attackCooldown;
            }
        }
    }
}