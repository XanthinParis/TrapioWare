using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Testing;

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
            public GameObject[] tinderPaperDirty;
            public GameObject breakScreen;

            public bool[] goodProfile;
            public bool canPlay;

            public int goodProfileNumber;
            public int profilAnalizing = 0;
            public int tickSwipe = 0;
            Vector3 Rotation = new Vector3 (0f, 0f, 28f);


            public override void Start()
            {
                base.Start(); //Do not erase this line!
                tinderProfile = GameObject.FindGameObjectsWithTag("Button1");
                tinderPaper = GameObject.FindGameObjectsWithTag("Button2");
                tinderPaperDirty = GameObject.FindGameObjectsWithTag("Wall");
                for (int positionOfArray = 0; positionOfArray < tinderProfile.Length; positionOfArray++)
                {
                    GameObject obj = tinderProfile[positionOfArray];
                    GameObject obj2 = tinderPaper[positionOfArray];
                    GameObject obj3 = tinderPaperDirty[positionOfArray];
                    int randomizeArray = Random.Range(0, positionOfArray);
                    tinderProfile[positionOfArray] = tinderProfile[randomizeArray];
                    tinderPaper[positionOfArray] = tinderPaper[randomizeArray];
                    tinderPaperDirty[positionOfArray] = tinderPaperDirty[randomizeArray];
                    tinderProfile[randomizeArray] = obj;
                    tinderPaper[randomizeArray] = obj2;
                    tinderPaperDirty[randomizeArray] = obj3;
                }

                for (int i = 0; i < 16; i++)
                {
                    tinderProfile[i].GetComponent<SpriteRenderer>().sortingOrder = (17 - i);
                }

                for (int i = 0; i < 16; i++)
                {
                    goodProfile[i] = false;
                }

                goodProfileNumber = Random.Range(1, 16);

                for (int i = 0; i < tinderPaper.Length; i++)
                {
                    tinderPaper[i].SetActive(false);
                    tinderPaperDirty[i].SetActive(false);
                }

                switch (currentDifficulty)
                {
                    case Testing.Manager.Difficulty.EASY:
                        goodProfile[goodProfileNumber] = true;
                        tinderPaper[goodProfileNumber].SetActive(true);
                        breakScreen.SetActive(false);
                        break;
                    case Testing.Manager.Difficulty.MEDIUM:
                        goodProfile[goodProfileNumber] = true;
                        tinderPaper[goodProfileNumber].SetActive(true);

                        breakScreen.SetActive(true);
                        break;
                    case Testing.Manager.Difficulty.HARD:
                        goodProfile[goodProfileNumber] = true;
                        tinderPaperDirty[goodProfileNumber].SetActive(true);
                        breakScreen.SetActive(true);
                        break;
                }
            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!
            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                tickSwipe++;
                if (Tick == 8)
                {

                }
            }

            void Update()
            {
                if (Input.GetButtonDown("B_Button") && canPlay)
                {
                    if (goodProfile[profilAnalizing] == true)
                    {
                        SwipeDroite();
                        canPlay = false;
                        Debug.Log("Victoire");
                    }
                    if (goodProfile[profilAnalizing] == false)
                    {
                        SwipeDroite();
                        canPlay = false;
                        Debug.Log("Défaite");
                    }
                }
                if (Input.GetButtonDown("X_Button") && canPlay)
                {
                    if (goodProfile[profilAnalizing] == true)
                    {
                        SwipeGauche();
                        canPlay = false;
                        Debug.Log("Défaite");
                    }
                    if (goodProfile[profilAnalizing] == false)
                    {
                        SwipeGauche();
                        profilAnalizing++;
                    }
                }
            }
            public void SwipeGauche()
            {
                tinderProfile[profilAnalizing].transform.DOMoveX(1f, 0.2f);
                tinderProfile[profilAnalizing].transform.DOMoveY(-3f, 0.2f);
                tinderProfile[profilAnalizing].transform.DORotate(Rotation, 0.2f);
            }
            public void SwipeDroite()
            {
                tinderProfile[profilAnalizing].transform.DOMoveX(7f, 0.2f);
                tinderProfile[profilAnalizing].transform.DOMoveY(-3f, 0.2f);
                tinderProfile[profilAnalizing].transform.DORotate(-Rotation, 0.2f);
            }
        }
    }
}
