using UnityEngine;
using Entities;
using Entities.enums;

namespace Entities.impl
{
    public abstract class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        private string myName;

        [SerializeField]
        private int life = 3;

        public Transform entityTransform { get; set; }

        protected EntityStateType stateType;

        public virtual void Awake()
        {
            entityTransform = this.transform;
        }

        public string MyName
        {
            get { return myName; }
            set { myName = value; }
        }

        public int Life
        {
            get { return life; }
            protected set { life = value; }
        }

        public virtual void ApplyDamage(int _damage)
        {
            if (StateType == EntityStateType.LIVE)
                StateType = EntityStateType.HIT;

            Life -= _damage;
        }

        public virtual void Die()
        {
            StateType = enums.EntityStateType.DIED;
        }

        public EntityStateType StateType
        {
            get { return stateType; }
            set { stateType = value; }
        }
    }
}