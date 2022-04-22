using UnityEngine;
using Weapons;

namespace Weapons.controllers
{
    public class LowImpactFire : Weapon
    {
        public override void Action()
        {
            var _fireInterval = WeaponData.FireIntervalTime;
            if(CanShoot)
            {
                StartCoroutine(CoroutineFireInterval());
                CreateBullet();
            }
        }

        public override void CreateBullet()
        {
            base.CreateBullet();
        }
    }
}