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

        private EntityStateType stateType;

        public virtual void Awake()
        {
            entityTransform = this.transform;
        }

        public string MyName
        {
            get { return myName; }
        }

        public int Life
        {
            get { return life; }
            protected set { life = value; }
        }

        public EntityStateType StateType
        {
            get { return stateType; }
            set { stateType = value; }
        }
    }
}