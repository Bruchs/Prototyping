using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class ThrowGrenade : MonoBehaviour
    {

        public GameObject grenadePrefab;

        private Transform grenadeTransform;
        private float propulsionForce = 200f;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Grenade"))
            {
                SpawnGrenade();
            }
        }

        void SetInitialReferences()
        {
            grenadeTransform = transform;
        }


        void SpawnGrenade()
        {
            GameObject grenadePref = Instantiate(grenadePrefab, grenadeTransform.TransformPoint(0f, 0f, 1f), grenadeTransform.rotation) as GameObject;
            grenadePref.GetComponent<Rigidbody>().AddForce(grenadeTransform.forward * propulsionForce, ForceMode.Impulse);
            Destroy(grenadePref, 10);
        }
    }

}
