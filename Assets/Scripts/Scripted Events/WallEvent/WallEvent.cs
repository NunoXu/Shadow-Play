using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events
{
    class WallEvent : MonoBehaviour
    {
        public GameObject RevealingWall;
        public float timeToPosition = 2f;

        private bool _triggered;
        public float finalPos = 16.4f;

        private float startPosition;
        private float velocity;

        void Start()
        {
            startPosition = RevealingWall.transform.position.y;
            velocity = Mathf.Abs((finalPos - startPosition) / timeToPosition);
        }

        void Update()
        {
            if (_triggered && RevealingWall.transform.position.y != finalPos)
            {
                Vector3 pos = RevealingWall.transform.position;
                pos.y += velocity * Time.deltaTime;
                pos.y = Mathf.Min(finalPos, pos.y);
                RevealingWall.transform.position = pos;
            }
        }

        public void TriggerTrap()
        {
            _triggered = true;
            RevealingWall.SetActive(true);
        }

        public void F()
        {

        }
    }
}
