﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Scripted_Events.Dialogue
{
    class EnterTrigger : MonoBehaviour
    {
        private ShowDialogue dialogue;

        void Start()
        {
            dialogue = GetComponentInParent<ShowDialogue>();
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            if (e.gameObject.tag == "Player")
            {
                dialogue.TriggeredFadeIn();
                this.gameObject.SetActive(false);
            }
        }

    }
}