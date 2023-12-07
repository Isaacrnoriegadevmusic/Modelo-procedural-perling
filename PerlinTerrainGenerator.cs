using UnityEngine;

public class PerlinTerrainGenerator : MonoBehaviour
{
    public int size = 256;          // Tamaño del terreno (ancho y largo)
    public float scale = 20f;       // Escala del ruido de Perlin
    public int octaves = 4;         // Número de octavas para la generación de ruido

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GeneratePerlinTerrain(terrain.terrainData);
    }

    TerrainData GeneratePerlinTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = size + 1;
        terrainData.size = new Vector3(size, 10, size);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[size, size];

        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float xCoord = (float)x / size * scale;
                float yCoord = (float)y / size * scale;
                heights[y, x] = Mathf.PerlinNoise(xCoord, yCoord);
            }
        }

        return heights;
    }
}

