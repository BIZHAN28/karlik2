using UnityEngine;
using System.Collections.Generic;

public class EnemyKarma : MonoBehaviour
{
    private float lastKarma = 100;
    private bool _isEvolving = false;
    private int _upgradeIndex = 0;
    private Dictionary<int, GameObject> _enemyUpgrade;
    
    void Start()
    {
        EventBus.Instance.Subscribe<KarmaChangedSignal>(OnKarmaChanged);
        _enemyUpgrade = EnemySpawner.Instance.GetEnemies;
    }

    void OnKarmaChanged(KarmaChangedSignal signal)
    {
        if (signal.Karma < 75 && lastKarma >= 75)
        {
            _isEvolving = true;
            Destroy(gameObject);
            _upgradeIndex = 2;
        } else if (signal.Karma < 50 && lastKarma >= 50)
        {
            _isEvolving = true;
            Destroy(gameObject);
            _upgradeIndex = 1;
        } else if (signal.Karma < 25 && lastKarma >= 25)
        {
            _isEvolving = true;
            Destroy(gameObject);
            _upgradeIndex = 0;
        }
        lastKarma = signal.Karma;
    }

    void OnDestroy()
    {
        EventBus.Instance.Unsubscribe<KarmaChangedSignal>(OnKarmaChanged);
        if (_isEvolving)
        {
            Instantiate(_enemyUpgrade[_upgradeIndex], transform.position, Quaternion.identity);
        } else {
            EnemySpawner.Instance.Dead();
        }
    }
}