using LOS.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Disappear : MonoBehaviour
    {
        public bool removeCollider = true;

        private FadeObjectInOut _fader;
        private Collider2D _collider;
        private Rigidbody2D _rigidbody;

        private bool disappear = false;
        

        private const float SECONDS_TO_DISAPEAR = 1.0f;
        

        void Start()
        {
            _fader = GetComponent<FadeObjectInOut>();
            _collider = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();

            LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
            if (trigger.enabled)
            {
                trigger.OnNotTriggered += OnNotLit;
                trigger.OnTriggered += OnLit;

                OnNotLit();
            }
        }

        public void MakeDisappear()
        {
            if (!disappear)
            {
                _fader.FadeOut(F);
                disappear = true;
                if (removeCollider)
                {
                    if (_collider != null)
                        _collider.isTrigger = true;
                    if (_rigidbody != null)
                        _rigidbody.Sleep();
                }

            }
        }

        public void MakeAppear()
        {
            if (disappear)
            {
                if (removeCollider)
                    _fader.FadeIn(FinishFadeIn);
                else
                    _fader.FadeIn(F);
                disappear = false;
            }
        }


        private void OnNotLit()
        {
            MakeDisappear();
        }

        private void OnLit()
        {
            MakeAppear();  
        }

        public void FinishFadeIn()
        {
            if (_collider != null)
                _collider.isTrigger = false;
            if (_rigidbody != null)
                _rigidbody.WakeUp();

        }

        public void F()
        {
        }
    }
}
