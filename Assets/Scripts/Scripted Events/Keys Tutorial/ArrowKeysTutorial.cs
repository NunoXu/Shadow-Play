using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Keys_Tutorial
{
    class ArrowKeysTutorial : MonoBehaviour
    {
        private FadeObjectInOut _fader;


        void Start()
        {
            this.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
            
            _fader = GetComponent<FadeObjectInOut>();
        }

        void Update()
        {
            if (Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f)
            {
                _fader.FadeOut(() => { });
                this.enabled = false;
            }
        }
    }
}
