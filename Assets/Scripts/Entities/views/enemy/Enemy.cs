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

        protected Weapon currentWeapon;

        private void OnEnable()
        {
            StateType = EntityStateType.LIVE;
            currentWeapon = this.GetComponent<Weapon>();
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
            
            if(UIManager.Instance)
                UIManager.Instance.InGame.SetStrongEnemyKills(1);
            //TODO - ON PollManager enable that object
            Destroy(this.gameObject);
        }
    }
}
