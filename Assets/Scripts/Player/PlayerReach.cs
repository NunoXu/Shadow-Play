using LOS.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerReach : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        public Color litColor;
        public Color notLitColor;

        void Start()
        {
            _renderer = (SpriteRenderer)GetComponent<Renderer>();

            LOSEventTrigger trigger = GetComponent<LOSEventTrigger>();
            trigger.OnNotTriggered += OnNotLit;
            trigger.OnTriggered += OnLit;

            OnNotLit();
        }

        private void OnNotLit()
        {
            _renderer.color = notLitColor;
        }

        private void OnLit()
        {
            _renderer.color = litColor;
        }
    }
}
