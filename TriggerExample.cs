using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class TriggerExample : MonoBehaviour
    {
        private WalkThroughWall walkThroughWallScript;
        private GameManager_EventMaster eventMasterScript;

        void Start()
        {
            SetInitialReferences();
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
        }

        void OnTriggerEnter(Collider other)
        {
            eventMasterScript.CallMyGeneralEvent();
            Destroy(gameObject);
        }
    }
}


