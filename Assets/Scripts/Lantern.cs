using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Lantern : MonoBehaviour
    {
        
        private bool PickedUp = false;
        

        private Rigidbody2D rigidBody;
        private Vector3 relativePositionToPlayer;
        private Player.Player player;
        private Transform parent;

        void Start()
        {
            parent = transform.parent;
            rigidBody = this.GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            if (PickedUp)
            {
                GetComponent<Rigidbody2D>().MovePosition(player.transform.position + relativePositionToPlayer);
            }
        }

        public void GetPickedUp (Player.Player player)
        {
            this.player = player;
            relativePositionToPlayer = transform.position - player.transform.position;
            PickedUp = true;
            rigidBody.isKinematic = false;
        }

        public void GetDropped()
        {
            this.player = null;
            PickedUp = false;
            rigidBody.isKinematic = true;
        }


    }
}
