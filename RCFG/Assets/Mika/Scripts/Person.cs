using nvp.events;
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
            if (((GameObject)sender))
            {

            }
            deselect();
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

    public void deselect()
    {
        if (selected)
        {
            this.transform.localPosition -= new Vector3(0, 0.5f, 0);
            selected = false;
            this.GetComponent<Renderer>().material = unselectedMaterial;
        }


    }
}
