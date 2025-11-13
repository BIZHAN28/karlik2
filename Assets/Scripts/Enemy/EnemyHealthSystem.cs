using UnityEngine;
public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private int _karmaPoints;
    private int _currentHealth;
    
    [SerializeField]
    private GameObject expPrefub;
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            GetComponent<EnemyKarma>().enabled = false;
            KarmaSystem.Instance.GetKarmaChange(_karmaPoints);
            Instantiate(expPrefub, transform.position, Quaternion.identity);
        }
    }
}