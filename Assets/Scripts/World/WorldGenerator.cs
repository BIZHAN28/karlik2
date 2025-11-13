using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [Header("World Settings")]
    public int worldSize = 10;
    public int chunkSize = 16;

    public float obstacleProp;

    [SerializeField]
    public float cryptProp;


    [Header("Prefabs")]
    public GameObject[] terrainPrefabs;
    public GameObject[] obstaclePrefabs;
    public GameObject cryptPrefab;
    // public GameObject flaskPrefab;

    private MapChunk[,] chunks;

    void Start()
    {
        GenerateWorld();
        GenerateBorders();
    }

    

    void GenerateWorld()
    {
        chunks = new MapChunk[worldSize, worldSize];

        for (int x = 0; x < worldSize; x++)
        {
            for (int y = 0; y < worldSize; y++)
            {
                chunks[x, y] = new MapChunk(chunkSize, obstacleProp, cryptProp);
                chunks[x, y].Generate(terrainPrefabs, obstaclePrefabs, cryptPrefab, x, y, worldSize);
            }
        }

        // PlaceCrypts();
        // PlaceFlasks();
    }

    void GenerateBorders()
    {
        int totalSize = worldSize * chunkSize;
        int offset = totalSize / 2;

        int borderThickness = 8;

        for (int x = -borderThickness; x < totalSize + borderThickness; x++)
        {
            for (int y = -borderThickness; y < totalSize + borderThickness; y++)
            {
                bool isOutside = (x < 0 || y < 0 || x >= totalSize || y >= totalSize);
                if (isOutside)
                {
                    PlaceGroundBlock(x - offset, y - offset);
                }
            }
        }

        for (int x = 0; x < totalSize; x++)
        {
            PlaceBorderBlock(x - offset, -offset);                   
            PlaceBorderBlock(x - offset, totalSize - 1 - offset);      
        }

        for (int y = 0; y < totalSize; y++)
        {
            PlaceBorderBlock(-offset, y - offset);                   
            PlaceBorderBlock(totalSize - 1 - offset, y - offset);     
        }
    }

    void PlaceBorderBlock(int x, int y)
    {
        if (obstaclePrefabs.Length == 0) return;

        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Vector3 pos = new Vector3(x, y, 0);

        Instantiate(prefab, pos, Quaternion.identity);
    }

    void PlaceGroundBlock(int x, int y)
    {
        if (terrainPrefabs.Length == 0) return;

        GameObject prefab = terrainPrefabs[Random.Range(0, terrainPrefabs.Length)];
        Vector3 pos = new Vector3(x, y, 0);

        Instantiate(prefab, pos, Quaternion.identity);
    }

    // void PlaceCrypts()
    // {
    //     int maxCrypts = worldSize * worldSize / 2;

    //     for (int i = 0; i < maxCrypts; i++)
    //     {
    //         int x = Random.Range(0, worldSize);
    //         int y = Random.Range(0, worldSize);
    //         Vector3 pos = new Vector3(x * chunkSize, 0, y * chunkSize);

    //         Instantiate(cryptPrefab, pos, Quaternion.identity);
    //     }
    // }

    // void PlaceFlasks()
    // {
    //     int count = Random.Range(10, 20);
    //     for (int i = 0; i < count; i++)
    //     {
    //         int x = Random.Range(0, worldSize);
    //         int y = Random.Range(0, worldSize);
    //         Vector3 pos = new Vector3(x * chunkSize + Random.Range(-4, 4), 0, y * chunkSize + Random.Range(-4, 4));
    //         Instantiate(flaskPrefab, pos, Quaternion.identity);
    //     }
    // }
}
