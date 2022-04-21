using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.impl;
using Entities.enums;
using Managers.controllers;
using Weapons;
using Weapons.Bullets.impl;

namespace Entities.views.enemy
{
    public class Enemy : Entity
    {
        [SerializeField]
        private float speedMove = 0.1f;

        [SerializeField]
        Weapon currentWeapon;

        private void OnEnable()
        {
            StateType = EntityStateType.LIVE;
            currentWeapon = this.GetComponent<Weapon>();
        }

        private void Update()
        {
            if (StateType == enums.EntityStateType.LIVE)
            {
                this.transform.position += Vector3.forward * (speedMove * Time.deltaTime);
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
            
            if(UIManager.Instance)
                UIManager.Instance.InGame.SetStrongEnemyKills(1);

            DestroyImmediate(this.gameObject);
        }
    }
}
