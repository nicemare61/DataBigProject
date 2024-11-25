using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Searching
{

    public class OOPExit : Identity
    {
        /*public string unlockKey;*/
        public TMP_Text pointTxt;
        public GameObject YouWin;
        public GameObject YouLose;

        private OOPPlayer player;
        private int point = 0;
        public int Point
        {
            get { return point;}
            set
            {
                point = value; 
                UpdatePointHUD();
            }
        }

        private void Awake()
        {
            UpdatePointHUD();
        }

        public void UpdatePointHUD()
        {
            pointTxt.text = $"Point : {point}";
        }

        


        /*public override void Hit()
        {
            if (mapGenerator.player.inventory.numberOfItem(unlockKey) > 0)
            {
                Debug.Log("Exit unlocked");
                mapGenerator.player.enabled = false;
                YouWin.SetActive(true);
                Debug.Log("You win");
            }
            else
            {
                Debug.Log($"Exit locked, require key: {unlockKey}");
            }
        }*/
    }
}