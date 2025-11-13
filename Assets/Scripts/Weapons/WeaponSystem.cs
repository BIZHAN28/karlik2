using UnityEngine;
using UnityEngine.UI;

public enum WeaponType
{
	Melee,
	Ranged
}

public class WeaponSystem : MonoBehaviour
{

	[SerializeField]
	private WeaponType _type = WeaponType.Melee;

	[SerializeField]
	private int _damage = 10;

	public WeaponType Type => _type;
	public bool Melee => _type == WeaponType.Melee;
	public bool Ranged => _type == WeaponType.Ranged;
	public int Damage => _damage;

	private void OnTriggerEnter2D(Collider2D other)
	{
		var playerAttack = other.GetComponentInParent<PlayerAttack>();
		if (playerAttack == null)
		{
			playerAttack = other.GetComponent<PlayerAttack>();
		}

		if (playerAttack != null)
		{
			playerAttack.PickWeapon(this);
			Destroy(gameObject);
		}
	}
}