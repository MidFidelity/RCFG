using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public partial class Ground : MonoBehaviour
{


    public GameObject content;
    [SerializeField] private bool selected = false;

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
        if (((GameObject)sender).GetComponent<Ground>() != this)
        {
            deselect();
        }
        else
        {
            select();
        }


    }

    void select()
    {
        if (!selected)
        {
            this.transform.localPosition += new Vector3(0, 0.5f, 0);
            selected = true;
        }
    }

    public void deselect()
    {
        if (selected)
        {
            this.transform.localPosition -= new Vector3(0, 0.5f, 0);
            selected = false;
        }
    }

}
