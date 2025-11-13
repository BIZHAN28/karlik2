using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    private int _maxLevel = 10;

    private bool _allowLevelUps = true;

    [SerializeField] private int _levelBorder = 10;

    [SerializeField]
    private int _currentLevel;

	[SerializeField] private GameObject _player;

    [SerializeField] private int _currentExp;

    [SerializeField] private Slider _expBar;

    void Start()
    {
        _expBar.maxValue = _levelBorder;
        _currentExp = 0;
        _currentLevel = 1;
        _expBar.value = 0;
    }

    public void GetExp(int exp)
    {
        if (!_allowLevelUps) return;
        _currentExp += exp;
        if (_currentExp >= _levelBorder)
        {
            _currentExp -= _levelBorder;
            _levelBorder *= 2;
            _currentLevel++;
            this.GetComponentInParent<PlayerAttack>().IncreaseDamage();
            transform.parent.GetChild(2).GetComponent<PlayerHealthSystem>().IncreaseMaxHealth();
            _expBar.maxValue = _levelBorder;
            if (_currentLevel == _maxLevel)
            {
                _allowLevelUps = false;
                _expBar.value = int.MaxValue;
                return;
            }
        }
        _expBar.value = _currentExp;
    }
}