using LOS.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class EnemySomething : MonoBehaviour
    {
        void Start()
        {
            LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
            if (trigger.enabled)
            {
                trigger.OnNotTriggered += OnNotLit;
                trigger.OnTriggered += OnLit;

                OnNotLit();
            }
        }

        private void OnNotLit()
        {
        }

        private void OnLit()
        {
        }

        void Update() 
        {

        }


        private void Shoot()
        {

        }
    }
}
