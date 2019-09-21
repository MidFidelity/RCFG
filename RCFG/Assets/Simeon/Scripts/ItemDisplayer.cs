using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class ItemDisplayer : MonoBehaviour
{
    public GameObject welt;
    public Material mat_1;
    
    // Update is called once per frame
    void Update()
    {
        // init list
    	this.GetComponent<Text>().text = "<size=25>Rohstoffe:</size> \n";
        // +nahrung
        this.GetComponent<Text>().text += "\n      Brot: ";
        this.GetComponent<Text>().text += welt.GetComponent<PlayerManager>().CurrPlayer.items.items["Brot"].ToString();
        // +holz
        this.GetComponent<Text>().text += "\n      Holz: ";
        this.GetComponent<Text>().text += welt.GetComponent<PlayerManager>().CurrPlayer.items.items["Holz"].ToString();
        // +stein
        this.GetComponent<Text>().text += "\n      Stein: ";
        this.GetComponent<Text>().text += welt.GetComponent<PlayerManager>().CurrPlayer.items.items["Stein"].ToString();
        // +eisen
        this.GetComponent<Text>().text += "\n      Eisen: ";
        this.GetComponent<Text>().text += welt.GetComponent<PlayerManager>().CurrPlayer.items.items["Eisen"].ToString();
        // +gold
        this.GetComponent<Text>().text += "\n      Gold: ";
        this.GetComponent<Text>().text += welt.GetComponent<PlayerManager>().CurrPlayer.items.items["Gold"].ToString();        

    }

}
 