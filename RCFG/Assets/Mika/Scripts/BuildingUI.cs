using nvp.events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject functionContainer;
    
    void Start()
    {
        EventManager.Events("select").GameEventHandler += onClick;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Camera.main.transform.rotation;


    }

    public void onClick(object sender, System.EventArgs args)
    {
        if(((GameObject)sender).GetComponent<BuildingUI>() == this)
        {
            switch (transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text)
            {
                case "Build":
                    functionContainer.GetComponent<Ground>().build();
                    break;
                case "Destroy":
                    functionContainer.GetComponent<Building>().destroy();
                    break;
                
            }
        }
    }
}
