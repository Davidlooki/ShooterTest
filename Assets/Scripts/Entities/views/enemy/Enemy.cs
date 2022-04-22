using System;
using UnityEngine;
using Entities.impl;
using Entities.enums;
using Managers.controllers;
using Weapons;

namespace Entities.views.enemy
{
    public class Enemy : Entity
    {
        [SerializeField]
        private float speedMove = 0.1f;

        protected Weapon currentWeapon;

        public static event Action OnNotifyEnemyDie;

        private void OnEnable()
        {
            StateType = EntityStateType.LIVE;
            
            currentWeapon = this.GetComponent<Weapon>();
            currentWeapon.Action();
        }


        private void Update()
        {
            if (StateType == enums.EntityStateType.LIVE)
            {
                this.transform.position += this.transform.forward * (speedMove * Time.deltaTime);
            }
        }
        
        public override void ApplyDamage(int _damage)
        {
            base.ApplyDamage(_damage);

            if(Life <= 0)
            {
                Die();
            }
            else
            {
                StateType = EntityStateType.LIVE;
            }
        }

        public override void Die()
        {
            base.Die();
            
            if(OnNotifyEnemyDie != null)
                OnNotifyEnemyDie();
            
            PoolManager.Instance.DisableObject(this.gameObject);

            GameManager.Instance.PullObjectInScene();
        }
    }
}
