using nvp.events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        EventManager.Events("select").GameEventHandler += onSelect;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

    public void onSelect(object sender, System.EventArgs args)
    {
        if(((GameObject)sender).GetComponent<Building>() == this)
        {
            select();
        }
        else
        {
            deselect();
        }
    }

    public void select()
    {
        if (GetComponentInParent<Ground>().selected)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void deselect()
    {
        if (!GetComponentInParent<Ground>().selected)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
