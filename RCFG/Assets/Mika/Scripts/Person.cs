using nvp.events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class Person : MonoBehaviour
    {
        public bool selected = false;
        public Material selectedMaterial;
        public Material unselectedMaterial;
        public Vector2Int pos;
        public GameObject world;
    public GameObject movementMarker;


        // Start is called before the first frame update
        void Start()
        {
            EventManager.Events("select").GameEventHandler += onSelect;
        world = transform.parent.parent.gameObject;
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
                            Vector2Int diff = new Vector2Int(pos.x - x, pos.y + y);
                            if (selected)
                            {
                                transform.SetParent(tiles[x, y].transform);
                                transform.localPosition = new Vector3(0, 1, 0);
                            pos = new Vector2Int(x, y);
                            }
                        }
                    }
                }
                deselect(sender);
            EventManager.Events("removeMarkers").TriggerEvent(this, EventArgs.Empty);
            }


        }

        void select()
        {
            if (!selected)
            {
            GameObject[,] tiles = world.GetComponent<Grid>().tiles;
            this.transform.localPosition += new Vector3(0, 0.5f, 0);
                selected = true;
                this.GetComponent<Renderer>().material = selectedMaterial;
            for (int x = pos.x-2;x <= pos.x+2; x++)
            {
                for (int y = pos.y - 2; y <= pos.y + 2; y++)
                {
                    if (x >= 0 && x <= 40 && y >= 0 && y <= 40)
                        tiles[x, y].GetComponent<Ground>().movementMarker = Instantiate(movementMarker, tiles[x, y].transform);
                }
            }
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

        public void create(Vector2Int pos,GameObject caller)
        {
        GameObject temp = Instantiate(this.gameObject, caller.transform);
        temp.GetComponent<Person>().pos = pos;
        
        }
    }

