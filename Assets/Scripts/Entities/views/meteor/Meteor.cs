using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.impl;
using Entities.views.player;

namespace Entities.views.meteor
{
    public class Meteor : Entity
    {
        [SerializeField]
        private float speedMove = 0.1f;

        [SerializeField]
        private int damage = 20;

        private void OnEnable()
        {
            StateType = enums.EntityStateType.LIVE;
        }

        private void Update()
        {
            if (StateType != enums.EntityStateType.DIED)
            {
                this.transform.position += Vector3.forward * (speedMove * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Entity _entObj = other.gameObject.GetComponent<Player>();
            if (_entObj != null)
            {
                Debug.Log("COLLIDED TO " + _entObj.MyName);
                ((Player)_entObj).ApplyDamage(damage);
                Die();
            }
        }

        public override void Die()
        {
            base.Die();
            
            DestroyImmediate(this.gameObject);
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}