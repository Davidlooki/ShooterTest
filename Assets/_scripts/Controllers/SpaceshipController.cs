using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CMGA.Shooter.Controllers{

    public class SpaceshipController : MonoBehaviour
    {
        public float xySpeed;
        public float lookSpeed;
        public Transform shipModel;
        public Transform aimTarget;

        void Update()
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            LocalMove(h, v, xySpeed);
            RotationLook(h,v, lookSpeed);
            HorizontalLean(shipModel, h, 80, .1f);
        }

        void LocalMove(float x, float y, float speed)
        {
            transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
            ClampPosition();
        }

        void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        void RotationLook(float h, float v, float speed)
        {
            aimTarget.parent.position = Vector3.zero;
            aimTarget.localPosition = new Vector3(h, v, 1);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
        }

        void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
        {
            Vector3 targetEulerAngels = target.localEulerAngles;
            target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(aimTarget.position, .5f);
            Gizmos.DrawSphere(aimTarget.position, .15f);

        }
    }
}