using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Grid : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject[] ores;
    public GameObject[,] tiles;

    public int gridWidth, gridHeight;
    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[gridWidth, gridHeight];
        Assert.IsNotNull(groundPrefab, "GroundPrefab not set");

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                tiles[x, y] = Instantiate(groundPrefab, new Vector3(x, Random.value*0.1f, y), Quaternion.identity, this.transform);

                
            }
        }
        foreach (GameObject tile in tiles)
        {
            if (Random.value < 0.1f)
            {
                GameObject temp = Instantiate(ores[Random.Range(0, 4)], tile.transform);
                tile.GetComponent<Ground>().ore = temp;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
