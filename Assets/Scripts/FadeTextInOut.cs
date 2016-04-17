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

        

        // store colours
        private Color[] colors;




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
        IEnumerator FadeSequence(float fadingOutTime)
        {
            // log fading direction, then precalculate fading speed as a multiplier
            bool fadingOut = (fadingOutTime < 0.0f);
            float fadingOutSpeed = 1.0f / fadingOutTime;

            // grab all child objects
            Text[] rendererObjects = GetComponents<Text>();
            if (colors == null)
            {
                //create a cache of colors if necessary
                colors = new Color[rendererObjects.Length];

                // store the original colours for all child objects
                for (int i = 0; i < rendererObjects.Length; i++)
                {
                    colors[i] = rendererObjects[i].color;
                }
            }

            // make all objects visible
            for (int i = 0; i < rendererObjects.Length; i++)
            {
                rendererObjects[i].enabled = true;
            }


            // get current max alpha
            float alphaValue = MaxAlpha();


            // This is a special case for objects that are set to fade in on start. 
            // it will treat them as alpha 0, despite them not being so. 
            if (logInitialFadeSequence && !fadingOut)
            {
                alphaValue = 0.0f;
                logInitialFadeSequence = false;
            }

            // iterate to change alpha value 
            while ((alphaValue >= 0.0f && fadingOut) || (alphaValue <= 1.0f && !fadingOut))
            {
                alphaValue += Time.deltaTime * fadingOutSpeed;

                for (int i = 0; i < rendererObjects.Length; i++)
                {
                    Color newColor = (colors != null ? colors[i] : rendererObjects[i].color);
                    newColor.a = Mathf.Min(newColor.a, alphaValue);
                    newColor.a = Mathf.Clamp(newColor.a, 0.0f, 1.0f);
                    rendererObjects[i].color =newColor;
                }

                yield return null;
            }

            // turn objects off after fading out
            if (fadingOut)
            {
                for (int i = 0; i < rendererObjects.Length; i++)
                {
                    rendererObjects[i].enabled = false;
                }
            }


            Debug.Log("fade sequence end : " + fadingOut);

        }


        public void FadeIn()
        {
            FadeIn(fadeTime);
        }

        public void FadeOut()
        {
            FadeOut(fadeTime);
        }

        public void FadeIn(float newFadeTime)
        {
            StopAllCoroutines();
            StartCoroutine("FadeSequence", newFadeTime);
        }

        public void FadeOut(float newFadeTime)
        {
            StopAllCoroutines();
            StartCoroutine("FadeSequence", -newFadeTime);
        }

    }
}

