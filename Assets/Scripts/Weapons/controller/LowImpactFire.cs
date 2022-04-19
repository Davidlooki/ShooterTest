using UnityEngine;
using Weapons;

namespace Weapons.controllers
{
    public class LowImpactFire : Weapon
    {
        private Bullet bullet;

        private float reloadTimeSpent = 0;

        private bool onReload = false;

        public override void Process()
        {
            var _fireInterval = WeaponData.FireIntervalTime;
            // StartCoroutine(FireInterval(_fireInterval));
            // if(CanShoot && !onReload)
            Debug.Log("WEAPON PROCESS");
            //CreateBullet();
        }

        private void Reload()
        {
            onReload = true;
        }

        private void CreateBullet()
        {
            GameObject _bulletInstance = Instantiate(bullet.gameObject, this.transform);
        }
    }
}
