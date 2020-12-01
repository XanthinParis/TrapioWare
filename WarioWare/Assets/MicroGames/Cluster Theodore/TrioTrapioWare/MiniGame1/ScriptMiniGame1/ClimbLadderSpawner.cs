using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {
        public class ClimbLadderSpawner : MonoBehaviour
        {
            public GameObject ladderPrefab;


            // Start is called before the first frame update
            void Start()
            {
                if (ClimbGameManager.Instance.numberOfLadder < ClimbGameManager.Instance.numberOfLadderNeeded)
                {
                    GameObject instanciateLadder = Instantiate(ladderPrefab, transform.position, Quaternion.identity);
                    instanciateLadder.transform.parent = ClimbGameManager.Instance.ladderParent.transform;
                    ClimbGameManager.Instance.numberOfLadder += 1;
                    Debug.Log("if");
                }
                else
                {
                    ClimbGameManager.Instance.needToCheck = true;
                    Debug.Log("else");
                }

            }
        }
    }
}