using System;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Game.Scripts
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private WheelCollider rearRight, rearLeft, frontRight, frontLeft;

        [SerializeField]
        private Transform rearRightTransform, rearLeftTransform, frontRightTransform, frontLeftTransform;

        [SerializeField] private float speedCar, brakeCar;
        [SerializeField] private bool gasPressing, brakePressing;
        [SerializeField] private float speed, maxSpeed;
        [SerializeField] private Rigidbody rb;

        //
        [SerializeField] private float turnSensetivity = 1.0f;
        [SerializeField] private float maxSteerAngle = 45.0f;

        private float inputX;
        //

        private void FixedUpdate()
        {
            AnimateWheels();
        }

        private void Update()
        {
            speed = rb.velocity.sqrMagnitude;
            if (speed < maxSpeed)
            {
                if (gasPressing)
                {
                    rearLeft.brakeTorque = 0;
                    rearRight.brakeTorque = 0;
                    rearLeft.motorTorque = speedCar;
                    rearRight.motorTorque = speedCar;
                }
            }
            else
            {
                rearLeft.brakeTorque = brakeCar;
                rearRight.brakeTorque = brakeCar;
            }

            if (!brakePressing) return;
            rearLeft.brakeTorque = brakeCar;
            rearRight.brakeTorque = brakeCar;

        }

        public void BrakeDown()
        {
            brakePressing = true;
        }

        public void BrakeExit()
        {
            brakePressing = false;
        }

        public void GasDown()
        {
            gasPressing = true;
        }

        public void GasExit()
        {
            gasPressing = false;
            rearLeft.motorTorque = 0;
            rearRight.motorTorque = 0;
        }

        private void GetInputs()
        {
            inputX = Input.GetAxis("Horizontal");
        }


        public void LeftDwn()
        {
            var _steerAgnle = inputX * turnSensetivity * maxSteerAngle;
            frontLeft.steerAngle = -30;
            frontRight.steerAngle = -30;
            frontLeft.steerAngle = Mathf.Lerp(frontLeft.steerAngle, _steerAgnle, 0.5f);
            frontRight.steerAngle = Mathf.Lerp(frontRight.steerAngle, _steerAgnle, 0.5f);
        }

        public void RightDwn()
        {
            var _steerAgnle = inputX * turnSensetivity * maxSteerAngle;
            frontLeft.steerAngle = 30;
            frontRight.steerAngle = 30;
            frontLeft.steerAngle = Mathf.Lerp(frontLeft.steerAngle, _steerAgnle, 0.5f);
            frontRight.steerAngle = Mathf.Lerp(frontRight.steerAngle, _steerAgnle, 0.5f);
        }

        private void AnimateWheels()
        {
            UpdateAnimateWheels(frontLeft, frontLeftTransform);
            UpdateAnimateWheels(frontRight, frontRightTransform);
            UpdateAnimateWheels(rearLeft, rearLeftTransform);
            UpdateAnimateWheels(rearRight, rearRightTransform);
        }

        private void UpdateAnimateWheels(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }
    }
}
