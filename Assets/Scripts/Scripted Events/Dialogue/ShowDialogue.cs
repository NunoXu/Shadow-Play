using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scripted_Events.Dialogue
{
    class ShowDialogue : MonoBehaviour
    {
        private Text dialogueText;
        public string dialogue = "Are you not a child of dark? Cast thy shadow upon the light.\n(Press Z)";

        void Start()
        {
            dialogueText = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Text>();
        }

        public void TriggeredFadeIn()
        {
            dialogueText.GetComponent<FadeTextInOut>().FadeIn(() => { });
            dialogueText.text = dialogue;
        }

        public void TriggeredFadeOut()
        {
            dialogueText.GetComponent<FadeTextInOut>().FadeOut(() => { });
            this.gameObject.SetActive(false);
        }



    }
}
