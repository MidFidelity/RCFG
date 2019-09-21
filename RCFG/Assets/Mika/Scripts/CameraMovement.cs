using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject world;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swapTurns(int player)
    {
        if (player == 1)
        {
            GetComponent<Animator>().Play("CameraToP1");
        }
        if (player == 2)
        {
            GetComponent<Animator>().Play("CameraToP2");
        }
    }
}
