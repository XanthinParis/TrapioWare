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
            public GameObject wanted;
            public GameObject auraMatch;
            public GameObject auraPersonnage;
            public GameObject personnageRondVert;

            public GameObject match;
            public GameObject ecranNoir;
            public GameObject[] greenCircle;
            public GameObject epeeDroit;
            public GameObject epeeGauche;

            public bool[] goodProfile;
            public bool canPlay;

            public int goodProfileNumber;
            public int profilAnalizing = 0;
            public int tickSwipe = 0;
            Vector3 RotationSwipe = new Vector3(0f, 0f, 28f);
            Vector3 RotationEpees = new Vector3(0f, 0f, 25f);


            public override void Start()
            {
                base.Start(); //Do not erase this line!

                RandomSorting();
                ecranNoir.SetActive(false);
                ProfilSelection();

                switch (currentDifficulty)
                {
                    case Difficulty.EASY:
                        tinderPaper[goodProfileNumber].SetActive(true);
                        breakScreen.SetActive(false);
                        break;
                    case Difficulty.MEDIUM:
                        tinderPaper[goodProfileNumber].SetActive(true);
                        breakScreen.SetActive(true);
                        break;
                    case Difficulty.HARD:
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
                        AnimVictoire();
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

                auraMatch.transform.Rotate(new Vector3(0, 0, 100f * Time.deltaTime));
                auraPersonnage.transform.Rotate(new Vector3(0, 0, 100f * Time.deltaTime));
            }
            public void RandomSorting()
            {
                tinderProfile = GameObject.FindGameObjectsWithTag("Button1");
                tinderPaper = GameObject.FindGameObjectsWithTag("Button2");
                tinderPaperDirty = GameObject.FindGameObjectsWithTag("Wall");
                greenCircle = GameObject.FindGameObjectsWithTag("Finish");
                for (int positionOfArray = 0; positionOfArray < tinderProfile.Length; positionOfArray++)
                {
                    GameObject obj = tinderProfile[positionOfArray];
                    GameObject obj2 = tinderPaper[positionOfArray];
                    GameObject obj3 = tinderPaperDirty[positionOfArray];
                    GameObject obj4 = greenCircle[positionOfArray];
                    int randomizeArray = Random.Range(0, positionOfArray);
                    tinderProfile[positionOfArray] = tinderProfile[randomizeArray];
                    tinderPaper[positionOfArray] = tinderPaper[randomizeArray];
                    tinderPaperDirty[positionOfArray] = tinderPaperDirty[randomizeArray];
                    greenCircle[positionOfArray] = greenCircle[randomizeArray];
                    tinderProfile[randomizeArray] = obj;
                    tinderPaper[randomizeArray] = obj2;
                    tinderPaperDirty[randomizeArray] = obj3;
                    greenCircle[randomizeArray] = obj4;

                    for (int i = 0; i < 16; i++)
                    {
                        tinderProfile[i].GetComponent<SpriteRenderer>().sortingOrder = (17 - i);
                    }
                }
            }

            public void ProfilSelection()
            {
                goodProfileNumber = Random.Range(1, 16);
                for (int i = 0; i < 16; i++)
                {
                    goodProfile[i] = false;
                }
                for (int i = 0; i < tinderPaper.Length; i++)
                {
                    tinderPaper[i].SetActive(false);
                    tinderPaperDirty[i].SetActive(false);
                }
                goodProfile[goodProfileNumber] = true;
            }

        public void SwipeGauche()
            {
                tinderProfile[profilAnalizing].transform.DOMoveX(1f, 0.2f);
                tinderProfile[profilAnalizing].transform.DOMoveY(-3f, 0.2f);
                tinderProfile[profilAnalizing].transform.DORotate(RotationSwipe, 0.2f);
            }
            public void SwipeDroite()
            {
                tinderProfile[profilAnalizing].transform.DOMoveX(7f, 0.2f);
                tinderProfile[profilAnalizing].transform.DOMoveY(-3f, 0.2f);
                tinderProfile[profilAnalizing].transform.DORotate(-RotationSwipe, 0.2f);
            }

            public void AnimVictoire()
            {
                ecranNoir.SetActive(true);
                for (int i = 0; i < greenCircle.Length; i++)
                {
                    greenCircle[i].SetActive(false);
                }
                greenCircle[goodProfileNumber].SetActive(true);
                greenCircle[goodProfileNumber].transform.DOScale(1f, (0.2f * 60 / bpm));
                personnageRondVert.transform.DOScale(0.2f, (0.2f * 60 / bpm));
                auraMatch.transform.DOScale(0.3f, (0.2f * 60 / bpm));
                auraPersonnage.transform.DOScale(0.3f, (0.2f * 60 / bpm));
                match.transform.DOScale(0.23f, (0.2f*60/bpm));
                epeeDroit.transform.DOMoveX(0.2f, (0.4f * 60 / bpm));
                epeeDroit.transform.DORotate(RotationEpees, (0.4f * 60 / bpm));
                epeeGauche.transform.DOMoveX(-0.2f, (0.4f * 60 / bpm));
                epeeGauche.transform.DORotate(-RotationEpees, (0.4f * 60 / bpm));
            }
        }
    }
}
