using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Keys_Tutorial
{
    class InteractKeyTutorial : MonoBehaviour
    {

        private FadeObjectInOut _fader;
        public RoomButtonLock button;

        void Start()
        {
            _fader = GetComponent<FadeObjectInOut>();
            _fader.FadeOut(() => { });
        }

        void Update()
        {
            if (button.isFlipped())
            {
                _fader.FadeOut(() => {
                    this.gameObject.SetActive(false);
                });
            }
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player" && button.isVisible())
            {
                _fader.FadeIn(() => { });
            }
        }

        void OnTriggerStay2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player" && button.isVisible())
            {
                _fader.FadeIn(() => { });
            }
        }

        void OnTriggerExit2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player" || !button.isVisible())
            {
                _fader.FadeOut(() => { });
            }
        }
    }
}
