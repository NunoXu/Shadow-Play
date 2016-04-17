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
