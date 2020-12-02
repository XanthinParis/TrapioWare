using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrapioWare
{
    namespace Spin
    {
        public class HammerPhysicController : TimedBehaviour
        {
            [Header("Spin Settings")]
            [Range(0.0f, 720.0f)] public float rotationStep;
            [Range(0.0f, 100.0f)] public float force;
            [Range(0.0f, 1000.0f)] public float maxSpiningSpeed;
            public DistanceJoint2D joint;

            [Header("Technical Settings")]
            [Range(0.0f, 1.0f)] public float minimumJoystickTilt = 0.8f;
            public bool isUsingRightJoystick = true;
            public Text[] debugText;

            [Header("Launch Settings")]
            public float launchSpeedRatio;

            private Vector2 currentJoystickDirection;
            private Rigidbody2D hammerRb;
            private bool hammerStartedSpinning;
            private bool hammerReleased;

            private float joystickAngleProgression;
            private float joystickAngleBackwardProgression;
            private float currentJoystickAngle;
            private bool isStartAngleSet;
            private float previousJoystickAngle;
            private float currentJoystickAngleMovement;
            private bool bumperPressed;
            private SpriteRenderer sprite;

            public override void Start()
            {
                base.Start();
                hammerRb = GetComponent<Rigidbody2D>();
            }

            public void Update()
            {
                bumperPressed = Input.GetButton(isUsingRightJoystick ? "Left_Bumper" : "Right_Bumper");

                currentJoystickDirection = new Vector2(isUsingRightJoystick ? Input.GetAxis("Right_Joystick_X") : Input.GetAxis("Left_Joystick_X"),
                    -(isUsingRightJoystick ? Input.GetAxis("Right_Joystick_Y") : Input.GetAxis("Left_Joystick_Y")));
                currentJoystickAngle = Vector2.SignedAngle(Vector2.right, currentJoystickDirection);
                if (currentJoystickAngle < 0)
                {
                    currentJoystickAngle += 360;
                }

                RotateSprite();
            }


            public override void FixedUpdate()
            {
                base.FixedUpdate();

                UpdateHammerMovement();
            }


            public override void TimedUpdate()
            {

            }

            private void UpdateHammerMovement()
            {
                if (currentJoystickDirection.magnitude > minimumJoystickTilt)
                {
                    if (!isStartAngleSet)
                    {
                        isStartAngleSet = true;
                        previousJoystickAngle = currentJoystickAngle;
                    }

                    currentJoystickAngleMovement = currentJoystickAngle - previousJoystickAngle;
                    if (currentJoystickAngleMovement < 180 && currentJoystickAngleMovement >= 0)
                    {
                        joystickAngleProgression += currentJoystickAngleMovement;
                    }

                    if (joystickAngleProgression > rotationStep)
                    {
                        joystickAngleProgression = 0;
                        isStartAngleSet = false;
                        IncreaseHammerSpeed(true);
                    }


                    if (currentJoystickAngleMovement > -180 && currentJoystickAngleMovement < 0)
                    {
                        joystickAngleBackwardProgression -= currentJoystickAngleMovement;
                    }

                    if (joystickAngleBackwardProgression > rotationStep)
                    {
                        joystickAngleBackwardProgression = 0;
                        isStartAngleSet = false;
                        IncreaseHammerSpeed(false);
                    }

                    previousJoystickAngle = currentJoystickAngle;
                }
                else
                {
                    isStartAngleSet = false;
                    joystickAngleProgression = 0;
                    joystickAngleBackwardProgression = 0;
                }
                debugText[0].text = "Current Joystick Angle : " + currentJoystickAngle;
                debugText[1].text = "Joystick Angle Progression : " + joystickAngleProgression;
                debugText[2].text = "Joystick Angle Back Progression : " + joystickAngleProgression;

                if (bumperPressed && hammerStartedSpinning && !hammerReleased)
                {
                    ReleaseHammer();
                }
            }

            private void IncreaseHammerSpeed(bool clockwise)
            {
                if(!hammerReleased)
                {
                    hammerStartedSpinning = true;

                    Vector2 hammerDirectionFromCenter = transform.position - joint.transform.position;
                    float hammerClockwiseAngle = Vector2.SignedAngle(Vector2.right, hammerDirectionFromCenter) + (clockwise ? 90 : -90);
                    Vector2 hammerClockwiseDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * hammerClockwiseAngle), Mathf.Sin(Mathf.Deg2Rad * hammerClockwiseAngle));
                    hammerRb.velocity += hammerClockwiseDirection.normalized * force;
                }
            }

            private void ReleaseHammer()
            {
                joint.enabled = false;
                hammerReleased = true;
            }

            private void RotateSprite()
            {
                Vector2 hammerDirectionFromCenter = transform.position - joint.transform.position;
                transform.rotation = Quaternion.Euler(0.0f, 0.0f, Vector2.SignedAngle(Vector2.right, hammerDirectionFromCenter));
            }
        }
    }
}