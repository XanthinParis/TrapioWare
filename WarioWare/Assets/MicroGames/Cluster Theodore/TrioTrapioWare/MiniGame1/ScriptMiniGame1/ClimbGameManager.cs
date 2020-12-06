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
    public GameObject playerSkin;
    public int playerPosition = 0;

    [Header("InputBools")]
    [SerializeField] private bool canLeft = false;
    [SerializeField] private bool canRight = true;
    public bool finishInstantiate = false;
    public bool win = false;

    public bool needToStop = false;
   

    private void Awake()
    {
        CreateSingleton(true);
    }
    
    private void Update()
    {
        if (needToStop)
        {
            canLeft = false;
            canRight = false;
        }

        if (playerPosition == positions.Count && finishInstantiate && !win)
        {
            win = true;
            canLeft = false;
            canRight = false;

            Debug.Log("You WIN");

        }

        if (finishInstantiate && !needToStop && (canLeft || canRight))
        {
            player.transform.position = positions[playerPosition].transform.position;
        } 
        
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) && finishInstantiate)
        {
            if(playerPosition < positions.Count && !needToStop){
                
                PlayerInput();
            }
            
        }
    }

    void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0) && canLeft)
        {
            //Debug.Log("Left");
            canRight = true;
            playerPosition += 1;
            canLeft = false;
            playerSkin.GetComponent<SpriteRenderer>().flipX = false;
            return;

        }
        else if (Input.GetMouseButtonDown(1) && canRight)
        {
            //Debug.Log("Right");
            canLeft = true;
            canRight = false;
            playerPosition++;
            playerSkin.GetComponent<SpriteRenderer>().flipX = true;
            return;
        }
    }
}
