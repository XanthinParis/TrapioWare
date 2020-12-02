using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapioWare
{
    namespace Spin
    {
        public class SpinManager : TimedBehaviour
        {
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

                if(Tick == 8)
                {
                    Debug.Log("Lose");
                }
            }
        }
    }
}