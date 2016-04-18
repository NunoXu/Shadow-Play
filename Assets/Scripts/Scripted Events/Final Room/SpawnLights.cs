using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Final_Room
{
    class SpawnLights : MonoBehaviour
    {

        public Lantern[] lanterns;


        void OnTriggerEnter2D(Collider2D e)
        {
            foreach(Lantern lant in lanterns)
            {
                lant.gameObject.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }
}
