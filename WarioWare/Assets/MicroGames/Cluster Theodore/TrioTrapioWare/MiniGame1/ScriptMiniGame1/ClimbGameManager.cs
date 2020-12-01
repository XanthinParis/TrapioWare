using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbGameManager : Singleton<ClimbGameManager>
{
    [Header("Tableau de Positions")]
    public GameObject ladderParent;
    public List<GameObject> positions = new List<GameObject>();
    public bool needToCheck = false;

    [Header("Variables")]
    public int numberOfLadder = 0;
    public int numberOfLadderNeeded = 0;

    [Header("PlayerReference")]
    public GameObject player;
    public int playerPosition;

    [Header("InputBools")]
    [SerializeField] private bool canLeft = false;
    [SerializeField] private bool canRight = true;

    private void Awake()
    {
        CreateSingleton(true);
    }
    
    private void Update()
    {
        player.transform.position = positions[playerPosition].transform.position;

        PlayerInput();
    }

    void PlayerInput()
    {
        if (Input.GetButtonDown("A_Button") && canLeft)
        {
            Debug.Log("Left");
            canRight = true;
            playerPosition += 1;
            canLeft = false;
            return;

        }
        else if (Input.GetButtonDown("Right_Bumper") && canRight)
        {
            Debug.Log("Right");
            canLeft = true;
            canRight = false;
            playerPosition++;
            return;
        }
    }
}
