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

        private EntityStateType currentState;

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
            set { life = value; }
        }
    }
}