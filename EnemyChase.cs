using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class EnemyChase : MonoBehaviour
    {
        public LayerMask detectionLayer;

        private Transform enemyTransform;
        private NavMeshAgent enemyNavMeshAgent;
        private Collider[] hitColliders;
        private float checkRate;
        private float nextCheck;
        private float detectionRadius = 20f;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckPlayerInRange();
        }

        void SetInitialReferences()
        {
            enemyNavMeshAgent = GetComponent<NavMeshAgent>();
            enemyTransform = transform;
            checkRate = Random.Range(0.4f, 0.8f);
        }

        void CheckPlayerInRange()
        {
            if (Time.time > nextCheck && enemyNavMeshAgent.enabled == true)
            {
                nextCheck = Time.time + checkRate;
                hitColliders = Physics.OverlapSphere(enemyTransform.position, detectionRadius, detectionLayer);

                if (hitColliders.Length > 0)
                {
                    enemyNavMeshAgent.SetDestination(hitColliders[0].transform.position);
                }
            }
        }
    }
}