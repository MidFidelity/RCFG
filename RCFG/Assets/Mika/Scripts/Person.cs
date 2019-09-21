﻿using nvp.events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public bool selected=false;
    public Material selectedMaterial;
    public Material unselectedMaterial;
    public Vector2 pos;
    public GameObject world;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.Events("select").GameEventHandler += onSelect;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onSelect(object sender, System.EventArgs args)
    {
        if (((GameObject)sender).GetComponent<Person>() == this)
        {
            select();
        }
        else
        {
            GameObject[,] tiles = world.GetComponent<Grid>().tiles;
            for (int x = 0; x < tiles.GetLength(0); x++)
            {
                for (int y = 0; y < tiles.GetLength(1); y++)
                {
                    if (tiles[x, y].GetInstanceID() == ((GameObject)sender).GetInstanceID())
                    {
                        Vector2 diff = new Vector2(pos.x - x, pos.y + y);
                        if (true)
                        {
                            transform.SetParent(tiles[x, y].transform);
                            transform.localPosition = new Vector3(0, 1, 0);
                        }
                    }
                }
            }
            deselect(sender);
        }


    }

    void select()
    {
        if (!selected)
        {
            this.transform.localPosition += new Vector3(0, 0.5f, 0);
            selected = true;
            this.GetComponent<Renderer>().material = selectedMaterial;
        }
    }

    public void deselect(object sender)
    {
        if (selected)
        {
            
            this.transform.localPosition -= new Vector3(0, 0.5f, 0);
            selected = false;
            this.GetComponent<Renderer>().material = unselectedMaterial;
        }


    }
}
