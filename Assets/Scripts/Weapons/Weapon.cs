using System.Collections;
using UnityEngine;

namespace Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField]
        private WeaponDataSO weaponData;

        private int currentAmmo = 0;

        private bool canShoot = true;

        public IEnumerator FireInterval(float _fireInterval)
        {
            while (_fireInterval != 0)
            {
                canShoot = false;
                _fireInterval -= Time.deltaTime;
                yield return null;
            }
            canShoot = true;
        }

        public WeaponDataSO WeaponData => weaponData;

        public bool CanShoot
        {
            get { return canShoot; }
            set { canShoot = value; }
        }

        public abstract void Process();
    }
}
