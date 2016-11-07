using Assets.Scripts.Scripted_Events.Room2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events
{
    class RoomButtonLock : MonoBehaviour
    {
        public GameObject[] WGWalls;
        public GameObject[] NormalWalls;
        private GameObject player;
        private SpriteRenderer buttonRenderer;

        public GameObject Door;
        public SpriteRenderer Wall;

        private ButtonRange buttonRange;

        void Start()
        {
            buttonRenderer = GetComponent<SpriteRenderer>();
            player = GameObject.FindGameObjectWithTag("Player");
            buttonRange = GetComponentInChildren<ButtonRange>();
        }

        void Update()
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (buttonRange.PlayerInRange && buttonRenderer.enabled)
                {
                    Toggle();
                }
            }
        }

        private void Toggle()
        {
            foreach (GameObject normalWall in NormalWalls)
            {
                normalWall.SetActive(!normalWall.activeSelf);
            }

            foreach (GameObject wall in WGWalls)
            {
                toggleObject(wall);
            }
            if (Door != null)
            {
                toggleObject(Door);
                toggleLayer(Door);
            }
            buttonRenderer.flipY = !buttonRenderer.flipY;

        }
        

        private void toggleObject(GameObject gameObject)
        {
            //var LOSTriggerEnabled = gameObject.GetComponent<LOS.Event.LOSEventTrigger>().enabled;

            //gameObject.GetComponent<LOS.Event.LOSEventTrigger>().enabled = !LOSTriggerEnabled;
            gameObject.GetComponent<Collider2D>().enabled = !gameObject.GetComponent<Collider2D>().enabled;
            gameObject.GetComponent<LOS.LOSObstacle>().enabled = !gameObject.GetComponent<LOS.LOSObstacle>().enabled;
        }

        private void toggleLayer(GameObject gameObject)
        {
            if (Door.layer == LayerMask.NameToLayer("Glass"))
                Door.layer = LayerMask.NameToLayer("Obstacles");
            else
                Door.layer = LayerMask.NameToLayer("Glass");

        }

        public bool isFlipped()
        {
            return buttonRenderer.flipY;
        }

        public bool isVisible()
        {
            return buttonRenderer.enabled;
        }
    }
}
