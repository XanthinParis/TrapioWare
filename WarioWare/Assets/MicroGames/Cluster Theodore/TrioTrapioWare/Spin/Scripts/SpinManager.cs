﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrapioWare
{
    namespace Spin
    {
        public class SpinManager : TimedBehaviour
        {
            public DifficultySetup[] difficultySetups;
            public bool useCustomDifficulty;
            public int difficulty;
            public bool hasInlimitedTime;
            public GameObject[] holes;
            public GameObject canonHoleEffect;
            public GameObject canonHoleFinalEffect;
            public AudioClip[] canonBreakClips;

            [HideInInspector] public bool hasWon;
            [HideInInspector] public bool gameFinished;
            private AudioSource source;

            public override void Start()
            {
                base.Start();
                source = GetComponent<AudioSource>();

                if(!useCustomDifficulty)
                {
                    difficulty = (int)currentDifficulty;
                }
                InitializeDifficulty();

                for(int i = 0; i < holes.Length; i++)
                {
                    holes[i].SetActive(false);
                }
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();
            }

            public override void TimedUpdate()
            {
                base.TimedUpdate();
                if(Tick -2 < 7 && Tick - 2>= 0)
                {
                    SpawnHole(Tick - 2, false);
                }

                if(Tick - 1 == 8 && !gameFinished && !hasInlimitedTime)
                {
                    gameFinished = true;
                    SpawnHole(7, true);
                    Manager.Instance.Result(false);
                }
            }

            private void InitializeDifficulty()
            {
                for (int i = 0; i < 3; i++)
                {
                    difficultySetups[i].target.SetActive(false);
                    difficultySetups[i].background.SetActive(false);
                    difficultySetups[i].boundaries.SetActive(false);
                }

                difficultySetups[difficulty].target.SetActive(true);
                difficultySetups[difficulty].background.SetActive(true);
                difficultySetups[difficulty].boundaries.SetActive(true);
            }

            public void Win()
            {
                if(!gameFinished)
                {
                    gameFinished = true;
                    hasWon = true;
                    Manager.Instance.Result(true);
                }
            }

            private void SpawnHole(int canonHoleIndex, bool isFinal)
            {
                Instantiate(!isFinal? canonHoleEffect : canonHoleFinalEffect, holes[canonHoleIndex].transform.position, Quaternion.identity);
                holes[canonHoleIndex].SetActive(true);
                source.pitch = Random.Range(0.8f, 1.2f);
                source.PlayOneShot(canonBreakClips[Random.Range(0, canonBreakClips.Length)]);
            }

            [System.Serializable]
            public class DifficultySetup
            {
                public GameObject target;
                public GameObject background;
                public GameObject boundaries;
            }
        }
    }
}