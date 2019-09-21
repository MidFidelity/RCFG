using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Grid : MonoBehaviour
{
    public GameObject groundPrefab;

    public int gridWidth, gridHeight;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(groundPrefab, "GroundPrefab not set");

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Instantiate(groundPrefab, new Vector3(x, 0, y), Quaternion.identity, this.transform);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
