using UnityEngine;
using Entities;
using Entities.enums;

namespace Entities.impl
{
    public abstract class Entity : MonoBehaviour, IEntity
    {
        [SerializeField]
        private string myName;

        private int live = 3;

        public Transform entityTransform { get; set; }

        private EntityStateType currentState;

        public virtual void Awake()
        {
            entityTransform = this.transform;
        }

        public string GetMyName
        {
            get { return myName; }
        }


        public int Live
        {
            get { return live; }
            set { live = value; }
        }
    }
}