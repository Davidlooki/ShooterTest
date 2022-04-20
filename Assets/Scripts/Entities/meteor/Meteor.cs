using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities.impl;
using Entities.player;

namespace Entities.meteor
{
    public class Meteor : Entity
    {
        [SerializeField]
        private float speedMove = 0.1f;

        [SerializeField]
        private int damage = 20;

        Entity _entity;

        private void OnEnable()
        {
            StateType = enums.EntityStateType.LIVE;
            _entity = FindObjectOfType<Player>();
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
                ((Player)_entity).ApplyDamage(damage);
                Die();
            }
        }

        private void Die()
        {
            StateType = enums.EntityStateType.DIED;
            DestroyImmediate(this.gameObject);
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}