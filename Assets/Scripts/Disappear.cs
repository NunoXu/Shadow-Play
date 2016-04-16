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
            trigger.OnNotTriggered += OnNotLit;
            trigger.OnTriggered += OnLit;

            OnNotLit();
        }


        private void OnNotLit()
        {
            _fader.FadeOut();
            if (_collider != null)
                _collider.isTrigger = true;
            if (_rigidbody != null)
                _rigidbody.Sleep();
        }

        private void OnLit()
        {
            _fader.FadeIn();
            if (_collider != null)
                _collider.isTrigger = false;
            if (_rigidbody != null)
                _rigidbody.WakeUp();
        }
    }
}
