using UnityEngine;

public class EnemyShotAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackCooldown = 1f;
    [SerializeField]
    private int _attackDamage = 10;
    [SerializeField]
    private float _bulletSpeed = 10f;
    private float _attackCooldownTimer;
    private GameObject _bullet;
    private bool _isAttacking = false;
    private Collider2D _playerCollider;

    void Start()
    {
        transform.GetChild(1).GetComponent<EnemyAttackBox>().AttackDamage = _attackDamage;
        _bullet = transform.GetChild(1).gameObject;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerHitBox"))
        {
            _isAttacking = true;
            _playerCollider = other;
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
                Vector2 direction = _playerCollider.transform.position - transform.position;
                direction.Normalize();
                _bullet.transform.position = transform.position;
                _bullet.SetActive(true);
                _bullet.GetComponent<Rigidbody2D>().velocity = direction * _bulletSpeed;
                _attackCooldownTimer = _attackCooldown;
            }
        }
        if (_bullet.transform.position.x > 10 || _bullet.transform.position.x < -10 || _bullet.transform.position.y > 10 || _bullet.transform.position.y < -10)
        {
            _bullet.SetActive(false);
        }
    }
}