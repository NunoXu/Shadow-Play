using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Room2
{
    class ButtonRange : MonoBehaviour
    {
        public bool PlayerInRange = false;

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                PlayerInRange = true;
            }
        }

        void OnTriggerExit2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                PlayerInRange = false;
            }
        }
    }
}
