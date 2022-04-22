using System;
using System.Collections;
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

        [SerializeField]
        private float lifeSpan = 15;

        private bool wasKilled = false;

        public static event Action OnNotifyMeteorDie;


        private void Start() 
        {

        }

        private void OnEnable()
        {
            wasKilled = false;
            StateType = enums.EntityStateType.LIVE;

            StartCoroutine(CoroutineLifeSpan(lifeSpan));
        }

        private void Update()
        {
            if (StateType != enums.EntityStateType.DIED)
            {
                this.transform.position += this.transform.forward * (speedMove * Time.deltaTime);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Entity _entObj = other.gameObject.GetComponent<Player>();
            if (_entObj != null)
            {
                ((Player)_entObj).ApplyDamage(damage);
                Die();
            }
        }

        public IEnumerator CoroutineLifeSpan(float lifeSpan)
        {
            float _progress = lifeSpan;
            while (_progress > 0)
            {
                _progress -= Time.deltaTime;
                yield return null;
            }
            Die();
        }
        public override void Die()
        {
            base.Die();

            if (wasKilled)
            {
                if (OnNotifyMeteorDie != null)
                {
                    OnNotifyMeteorDie();
                }
            }
            StopCoroutine("CoroutineLifeSpan");
            PoolManager.Instance.DisableObject(this.gameObject);
            GameManager.Instance.PullObjectInScene();
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}