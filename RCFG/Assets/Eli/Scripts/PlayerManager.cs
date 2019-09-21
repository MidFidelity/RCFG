using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    using UnityEngine;

    public class ItemManager
    {
        public Dictionary<string, int> items;
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
        public ItemManager items;
        public int goldMines = 0;
        public int ironMines = 0;
        public Player()
        {
            items = new ItemManager();

        }
        public void startTurn()
        {
            items.items["Gold"] += goldMines;
            items.items["Eisen"] += ironMines;
        }
    }
    public class PlayerManager : MonoBehaviour
    {
        private Player[] players;
        public int currPlayerIndex;
        public Player CurrPlayer { get => players[currPlayerIndex]; set => players[currPlayerIndex] = value; }
        public int otherPlayerIndex { get => 1 - currPlayerIndex; set => currPlayerIndex = 1 - value; }
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
            CurrPlayer.startTurn();
            Camera.main.GetComponent<CameraMovement>().swapTurns(currPlayerIndex + 1);

        }
    }

}