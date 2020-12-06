using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioTrapioWare

{
    namespace Swipe
    {
        /// <summary>
        /// Roman Detue
        /// </summary>
        public class Initialisation : TimedBehaviour
        {

            public GameObject[] tinderProfile;
            public GameObject[] tinderPaper;

            public bool[] goodProfile;

            public int goodProfileNumber;
            public int profilAnalizing = 0;
            public int tick = 0;

            public override void Start()
            {
                base.Start(); //Do not erase this line!
                tinderProfile = GameObject.FindGameObjectsWithTag("Button1");
                tinderPaper = GameObject.FindGameObjectsWithTag("Button2");
                for (int positionOfArray = 0; positionOfArray < tinderProfile.Length; positionOfArray++)
                {
                    GameObject obj = tinderProfile[positionOfArray];
                    GameObject obj2 = tinderPaper[positionOfArray];
                    int randomizeArray = Random.Range(0, positionOfArray);
                    tinderProfile[positionOfArray] = tinderProfile[randomizeArray];
                    tinderPaper[positionOfArray] = tinderPaper[randomizeArray];
                    tinderProfile[randomizeArray] = obj;
                    tinderPaper[randomizeArray] = obj2;
                    //obj.GetComponent<SpriteRenderer>().sortingOrder = (25 - randomizeArray);
                }
                for (int i = 0; i < 25; i++)
                {
                tinderProfile[i].GetComponent<SpriteRenderer>().sortingOrder = (27 - i);
                }
                    for (int i = 0; i < 25; i++)
                {
                    goodProfile[i] = false;
                }
                goodProfileNumber = Random.Range(1, 25);
                for (int i = 0; i < tinderPaper.Length; i++)
                {
                    tinderPaper[i].SetActive(false);
                }
                goodProfile[goodProfileNumber] = true;
                tinderPaper[goodProfileNumber].SetActive(true);
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                tick++;
            }

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (goodProfile[profilAnalizing] == true)
                    {
                        Debug.Log("Victoire");
                    }
                    if (goodProfile[profilAnalizing] == false)
                    {
                        Debug.Log("Défaite");
                    }
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (goodProfile[profilAnalizing] == true)
                    {
                        Debug.Log("Défaite");
                    }
                    if (goodProfile[profilAnalizing] == false)
                    {
                        tinderProfile[profilAnalizing].SetActive(false);
                        profilAnalizing++;
                    }
                }
            }

        }
    }
}
