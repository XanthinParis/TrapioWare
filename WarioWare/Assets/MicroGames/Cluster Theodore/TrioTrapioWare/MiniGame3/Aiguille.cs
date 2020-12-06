using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrioName
{
    namespace MiniGameName
    {
        public class Aiguille : TimedBehaviour
        {
            float rotationAiguille = 45f + 15.07f;

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
                ChangeTheRotation();
            }
            void ChangeTheRotation()
            {
                rotationAiguille = rotationAiguille - 45f;
                transform.eulerAngles = new Vector3(0, 0, rotationAiguille);
            }
        }
    }
}