using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapioWare
{
    namespace Spin
    {
        public class TargetHandler : TimedBehaviour
        {
            public SpinManager spinManager;
            public GameObject destroyEffectPrefab;

            private Collider2D targetCollider;
            private ContactFilter2D hammerFilter;

            public override void Start()
            {
                base.Start();
                targetCollider = GetComponent<Collider2D>();

                hammerFilter.SetLayerMask(LayerMask.GetMask("Enemy"));
                hammerFilter.useTriggers = true;
            }


            public override void FixedUpdate()
            {
                base.FixedUpdate();
                List<Collider2D> colliders = new List<Collider2D>();
                if(Physics2D.OverlapCollider(targetCollider, hammerFilter, colliders) > 0)
                {
                    Explode();
                }
            }


            public override void TimedUpdate()
            {

            }

            public void Explode()
            {
                Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                spinManager.Win();
            }
        }
    }
}