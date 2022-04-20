using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public interface IBullet
    {
        IEnumerator CoroutineLifespan();
        void Move();
        void ApplyDamage();
        void DestroyBullet();
    }

}