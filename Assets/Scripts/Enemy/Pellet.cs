using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    class Pellet : MonoBehaviour
    {

        public float PelletVelocity = 2f;

        void Update()
        {
            transform.position += transform.forward * PelletVelocity * Time.deltaTime;
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {

            }
        }

        void OnTriggerExit2D(Collider2D e)
        {
        }
    }
}
