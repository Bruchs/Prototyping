using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Prototyping
{
    public class Welcome : MonoBehaviour
    {
        private string welcomeMessage = "WELCOME";
        private Text welcomeText;
        private GameObject welcomeCanvas;

        void Start()
        {    
            SetInitialReferences();
            WelcomeMessage();
        }

        void SetInitialReferences()
        {
            welcomeCanvas = GameObject.Find("Start Canvas");
            welcomeText = GameObject.Find("Text Welcome").GetComponent<Text>();
        }

        void WelcomeMessage()
        {
            if (welcomeText != null)
            {
                welcomeText.text = welcomeMessage;
            }
            else
            {
                Debug.Log("Welcome Message Not Assigned");
            }
            StartCoroutine(DisableCanvas(3.5f));
        }

       IEnumerator DisableCanvas(float waitTime)
       {
            yield return new WaitForSeconds(waitTime);
            welcomeCanvas.SetActive(false);
       }
    }
}

