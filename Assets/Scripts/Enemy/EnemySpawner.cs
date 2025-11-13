using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct EnemyData
{
    public GameObject enemy;
    public int priotity;
}

public class EnemySpawner : MonoBehaviour
{
    public Dictionary<int, GameObject> _enemyPrefabs = new ();
    public EnemyData[] _enemyUpgrades;
    public static EnemySpawner Instance { get; private set; }

    public EnemySpawner()
    {
        Instance = this;
    }

    private int _currentIndex = 0;
    [SerializeField]
    private int _maxEnemies = 15;
    [SerializeField]
    private Transform _cameraTransform;

    private int _currentEnemies = 0;

    public Dictionary<int, GameObject> GetEnemies => _enemyPrefabs;
    
	public void Dead()
	{
		_currentEnemies--;
	}
    private float _cameraWidth;

    public void Start()
    {
		_currentIndex = _enemyUpgrades.Length - 1;
        _cameraWidth = _cameraTransform.GetComponent<Camera>().orthographicSize * _cameraTransform.GetComponent<Camera>().aspect;
        foreach (var enemyData in _enemyUpgrades)
        {
            _enemyPrefabs[enemyData.priotity] = enemyData.enemy;
        }
    }
    public void FixedUpdate()
    {
        if (_currentEnemies < _maxEnemies)
        {
            _currentEnemies++;
            Vector2 randomPoint = new Vector2(Random.Range(0f, _cameraWidth), Random.Range(0f, _cameraWidth)) + new Vector2(_cameraTransform.position.x, _cameraTransform.position.y);
            var enemyPrefab = _enemyPrefabs[_currentIndex];
            switch (Random.Range(0, 4))
            {
                case 0:
                    randomPoint.x += _cameraWidth; 
                    Instantiate(enemyPrefab, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
                    break;
                case 1:
                    randomPoint.x -= _cameraWidth;
                    Instantiate(enemyPrefab, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
                    break;
                case 2:
                    randomPoint.y += _cameraWidth;
                    Instantiate(enemyPrefab, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
                    break;
                case 3:
                    randomPoint.y -= _cameraWidth;
                    Instantiate(enemyPrefab, new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
                    break;
            }
        }
    }

	public void SetIndex(int value){
        var newIndex = Mathf.Min(value / 25, 3);
        if (_currentIndex < newIndex)
            _maxEnemies = Mathf.Max(_maxEnemies - 5, 10);
        if (_currentIndex > newIndex)
            _maxEnemies = Mathf.Min(_maxEnemies + 5, 40);
		_currentIndex = newIndex;
    }
}