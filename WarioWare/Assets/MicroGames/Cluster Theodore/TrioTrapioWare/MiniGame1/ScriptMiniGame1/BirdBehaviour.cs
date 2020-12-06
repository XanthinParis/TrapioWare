using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    public bool goLeft = false;
    public bool goRight = false;

    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (goLeft && ClimbGameManager.Instance.needToStop == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        else if(goRight && ClimbGameManager.Instance.needToStop == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("You lose");
            ClimbGameManager.Instance.needToStop = true;
        }
    }
}
