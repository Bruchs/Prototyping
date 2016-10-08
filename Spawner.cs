using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class Spawner : MonoBehaviour
    {
        public GameObject objectSpawned;
        public int numberOfSpawns;

        private float spawnRadius = 5f;
        private Vector3 spawnPosition;
        private GameManager_EventMaster eventMasterScript;


        void OnEnable()
        {
            SetInitialReferences();
            eventMasterScript.myGeneralEvent += SpawnObject;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SpawnObject;
        }

        void SpawnObject()
        {
            for (int i = 0; i < numberOfSpawns; i++)
            {
                spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                Instantiate(objectSpawned, spawnPosition, Quaternion.identity);
            }
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
        }
    }
}
