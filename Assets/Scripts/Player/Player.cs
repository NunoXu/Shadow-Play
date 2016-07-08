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
        private LOS.LOSObstacle losObs;
        private Color GREEN = new Color(0, 195f / 255f, 66f / 255f, 255f / 255f);


        void Start()
        {
            spriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
            losObs = GetComponentInChildren<LOS.LOSObstacle>();

            foreach (GameObject lantern in GameObject.FindGameObjectsWithTag("Lantern"))
            {
                lanterns.Add(lantern.GetComponent<Lantern>());
            }
            ToggleTrans();
        }

        void Update()
        {
            if (LanternPickedup != null)
            {
                if (Vector3.Distance(this.transform.position, LanternPickedup.transform.position) >= 1.5f)
                {
                    DropLantern();
                }
            }
        }

        void FixedUpdate()
        {
            Vector3 pos = transform.position;
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
                var direction = lantern.transform.position - transform.position;

                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, LayerMask.GetMask("Obstacles", "Glass"));
                if (hit.collider == null)
                {
                    if (distance < closestDistance)
                    {
                        closestLantern = lantern;
                        closestDistance = distance;
                    }
                }

            }

            if (closestLantern != null)
            {
                LanternPickedup = gm.PickupLantern(this, closestLantern);
                if (LanternPickedup != null)
                {
                    var newcolor = Color.red;
                    newcolor.a = spriteRenderer.color.a;
                    spriteRenderer.color = newcolor;
                }
            }
        }

        public void DropLantern()
        {
            gm.DropLantern(LanternPickedup);
            LanternPickedup = null;
            var newcolor = GREEN;
            newcolor.a = spriteRenderer.color.a;
            spriteRenderer.color = newcolor;
        }

        public void ToggleTrans()
        {
            if (isTransparent())
            {
                setLayer(this.gameObject, LayerMask.NameToLayer("Player"));
                var newcolor = spriteRenderer.color;
                newcolor.a = Mathf.Clamp(spriteRenderer.color.a * 2, 0.0f, 1.0f);
                spriteRenderer.color = newcolor;

            }
            else
            {
                setLayer(this.gameObject, LayerMask.NameToLayer("TransPlayer"));
                var newcolor = spriteRenderer.color;
                newcolor.a = Mathf.Clamp(spriteRenderer.color.a / 2, 0.0f, 1.0f);
                spriteRenderer.color = newcolor;
            }

            losObs.enabled = !losObs.enabled;
        }

        public bool isTransparent()
        {
            return !losObs.enabled;
        }

        private void setLayer(GameObject obj, int newLayer)
        {
            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                setLayer(child.gameObject, newLayer);
            }
        }
    }
}
