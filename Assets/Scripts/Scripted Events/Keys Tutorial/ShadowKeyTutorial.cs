using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Keys_Tutorial
{
    class ShadowKeyTutorial : MonoBehaviour
    {

        private GameObject KeyImage;

        void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            KeyImage = GetComponentInChildren<SpriteRenderer>().gameObject;
            KeyImage.transform.parent = player.transform;
            KeyImage.GetComponent<FadeObjectInOut>().FadeOut(() => {});
        }
        

        public void Show()
        {
            KeyImage.GetComponent<FadeObjectInOut>().FadeIn(() => { });
        }

        public void Hide()
        {
            KeyImage.GetComponent<FadeObjectInOut>().FadeOut(() => { gameObject.SetActive(false); });
        }
    }
}
