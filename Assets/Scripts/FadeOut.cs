using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class FadeOut : MonoBehaviour
    {
        private FadeObjectInOut _fader;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(1);

            _fader = GetComponent<FadeObjectInOut>();
            _fader.FadeOut(() => { gameObject.SetActive(false); });
        }

        
    }
}
