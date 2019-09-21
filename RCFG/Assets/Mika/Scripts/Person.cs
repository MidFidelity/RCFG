using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using nvp.events;

public class Person : MonoBehaviour
{

    public bool canMove = false;
    public Player.Player owner;
    public int atk;
    public int def;
    public int movingRadius;
    public Grid grid;
    public Ground ground;
    public GameObject moveMarker;
    private Vector2Int position;
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
        if (((GameObject)sender).GetComponent<Person>() == this || ((GameObject)sender).GetComponent<Ground>() == this.transform.parent.GetComponent<Ground>())
        {
            if (ground.selected)
            {
                deselect();
            }
            else
            {
                select();
            }
        }
    }

    void select()
    {
        if (!ground.selected)
        {
           for(int x = position.x-movingRadius;x< 2 * movingRadius; x++)
            {
                for (int y = position.y - movingRadius; y < 2 * movingRadius; y++)
                {
                    if (x >= 0 && y >= 0)
                    {
                        grid.tiles[x][y].GetComponent<Ground>().
                    }
                }
            }
        }
    }

    public void deselect()
    {
        if (ground.selected)
        {
            
        }
    }
}
