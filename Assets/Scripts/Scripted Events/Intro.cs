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
            if (!fadedin && !startedFadingIn)
            {
                dialogBox.GetComponent<FadeTextInOut>().FadeIn(FinishedFadingIn);
                startedFadingIn = true;
            }

            if (lantern.PickedUp && fadedin && !startedFadingOut)
            {
                dialogBox.GetComponent<FadeTextInOut>().FadeOut(FinishedFadingOut);
                startedFadingOut = true;
            }
        }

        public void FinishedFadingIn()
        {
            fadedin = true;
        }

        public void FinishedFadingOut()
        {
            this.gameObject.SetActive(false);
        }
    }
}
