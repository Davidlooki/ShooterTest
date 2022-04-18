using UnityEngine;
using Entities;

namespace Internal.Command.impl
{
    public abstract class Command : ICommand
    {
        protected IEntity entity;       

        public Command(IEntity _entity)
        {
            entity = _entity;
        }

        public virtual void Execute()
        {

        }
    }
}