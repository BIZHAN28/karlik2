using UnityEngine;
public class KarmaSystem : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField]
    private int _currentCount;

     public static KarmaSystem Instance { get; private set; }

     public KarmaSystem()
    {
        Instance = this;
    }

    void Start()
    {
        _currentCount = 100;
    }

    public void GetKarmaChange(int change)
    {
        _currentCount = Mathf.Max(0, _currentCount + change);
		_enemySpawner.GetComponent<EnemySpawner>().SetIndex(_currentCount);
        EventBus.Instance.Invoke(new KarmaChangedSignal(_currentCount));
    }

}