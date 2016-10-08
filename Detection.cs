using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class Detection : MonoBehaviour
    {
        private LayerMask detectionLayer;
        private RaycastHit detectionHit;
        private float detectionRange = 5;
        private float checkRate = 0.5f;
        private float nextCheck;
        private Transform detectionTransform;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            DetectItems();
        }

        void SetInitialReferences()
        {
            detectionTransform = transform;
            detectionLayer = 1 << 9;
        }

        void DetectItems()
        {
            if (Time.time > nextCheck)
            {
                nextCheck = Time.time + checkRate;

                if (Physics.Raycast(detectionTransform.position, detectionTransform.forward, out detectionHit, detectionRange, detectionLayer))
                {
                    Debug.Log(detectionHit.transform.name + " " + "Is An Item");
                }
            }
        }
    }
}
