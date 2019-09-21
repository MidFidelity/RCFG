using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Grid : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject[] ores;

    public int gridWidth, gridHeight;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(groundPrefab, "GroundPrefab not set");

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject temp = Instantiate(groundPrefab, new Vector3(x, Random.value*0.1f, y), Quaternion.identity, this.transform);
                if (Random.value < 0.2f)
                {
                    GameObject temp2 = Instantiate(ores[Random.Range(0, 4)], temp.transform);
                    temp.GetComponent<Ground>().ore = temp2;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
