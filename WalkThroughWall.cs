using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class WalkThroughWall : MonoBehaviour
    {
        private Color wallColorNotSolid = new Color(0.5f, 1f, 0.5f, 0.5f);
        private GameManager_EventMaster eventMasterScript;

        void OnEnable()
        {
            SetInitialReferences();
            eventMasterScript.myGeneralEvent += SetLayerToNotSolid;
        }

        void OnDisable()
        {
            eventMasterScript.myGeneralEvent -= SetLayerToNotSolid;
        }

        void SetInitialReferences()
        {
            eventMasterScript = GameObject.Find("Game Manager").GetComponent<GameManager_EventMaster>();
        }

        void SetLayerToNotSolid()
        {
            gameObject.layer = LayerMask.NameToLayer("Not Solid");
            GetComponent<Renderer>().material.SetColor("_Color", wallColorNotSolid);
        }
    }
}

