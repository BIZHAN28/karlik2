using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    [SerializeField]
    private Slider _healthBar;
    private int _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.maxValue = _maxHealth;
        _healthBar.value = _currentHealth;
    }

    public void GetDamage(int damage)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        _healthBar.value = _currentHealth;
        if(_currentHealth <= 0){
            SceneManager.LoadScene(2);
        }
    }
	
	public void GetHealing(HealingSystem hs)
	{
		_currentHealth = Mathf.Min(_maxHealth, _currentHealth + hs.Value);
		_healthBar.value = _currentHealth;
	}

	public void IncreaseMaxHealth()
	{
		_maxHealth += 50;
		_healthBar.maxValue = _maxHealth;
	}

}
