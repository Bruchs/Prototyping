using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class Shoot : MonoBehaviour
    {

        private float fireRate = 0.3f;
        private float nextFire;
        private RaycastHit rayHit;
        private float rayRange = 300f;
        private Transform rayTransform;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInput();
        }

        void SetInitialReferences()
        {
            rayTransform = transform;
        }

        void CheckForInput()
        {
            if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Debug.Log("Key Pressed");
            }

            if (Input.GetButton("Fire2") && Time.time > nextFire)
            {
                Debug.DrawRay(rayTransform.TransformPoint(0f, 0f, 0.5f), transform.forward, Color.green, 2);
                if (Physics.Raycast(rayTransform.TransformPoint(0f, 0f, 0.5f), transform.forward, out rayHit, rayRange))
                {
                    if (rayHit.transform.CompareTag("Enemy"))
                    {
                        Debug.Log("Enemy" + " " + rayHit.transform.name);
                    }
                    else
                    {
                        Debug.Log("Not An Enemy");
                    }
                }
                nextFire = Time.time + fireRate;
            }
        }
    }
}

