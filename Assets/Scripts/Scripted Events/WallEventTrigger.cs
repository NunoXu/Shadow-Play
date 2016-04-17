using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events
{
    class WallEventTrigger : MonoBehaviour
    {
        public WallEvent smallRoom;

        private bool playerEntered = false;
        private bool lanternEntered = false;

        void OnTriggerEnter2D (Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                playerEntered = true;
            }

            if (e.gameObject.tag == "Lantern")
            {
                lanternEntered = true;
            }

            if (playerEntered && lanternEntered)
            {
                smallRoom.TriggerTrap();
                this.gameObject.SetActive(false);
            }
        }

        void OnTriggerExit2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                playerEntered = false;
            }

            if (e.gameObject.tag == "Lantern")
            {
                lanternEntered = false;
            }
        }
    }
}
