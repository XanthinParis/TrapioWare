using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrapioWare
{
    namespace Spin
    {
        public class SpinManager : TimedBehaviour
        {
            public GameObject[] targets;
            public bool hasInlimitedTime;

            [HideInInspector] public bool hasWon;
            [HideInInspector] public bool gameFinished;

            public override void Start()
            {
                base.Start();
                for(int i = 0; i < 3; i++)
                {
                    targets[i].SetActive(false);
                }

                targets[(int)currentDifficulty].SetActive(true);
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();
            }

            public override void TimedUpdate()
            {
                base.TimedUpdate();

                if(Tick - 1 == 8 && !gameFinished && !hasInlimitedTime)
                {
                    gameFinished = true;
                    Manager.Instance.Result(false);
                }
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
        }
    }
}