using System.Collections;
using System.Collections.Generic;
using CMGA.Shooter.Controllers.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace CMGA.Shooter.Controllers{

    public class SpaceshipController : MonoBehaviour
    {
        public float xySpeed;
        public float lookSpeed;
        public Transform shipModel;
        public Transform aimTarget;
        public Joystick JoystickLandscape;
        public Joystick JoystickPortrait;
        public HealthController HealthController;

        private void Start(){
            HealthController.Init();
        }
        private void Update()
        {
            var isPortrait = Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown;
            
            var joystick = isPortrait ? JoystickPortrait : JoystickLandscape;

            float h = joystick.Direction.x;
            float v = joystick.Direction.y;

            LocalMove(h, v, xySpeed);
            RotationLook(h,v, lookSpeed);
            HorizontalLean(shipModel, h, 80, .1f);
        }

        private void LocalMove(float x, float y, float speed)
        {
            transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
            ClampPosition();
        }

        private void ClampPosition()
        {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        private void RotationLook(float h, float v, float speed)
        {
            aimTarget.parent.position = Vector3.zero;
            aimTarget.localPosition = new Vector3(h, v, 1);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * speed * Time.deltaTime);
        }

        private void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
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

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy")){
                HealthController.TakeDamage(other.GetComponent<Enemy>().BaseDamage);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("Enemy")){
                HealthController.TakeDamage(other.gameObject.GetComponent<Enemy>().BaseDamage);
            }
        }
    }
}