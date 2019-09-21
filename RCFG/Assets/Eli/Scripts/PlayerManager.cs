using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    using UnityEngine;

    public class ItemManager
    {
        public Dictionary<string, int> items;
        public ItemManager()
        {
            items = new Dictionary<string, int>();
            items.Add("Brot", 5);
            items.Add("Holz", 5);
            items.Add("Stein", 5);
            items.Add("Eisen", 5);
            items.Add("Gold", 5);
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

        void Update()
        {

            if (CurrPlayer.items.items["Gold"] < -5 || CurrPlayer.items.items["Eisen"] < -5)
            {
                SceneManager.LoadScene("loose");

            }
            if (OtherPlayer.items.items["Gold"] < -5 || OtherPlayer.items.items["Eisen"] < -5)
            {
                SceneManager.LoadScene("win");

            }

        }

        public void swap()
        {
            currPlayerIndex = 1 - currPlayerIndex;
            CurrPlayer.startTurn();
            Camera.main.GetComponent<CameraMovement>().swapTurns(currPlayerIndex + 1);

        }
    }

}