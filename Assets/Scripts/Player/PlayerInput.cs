using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerInput: MonoBehaviour
    {
        public Player player;

        void Update()
        {
            
            if (Input.GetButtonDown("Pickup"))
            {
                if (player.LanternPickedup != null)
                    player.DropLantern();
                else
                    player.PickUpLantern();
            }
        }
    }
}
