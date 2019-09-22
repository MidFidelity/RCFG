using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class ClickInterpreter : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera camera;
    private readonly System.EventArgs eventArgsEmpty= new System.EventArgs();

    void Start()
    {
        camera = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    EventManager.Events("select").TriggerEvent(hit.collider.gameObject,eventArgsEmpty);
                    /*ISelectable selectable = hit.collider.GetComponent<ISelectable>();
                    if (selectable != null)
                    {
                        
                        selectable.onSelect(hit.collider, eventArgsEmpty);
                    }*/
                }
            }
        }
    }

    public void createPerson()
    {
        EventManager.Events("createPerson").TriggerEvent(this, eventArgsEmpty);
    }
}
