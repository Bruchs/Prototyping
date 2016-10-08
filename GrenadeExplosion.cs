using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class GrenadeExplosion : MonoBehaviour
    {
        private Collider[] hitColliders;
        private float destroyTime = 3.5f;
        private float blastRadius = 5f;
        private float explosionPower = 200f;

        public LayerMask explosionLayers;

        void OnCollisionEnter(Collision grenadeCollision)
        {
            ExplosionWork(grenadeCollision.contacts[0].point);
            Destroy(gameObject);
        }

        void ExplosionWork(Vector3 explosionPoint)
        {
            hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

            foreach (Collider hitCollider in hitColliders )
            {
                if (hitCollider.GetComponent<NavMeshAgent>() != null)
                {
                    hitCollider.GetComponent<NavMeshAgent>().enabled = false;
                    hitCollider.GetComponent<Rigidbody>().isKinematic = false;
                }

                if (hitCollider.GetComponent<Rigidbody>() != null)
                {
                    hitCollider.GetComponent<Rigidbody>().isKinematic = false;
                    hitCollider.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                }

                if (hitCollider.CompareTag("Enemy"))
                {
                    Destroy(hitCollider.gameObject, destroyTime);
                }
            }
        }
    }
}
