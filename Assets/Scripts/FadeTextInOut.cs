using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class FadeTextInOut : MonoBehaviour
    {
        // publically editable speed
        public float fadeDelay = 0.0f;
        public float fadeTime = 0.7f;
        public bool fadeInOnStart = false;
        public bool fadeOutOnStart = false;
        private bool logInitialFadeSequence = false;

        private Text text;

        

        // store colours
        private Color[] colors;

        void Start()
        {
            text = GetComponent<Text>();
        }


        // check the alpha value of most opaque object
        float MaxAlpha()
        {
            float maxAlpha = 0.0f;
            Text[] rendererObjects = GetComponents<Text>();
            foreach (Text item in rendererObjects)
            {
                maxAlpha = Mathf.Max(maxAlpha, item.color.a);
            }
            return maxAlpha;
        }

        // fade sequence
        private IEnumerator FadeSequence(float finalAlpha, float time, CallbackFunction function)
        {

            var increasing = text.color.a < finalAlpha;
            float fadeSpeed = 1.0f / time;
            if (!increasing)
                fadeSpeed = -fadeSpeed;

            while ((increasing && text.color.a < finalAlpha) || (!increasing && text.color.a > finalAlpha))
            {
                var alphaValue = text.color.a;
                var newColor = text.color;
                newColor.a += Time.deltaTime * fadeSpeed;
                text.color = newColor;

                yield return null;
            }

            function();

        }

        public delegate void CallbackFunction();

        public void FadeIn(CallbackFunction function)
        {
            FadeIn(fadeTime, function);
        }

        public void FadeOut(CallbackFunction function)
        {
            FadeOut(fadeTime, function);
        }

        public void FadeIn(float newFadeTime, CallbackFunction function)
        {
            StopAllCoroutines();
            StartCoroutine(FadeSequence(1.0f, newFadeTime, function));
        }

        public void FadeOut(float newFadeTime, CallbackFunction function)
        {
            StopAllCoroutines();
            StartCoroutine(FadeSequence(0.0f, newFadeTime, function));
        }

    }
}

