using UnityEngine;

public class MapChunk
{
    public int Size;
    public float ObstacleProp;
    public float CryptProp;
    public GameObject[,] Tiles;

    public MapChunk(int size, float obstacleProp, float cryptProp)
    {
        Size = size;
        ObstacleProp = obstacleProp;
        CryptProp = cryptProp;
        Tiles = new GameObject[size, size];
    }

    public void Generate(GameObject[] terrainPrefabs, GameObject[] obstaclePrefabs, GameObject CryptPrefab, int X, int Y, int WorldSize)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                float prop = Random.Range(.0f, 1.0f);
                TileType type = prop <= ObstacleProp ? (prop <= ObstacleProp*CryptProp ? TileType.Crypt : TileType.Obstacle) : TileType.Ground;
                Vector3 pos = new Vector3(
                    Mathf.RoundToInt((X - WorldSize / 2) * Size + i),
                    Mathf.RoundToInt((Y - WorldSize / 2) * Size + j),
                    10
                );
                Vector3 cryptPos = new Vector3(
                    Mathf.RoundToInt((X - WorldSize / 2) * Size + i),
                    Mathf.RoundToInt((Y - WorldSize / 2) * Size + j),
                    0.5f
                );
                switch(type)
                {
                    case TileType.Crypt:
                        Tiles[i, j] = UnityEngine.Object.Instantiate(CryptPrefab, cryptPos, Quaternion.identity);
                        Tiles[i, j] = UnityEngine.Object.Instantiate(terrainPrefabs[Random.Range(0, terrainPrefabs.Length)], pos, Quaternion.identity);
                        break;
                    case TileType.Ground:
                        Tiles[i, j] = UnityEngine.Object.Instantiate(terrainPrefabs[Random.Range(0, terrainPrefabs.Length)], pos, Quaternion.identity);
                        break;
                    case TileType.Obstacle:
                        Tiles[i, j] = UnityEngine.Object.Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)], pos, Quaternion.identity);
                        break;
                }
                
            }
        }
    }
}
