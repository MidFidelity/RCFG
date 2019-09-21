using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public partial class Ground : MonoBehaviour
{

    public Material selectedMaterial;
    public Material unselectedMaterial;
    public GameObject content;
    [SerializeField] public bool selected = false;

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
        if (((GameObject)sender).GetComponent<Ground>() == this|| ((GameObject)sender)==content)
        {
            select();
        }
        else
        {
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
