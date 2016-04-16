using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class Player : MonoBehaviour
    {

        public GameManager gm;
        public float MoveSpeed;

        [HideInInspector]
        public Lantern LanternPickedup = null;

        private IList<Lantern> lanterns = new List<Lantern>();
        private SpriteRenderer spriteRenderer;


        void Start()
        {
            spriteRenderer = this.GetComponent<SpriteRenderer>();

            foreach (GameObject lantern in GameObject.FindGameObjectsWithTag("Lantern"))
            {
                lanterns.Add(lantern.GetComponent<Lantern>());
            }
        }

        void Update()
        {
            /*if (LanternPickedup != null)
            {
                if (Vector3.Distance(this.transform.position, LanternPickedup.transform.position) >= 1.2f)
                {
                    DropLantern();
                }
            }*/
        }

        void FixedUpdate()
        {
            Vector3 pos = transform.position;
            Vector3 oldPlayerPos = pos;
            pos.x += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
            pos.y += Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }

        public void PickUpLantern()
        {
            Lantern closestLantern = null;
            float closestDistance = float.PositiveInfinity;

            foreach (Lantern lantern in lanterns)
            {
                var distance = Vector3.Distance(this.transform.position, lantern.transform.position);
                if (distance < closestDistance) {
                    closestLantern = lantern;
                    closestDistance = distance;
                }
            }

            if (closestLantern != null)
            {
                LanternPickedup = gm.PickupLantern(this, closestLantern);
                if (LanternPickedup != null)
                    spriteRenderer.color = Color.red;
            }
        }

        public void DropLantern()
        {
            gm.DropLantern(LanternPickedup);
            LanternPickedup = null;
            spriteRenderer.color = new Color32(0, 195, 66, 255);
        }
    }
}
