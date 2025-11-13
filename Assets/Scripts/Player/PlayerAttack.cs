using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackCooldown = 1f;
    [SerializeField]
    private int _attackDamage = 10;

	private bool _rangedAllowed;
    private float _currentAttackCooldown;
    private Animator _animator;
    void Start()
    {
        _currentAttackCooldown = _attackCooldown;
        _animator = GetComponent<Animator>();
        transform.GetChild(1).GetComponent<PlayerAttackBox>().AttackDamage = _attackDamage;
    }

    void Update()
    {
        if (_currentAttackCooldown > 0)
        {
            _currentAttackCooldown -= Time.deltaTime;
        }
        else
        {
            _currentAttackCooldown = _attackCooldown;
            _animator.SetTrigger("attack");
        }
    }

	public void PickWeapon(WeaponSystem weapon)
    {
		_attackDamage += weapon.Damage;
		transform.GetChild(1).GetComponent<PlayerAttackBox>().AttackDamage = _attackDamage;

		if (weapon.Ranged)
		{
			_rangedAllowed = true;
		}
    }

    public void IncreaseDamage()
    {
        _attackDamage += 10;
    }
}
