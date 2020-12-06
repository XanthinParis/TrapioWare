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

            private bool hasWon;
            public override void Start()
            {
                base.Start();
            }

            public override void FixedUpdate()
            {
                base.FixedUpdate();
            }

            public override void TimedUpdate()
            {
                base.TimedUpdate();

                if(Tick - 1 == 8 && !hasWon)
                {
                    Debug.Log("Lose");
                    Manager.Instance.Result(false);
                }
            }

            public void Win()
            {
                if(!hasWon)
                {
                    hasWon = true;
                    Manager.Instance.Result(true);
                }
            }
        }
    }
}