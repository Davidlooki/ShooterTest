using System.Collections;
using UnityEngine;

using Entities.impl;
using Entities.views.enemy;
using Entities.views.meteor;

namespace Weapons.Bullets.impl
{
    public class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField]
        [Range(5, 500)]
        private int damage = 20;

        [SerializeField]
        private float lifespan = 1;

        #region Getters/Settters
        public Vector3 Target { get; set; }
        public float ForceSpeed { get; set; }
        private float Lifespan { get { return lifespan; } }
        public int DamageValue { get { return damage; } }
        #endregion

        private void OnEnable()
        {
            StartCoroutine(CoroutineLifespan());
        }

        public IEnumerator CoroutineLifespan()
        {
            float currLifespan = Lifespan;
            while (currLifespan >= 0)
            {
                currLifespan -= Time.deltaTime;
                Move();
                yield return null;
            }

            DestroyBullet();
        }

        public void Move()
        {
            this.transform.position += Vector3.forward * (Time.deltaTime * ForceSpeed);
        }

        public virtual void DestroyBullet()
        {
            Destroy(this.gameObject);
        }
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Collided with " + other.transform.name);
            Entity _collided = other.gameObject.GetComponent<Entity>();
            
            if(_collided != null)
                _collided.ApplyDamage(DamageValue);

            DestroyBullet();
        }

        private void OnDestroy()
        {
            StopCoroutine(CoroutineLifespan());
        }
    }
}