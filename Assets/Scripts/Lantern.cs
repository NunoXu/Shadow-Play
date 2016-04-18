using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Lantern : MonoBehaviour
    {

        [HideInInspector]
        public bool PickedUp = false;

        public bool RadiateWhenPicked = true;
        

        private Rigidbody2D rigidBody;
        private Vector3 relativePositionToPlayer;
        private Player.Player player;
        private Transform parent;

        private LOS.LOSRadialLight lanternLight;
        private LOS.Event.LOSEventSource lanternEventSource;

        private bool firstPick = true;

        void Start()
        {
            parent = transform.parent;
            rigidBody = this.GetComponent<Rigidbody2D>();

            lanternLight = GetComponentInChildren<LOS.LOSRadialLight>();
            lanternEventSource = GetComponentInChildren<LOS.Event.LOSEventSource>();
        }

        void FixedUpdate()
        {
            if (PickedUp)
            {
                if (firstPick)
                {
                    Radiate(5f, 1f);
                    firstPick = false;
                }
                Vector3 newPos = Vector3.Lerp(transform.position, player.transform.position + relativePositionToPlayer,  player.MoveSpeed / Time.deltaTime);
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            }
        }

        public void GetPickedUp (Player.Player player)
        {
            this.player = player;
            relativePositionToPlayer = transform.position - player.transform.position;
            relativePositionToPlayer = relativePositionToPlayer.normalized * 1.2f;
            PickedUp = true;
            rigidBody.isKinematic = false;
        }

        public void GetDropped()
        {
            this.player = null;
            PickedUp = false;
            rigidBody.isKinematic = true;
        }

        private IEnumerator RadiateSequence(float finalRadiance, float time)
        {

            float radialSpeed = 1.0f / time;

            while (lanternLight.radius < finalRadiance)
            {
                var radialValue = lanternLight.radius;
                var newRadial = radialValue;
                newRadial += Time.deltaTime * radialSpeed;
                lanternLight.radius = newRadial;
                lanternEventSource.distance = newRadial;

                yield return null;
            }
            
        }


        public void Radiate(float finalRadiance, float time)
        {
            StopAllCoroutines();
            StartCoroutine(RadiateSequence(finalRadiance, time));
        }


    }
}
