using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scripted_Events
{
    class Intro : MonoBehaviour
    {
        public Text dialogBox;
        public Lantern lantern;

        private float startTime;
        private bool fadedin = false;
        private bool startedFadingIn = false;

        private bool fadedout = false;
        private bool startedFadingOut = false;

        private float fadeTime = 1.5f;

        private LOS.LOSRadialLight lanternLight;
        private LOS.Event.LOSEventSource lanternES;

        void Start()
        {
        }

        void Update()
        {
            if (!fadedin)
            {
                if (!startedFadingIn)
                {
                    startTime = Time.time;
                    startedFadingIn = true;
                }
                var alphaValue = (Time.time - startTime) / 1.5f;
                
                Color newColor = dialogBox.color;

                newColor.a = Mathf.Clamp(alphaValue, 0.0f, 1.0f);
                dialogBox.color = newColor;

                if (alphaValue >= 0.98f)
                    fadedin = true;
            }

            if (lantern.PickedUp && fadedin)
            {
                if (!startedFadingOut)
                {
                    startTime = Time.time;
                    startedFadingOut = true;
                }

                var timeDifference = (Time.time - startTime);
                var alphaValue = 1 - timeDifference / 1.5f;

                Color newColor = dialogBox.color;
                newColor.a = Mathf.Clamp(alphaValue, 0.0f, 1.0f);
                dialogBox.color = newColor;



                if (alphaValue <= 0.02f)
                    this.gameObject.SetActive(false);
            }
        }

    }
}
