using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadderManager : MonoBehaviour
{
    private void Update()
    {
        if (ClimbGameManager.Instance.needToCheck)
        {
            ClimbGameManager.Instance.needToCheck = false;
            UpdateList();
        }
    }


    private void UpdateList()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            ClimbGameManager.Instance.positions.Add(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
