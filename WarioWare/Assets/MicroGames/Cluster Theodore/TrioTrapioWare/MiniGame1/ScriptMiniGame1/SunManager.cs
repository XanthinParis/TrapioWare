using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Testing;


namespace TrapioWare
{
    namespace Climb
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

                if (TrapioWare.Climb.ClimbGameManager.Instance.needToStop == false && timerDead !=8)
                {
                    gameObject.GetComponent<Animator>().SetTrigger("TickTrigger");
                }

                if(timerDead == 8 && ClimbGameManager.Instance.lose == false)
                {
                    //Manager.Instance.Result(false);
                    Debug.Log("You Lose");
                    TrapioWare.Climb.ClimbGameManager.Instance.lose = true;
                    TrapioWare.Climb.ClimbGameManager.Instance.needToStop = true;
                }

            }
        }
    }
}