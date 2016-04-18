using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Keys_Tutorial
{
    class ShadowEnterTrigger : MonoBehaviour
    {
        private ShadowKeyTutorial shadowKeyTutorial;

        void Start()
        {
            shadowKeyTutorial = GetComponentInParent<ShadowKeyTutorial>();
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                shadowKeyTutorial.Show();
                this.gameObject.SetActive(false);
            }
        }
    }
}
