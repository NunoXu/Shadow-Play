using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class GameManager : MonoBehaviour
    {
        
        public Player.Player player;
        
        private IList<Lantern> lanterns = new List<Lantern>();

        void Start()
        {
            var goLanterns = GameObject.FindGameObjectsWithTag("Lantern");
            foreach (GameObject go in goLanterns)
            {
                lanterns.Add(go.GetComponent<Lantern>());
            }

        }
        
        void FixedUpdate()
        {
            
            

            /*foreach(Lantern lantern in lanterns) {
                if (lantern.PickedUp)
                {
                    Vector3 lpos = lantern.transform.position;
                    lpos.x += Input.GetAxis("Horizontal") * player.MoveSpeed * Time.deltaTime;
                    lpos.y += Input.GetAxis("Vertical") * player.MoveSpeed * Time.deltaTime;

                    float oldSqrDistance = Vector3.SqrMagnitude(oldPlayerPos - lantern.transform.position);
                    float newSqrDistance = Vector3.SqrMagnitude(pos - lpos);
                    if (Vector3.Distance(lpos, pos) < 1.2f)
                    {

                        lantern.GetComponent<Rigidbody2D>().MovePosition(lpos);
                    }
                }
            }*/
        }


        public Lantern PickupLantern(Player.Player player, Lantern lantern)
        {
            Lantern result = null;

            if (Vector3.Distance(player.transform.position, lantern.transform.position) < 1.5f)
            {
                lantern.GetPickedUp(player);
                result = lantern;
            }
            return result;
        }

        public void DropLantern(Lantern lantern)
        {
            lantern.GetDropped();
        }
    }
}
