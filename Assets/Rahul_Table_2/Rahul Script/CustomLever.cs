using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BNG
{
    public class CustomLever : GrabbableEvents
    {

        [Header("Rotation Limits")]
        [Tooltip("Maximum Z value in Local Euler Angles. Can be < -360. Ex : -450")]
        public float MinAngle = -360f;

        [Tooltip("Maximum Z value in Local Euler Angles. Can be > 360. Ex : 450")]
        public float MaxAngle = 360f;

        [Header("Rotation Object")]
        [Tooltip("The Transform to rotate on its Z axis.")]
        public Transform RotatorObject;

        [Header("Rotation Speed")]
        [Tooltip("How fast to move the wheel towards the target angle. 0 = Instant.")]
        public float RotationSpeed = 0f;

        [Header("Two-Handed Option")]
        [Tooltip("IF true both hands will effect the rotation of the steering wheel while grabbed with both hands. Set to false if you only want one hand to control the rotation.")]
        public bool AllowTwoHanded = true;

        [Header("Return to Center")]
        public bool ReturnToCenter = false;
        public float ReturnToCenterSpeed = 45;

        [Space]
        [Range(0f, 2f)]
        public float threshold = .5f;

        [Space]
        [Header("This event will automatically perfomed when lever rotaion value is equal to SteeringWheel Minimum value")]
        public UnityEvent MinimumValueEvent;

        [Space]
        [Header("This event will automatically performed when lever rotaion value is equal to SteeringWheel Maximum value")]
        public UnityEvent MaximumValueEvent;

        [HideInInspector]
        public bool isLeverOn;

        /// <summary>
        /// Returns the angle of the rotation, taking RotationSpeed into account
        /// </summary>
        public float Angle
        {
            get
            {
                return Mathf.Clamp(smoothedAngle, MinAngle, MaxAngle);
            }
        }

        /// <summary>
        /// Always returns the target angle, not taking RotationSpeed into account
        /// </summary>
        public float RawAngle
        {
            get
            {
                return targetAngle;
            }
        }

        public float ScaleValue
        {
            get
            {
                return GetScaledValue(Angle, MinAngle, MaxAngle);
            }
        }

        public float ScaleValueInverted
        {
            get
            {
                return ScaleValue * -1;
            }
        }

        public float AngleInverted
        {
            get
            {
                return Angle * -1;
            }
        }

        public Grabber PrimaryGrabber
        {
            get
            {
                return GetPrimaryGrabber();
            }
        }
        public Grabber SecondaryGrabber
        {
            get
            {
                return GetSecondaryGrabber();
            }
        }

        protected Vector3 rotatePosition;
        protected Vector3 previousPrimaryPosition;
        protected Vector3 previousSecondaryPosition;

        protected float targetAngle;
        protected float previousTargetAngle;

        /// <summary>
        /// This angle is smoothed towards target angle in Update using RotationSpeed
        /// </summary>
        protected float smoothedAngle;

        void Update()
        {

            // Calculate rotation if being held or returning to center
            if (grab.BeingHeld)
            {
                UpdateAngleCalculations();
            }
            else if (ReturnToCenter)
            {
                ReturnToCenterAngle();
            }

            // Apply the new angle
            ApplyAngleToSteeringWheel(Angle);


            // Call Event
            if (Angle >= MaxAngle - threshold && !isLeverOn)
            {
                MaximumValueEvent.Invoke();
                isLeverOn = true;
            }

            if (Angle <= MinAngle + threshold && isLeverOn)
            {
                MinimumValueEvent.Invoke();
                isLeverOn = false;
            }
        }

        public virtual void UpdateAngleCalculations()
        {

            float angleAdjustment = 0f;

            // Add first Grabber
            if (PrimaryGrabber)
            {
                rotatePosition = transform.InverseTransformPoint(PrimaryGrabber.transform.position);
                rotatePosition = new Vector3(rotatePosition.x, rotatePosition.y, 0);

                // Add in the angles to turn
                angleAdjustment += GetRelativeAngle(rotatePosition, previousPrimaryPosition);

                previousPrimaryPosition = rotatePosition;
            }

            // Add second Grabber
            if (AllowTwoHanded && SecondaryGrabber != null)
            {
                rotatePosition = transform.InverseTransformPoint(SecondaryGrabber.transform.position);
                rotatePosition = new Vector3(rotatePosition.x, rotatePosition.y, 0);

                // Add in the angles to turn
                angleAdjustment += GetRelativeAngle(rotatePosition, previousSecondaryPosition);

                previousSecondaryPosition = rotatePosition;
            }

            // Divide by two if being held by two hands
            if (PrimaryGrabber != null && SecondaryGrabber != null)
            {
                angleAdjustment *= 0.5f;
            }

            // Apply the angle adjustment
            targetAngle -= angleAdjustment;

            // Update Smooth Angle
            // Instant Rotation
            if (RotationSpeed == 0)
            {
                smoothedAngle = targetAngle;
            }
            // Apply smoothing based on RotationSpeed
            else
            {
                smoothedAngle = Mathf.Lerp(smoothedAngle, targetAngle, Time.deltaTime * RotationSpeed);
            }

            // Scrub the final results
            if (MinAngle != 0 && MaxAngle != 0)
            {
                targetAngle = Mathf.Clamp(targetAngle, MinAngle, MaxAngle);
                smoothedAngle = Mathf.Clamp(smoothedAngle, MinAngle, MaxAngle);
            }
        }

        public float GetRelativeAngle(Vector3 position1, Vector3 position2)
        {

            // Are we turning left or right?
            if (Vector3.Cross(position1, position2).z < 0)
            {
                return -Vector3.Angle(position1, position2);
            }

            return Vector3.Angle(position1, position2);
        }

        public virtual void ApplyAngleToSteeringWheel(float angle)
        {
            RotatorObject.localEulerAngles = new Vector3(0, 0, angle);
        }

        public override void OnGrab(Grabber grabber)
        {
            // Primary or secondary that grabbed us?
            if (grabber == SecondaryGrabber)
            {
                previousSecondaryPosition = transform.InverseTransformPoint(SecondaryGrabber.transform.position);

                // Discard the Z value
                previousSecondaryPosition = new Vector3(previousSecondaryPosition.x, previousSecondaryPosition.y, 0);
            }
            // Primary
            else
            {
                previousPrimaryPosition = transform.InverseTransformPoint(PrimaryGrabber.transform.position);

                // Discard the Z value
                previousPrimaryPosition = new Vector3(previousPrimaryPosition.x, previousPrimaryPosition.y, 0);
            }
        }

        public virtual void ReturnToCenterAngle()
        {

            bool wasUnderZero = smoothedAngle < 0;

            if (smoothedAngle > 0)
            {
                smoothedAngle -= Time.deltaTime * ReturnToCenterSpeed;
            }
            else if (smoothedAngle < 0)
            {
                smoothedAngle += Time.deltaTime * ReturnToCenterSpeed;
            }

            // Overshot
            if (wasUnderZero && smoothedAngle > 0)
            {
                smoothedAngle = 0;
            }
            else if (!wasUnderZero && smoothedAngle < 0)
            {
                smoothedAngle = 0;
            }

            // Snap if very close
            if (smoothedAngle < 0.02f && smoothedAngle > -0.02f)
            {
                smoothedAngle = 0;
            }

            // Set the target angle to our newly calculated angle
            targetAngle = smoothedAngle;
        }

        public Grabber GetPrimaryGrabber()
        {
            if (grab.HeldByGrabbers != null)
            {
                for (int x = 0; x < grab.HeldByGrabbers.Count; x++)
                {
                    Grabber g = grab.HeldByGrabbers[x];
                    if (g.HandSide == ControllerHand.Right)
                    {
                        return g;
                    }
                }
            }

            return null;
        }

        public Grabber GetSecondaryGrabber()
        {
            if (grab.HeldByGrabbers != null)
            {
                for (int x = 0; x < grab.HeldByGrabbers.Count; x++)
                {
                    Grabber g = grab.HeldByGrabbers[x];
                    if (g.HandSide == ControllerHand.Left)
                    {
                        return g;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a value between -1 and 1
        /// </summary>
        /// <param name="value">Current value to compute against</param>
        /// <param name="min">Minimum value of range used for conversion. </param>
        /// <param name="max">Maximum value of range used for conversion. Must be greater then min</param>
        /// <returns>Value between -1 and 1</returns>
        public virtual float GetScaledValue(float value, float min, float max)
        {
            float range = (max - min) / 2f;
            float returnValue = ((value - min) / range) - 1;

            return returnValue;
        }
    }
}

