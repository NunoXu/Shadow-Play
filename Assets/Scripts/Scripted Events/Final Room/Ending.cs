using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scripted_Events.Final_Room
{
    class Ending : MonoBehaviour
    {
        public Graphic CameraCover;

        void Start()
        {
            CameraCover.CrossFadeAlpha(0.0f, 0.0f, false);
        }

        void OnTriggerEnter2D(Collider2D e)
        {
            CameraCover.gameObject.SetActive(true);
            CameraCover.CrossFadeAlpha(1.0f, 1.0f, false);
        }

    }
}
