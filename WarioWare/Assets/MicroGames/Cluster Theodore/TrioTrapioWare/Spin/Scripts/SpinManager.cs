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
            public DifficultySetup[] difficultySetups;
            public bool useCustomDifficulty;
            public int difficulty;
            public bool hasInlimitedTime;

            [HideInInspector] public bool hasWon;
            [HideInInspector] public bool gameFinished;

            public override void Start()
            {
                base.Start();
                if(!useCustomDifficulty)
                {
                    difficulty = (int)currentDifficulty;
                }
                InitializeDifficulty();
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