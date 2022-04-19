using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private WeaponDataSO weaponData;

        protected Bullet bullet;

        private bool canShoot = true;

        private float currentFireInterval = 0;

        #region GETTERS/SETTERS
        public WeaponDataSO WeaponData => weaponData;

        public bool CanShoot
        {
            get { return canShoot; }
            set { canShoot = value; }
        }
        #endregion

        private void Awake()
        {
            if (WeaponData != null)
            {
                bullet = weaponData.GetBullet;
            }
        }

        public IEnumerator CoroutineFireInterval()
        {
            currentFireInterval = WeaponData.FireIntervalTime;
            canShoot = false;
            while (currentFireInterval >= 0)
            {
                currentFireInterval -= Time.deltaTime;
                yield return null;
            }
            canShoot = true;
        }

        public virtual void CreateBullet()
        {
            if (bullet != null)
            {
                GameObject _bulletInstance = Instantiate(bullet.gameObject);
                
                Vector3 _offsetPosition = this.transform.position + (Vector3.forward * .5f);

                _bulletInstance.transform.SetPositionAndRotation(_offsetPosition, this.transform.rotation);

                _bulletInstance.GetComponent<Bullet>().Target = Vector3.forward * 10;
                _bulletInstance.GetComponent<Bullet>().ForceSpeed = WeaponData.ForceSpeed;
            }
        }

        private void OnDestroy() 
        {
            StopCoroutine(CoroutineFireInterval());
        }

        public abstract void Action();
    }
}
