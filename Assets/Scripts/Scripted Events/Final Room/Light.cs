using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Final_Room
{
    class Light : MonoBehaviour
    {
        public Lantern[] lanterns;

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                foreach (Lantern lant in lanterns)
                {
                    lant.Radiate(4f, 1.0f);
                }
            }
        }
    }
}
