using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine;
using Weapons.Bullets.impl;

namespace Weapons.serializable
{
    [CreateAssetMenu(menuName = "Shooter Test/Weapon/Weapon Data")]
    public class WeaponDataSO : ScriptableObject
    {
        [SerializeField]
        private string weaponName;

        [SerializeField]
        private float forceSpeed;

        [SerializeField]
        private float fireIntervalTime = .2f;

        [SerializeField]
        private Bullet bulletObject;

        #region GETTERS
        public Bullet GetBullet => bulletObject;
        public float FireIntervalTime => fireIntervalTime;
        public float ForceSpeed => forceSpeed;
        public string WeaponName => weaponName;
        #endregion
    }

}