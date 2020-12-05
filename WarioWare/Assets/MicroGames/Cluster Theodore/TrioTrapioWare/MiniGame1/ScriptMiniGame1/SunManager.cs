using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;

namespace TrioName
{
    namespace MiniGameName
    {
        public class SunManager : TimedBehaviour
        {
            [SerializeField] private int timerDead = 0;

            public override void Start()
            {
                base.Start(); //Do not erase this line!

            }

            //FixedUpdate is called on a fixed time.
            public override void FixedUpdate()
            {
                base.FixedUpdate(); //Do not erase this line!

            }

            //TimedUpdate is called once every tick.
            public override void TimedUpdate()
            {
                timerDead++;
                gameObject.GetComponent<Animator>().SetTrigger("TickTrigger");
            
                if(timerDead == 8)
                {
                    //Manager.Instance.Result(false);
                    Debug.Log("You Lose");
                }

            }
        }
    }
}