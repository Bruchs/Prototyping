using UnityEngine;
using System.Collections;

namespace Prototyping
{
    public class FindEnemy : MonoBehaviour
    {

        GameObject[] enemies;

        // Use this for initialization
        void Start()
        {
            SearchForEnemies();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void SearchForEnemies()
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                foreach (GameObject gameEnemies in enemies)
                {
                    Debug.Log(gameEnemies.name);
                }
            }
        }
    }
}

