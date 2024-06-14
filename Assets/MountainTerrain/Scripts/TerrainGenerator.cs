using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MountainTerrain.Scripts
{

    public class TerrainGenerator : MonoBehaviour
    {
        public Terrain terrain;
        public Texture2D grassTexture;
        public Texture2D rockTexture;
        public Texture2D dirtTexture;
        public GameObject treePrefab;
        public GameObject grassMeshPrefab;

        void Start()
        {
            // Рельеф
            TerrainData terrainData = terrain.terrainData;
            float[,] heights = new float[terrainData.heightmapResolution, terrainData.heightmapResolution];
            for (int x = 0; x < terrainData.heightmapResolution; x++)
            {
                for (int y = 0; y < terrainData.heightmapResolution; y++)
                {
                    heights[x, y] = Mathf.PerlinNoise(x * 0.01f, y * 0.01f);
                }
            }
            terrainData.SetHeights(0, 0, heights);

            // Текстуры
            AddTexture(grassTexture, 0);
            AddTexture(rockTexture, 1);
            AddTexture(dirtTexture, 2);

            // Деревья
            for (int i = 0; i < 100; i++)
            {
                float x = Random.Range(0, terrainData.size.x);
                float z = Random.Range(0, terrainData.size.z);
                float y = terrain.SampleHeight(new Vector3(x, 0, z));
                Instantiate(treePrefab, new Vector3(x, y, z), Quaternion.identity);
            }

            // Трава
            DetailPrototype detail = new DetailPrototype();
            detail.prototype = grassMeshPrefab;
            detail.renderMode = DetailRenderMode.VertexLit;
            detail.prototypeTexture = grassTexture;
            detail.usePrototypeMesh = true;
            terrainData.detailPrototypes = new DetailPrototype[] { detail };
            int[,] details = new int[terrainData.detailWidth, terrainData.detailHeight];
            for (int x = 0; x < terrainData.detailWidth; x++)
            {
                for (int y = 0; y < terrainData.detailHeight; y++)
                {
                    details[x, y] = 1;
                }
            }
            terrainData.SetDetailLayer(0, 0, 0, details);
        }

        void AddTexture(Texture2D texture, int index)
        {
            TerrainLayer layer = new TerrainLayer();
            layer.diffuseTexture = texture;
            TerrainLayer[] layers = terrain.terrainData.terrainLayers;
            Array.Resize(ref layers, layers.Length + 1);
            layers[layers.Length - 1] = layer;
            terrain.terrainData.terrainLayers = layers;
        }
    }

}