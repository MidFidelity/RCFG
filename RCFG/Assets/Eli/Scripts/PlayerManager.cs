using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    using UnityEngine;

    public class ItemManager
    {
        public static Dictionary<string, int> items;
        public ItemManager()
        {
            items = new Dictionary<string, int>();
            items.Add("Brot", 0);
            items.Add("Holz", 0);
            items.Add("Stein", 0);
            items.Add("Eisen", 0);
            items.Add("Gold", 0);
        }


    }

    public class Player
    {
        public static ItemManager items;
        public Player()
        {
            items = new ItemManager();
        }
    }
    public class PlayerManager : MonoBehaviour
    {
        private Player[] players;
        private int currPlayerIndex;
        public Player CurrPlayer { get => players[currPlayerIndex]; set => players[currPlayerIndex] = value; }
        private int otherPlayerIndex { get => 1 - currPlayerIndex; set => currPlayerIndex = 1 - value; }
        public Player OtherPlayer { get => players[otherPlayerIndex]; set => players[otherPlayerIndex] = value; }
        void Start()
        {
            players = new Player[2];
            currPlayerIndex = 0;
            CurrPlayer = new Player();
            OtherPlayer = new Player();
        }


        public void swap()
        {
            currPlayerIndex = 1 - currPlayerIndex;
            Camera.main.GetComponent<CameraMovement>().swapTurns(currPlayerIndex + 1);

        }
    }

}