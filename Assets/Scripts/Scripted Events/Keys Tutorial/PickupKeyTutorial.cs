using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Keys_Tutorial
{
    class PickupKeyTutorial : MonoBehaviour
    {
        public string button;

        private FadeObjectInOut _fader;
        public Lantern lantern;

        void Start()
        {
            _fader = GetComponent<FadeObjectInOut>();
        }

        void Update()
        {
            if (lantern.PickedUp)
            {
                _fader.FadeOut(() => {
                    this.gameObject.SetActive(false);
                });
            }
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                _fader.FadeIn(() => { });
            }
        }

        void OnTriggerExit2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                _fader.FadeOut(() => { });
            }
        }
    }
}
