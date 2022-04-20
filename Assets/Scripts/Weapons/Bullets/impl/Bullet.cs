using System.Collections;
using UnityEngine;
using Weapons;

namespace Weapons.Bullets.impl
{
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        [SerializeField]
        [Range(5, 35)]
        private int damage = 20;

        [SerializeField]
        private float lifespan = 1;

        #region Getters/Settters
        public Vector3 Target { get; set; }
        public float ForceSpeed { get; set; }
        private float Lifespan { get { return lifespan; } }
        public float DamageValue { get { return damage; } }
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

        public void ApplyDamage()
        {
            //TODO - NOTIFY the Observer object with the object got hit
            Debug.Log("GET HIT");
            DestroyBullet();
        }

        public virtual void DestroyBullet()
        {
            DestroyImmediate(this.gameObject);
        }
        private void OnCollisionEnter(Collision other)
        {
            //TODO - if the OTHER is different from PARENT
            ApplyDamage();
        }

        private void OnDestroy()
        {
            StopCoroutine(CoroutineLifespan());
        }
    }
}