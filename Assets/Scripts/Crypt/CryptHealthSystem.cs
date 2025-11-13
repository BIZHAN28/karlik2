using UnityEngine;
public class CryptHealthSystem : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth = 100;
    private int _currentHealth;
    private int lastKarma = 100;
    void Start()
    {
        _currentHealth = _maxHealth;
        EventBus.Instance.Subscribe<KarmaChangedSignal>(OnKarmaChanged);
    }

    public void OnKarmaChanged(KarmaChangedSignal signal)
    {
        if (signal.Karma < 75 && lastKarma >= 75)
        {
            lastKarma = signal.Karma;
            if (Random.Range(0,3) == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        } else if (signal.Karma < 50 && lastKarma >= 50)
        {
            lastKarma = signal.Karma;
            if (Random.Range(0,3) == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        } else if (signal.Karma < 25 && lastKarma >= 25)
        {
            lastKarma = signal.Karma;
            if (Random.Range(0,3) == 0)
            {
                Destroy(transform.parent.gameObject);
            }
        } else if (signal.Karma == 0){
            Destroy(transform.parent.gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnDestroy()
    {
        EventBus.Instance.Unsubscribe<KarmaChangedSignal>(OnKarmaChanged);
    }

}
