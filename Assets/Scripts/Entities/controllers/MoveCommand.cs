using UnityEngine;
using Internal.Command.impl;

namespace Entities.controllers
{
    public class MoveCommand : Command
    {
        public float speed;
        public Vector3 direction;
        public MoveCommand(IEntity _entity, Vector3 _newDirection, float _speed = 0.001f) 
                        : base(_entity)
        {
            speed = _speed;
            direction = _newDirection;
        }

        public override void Execute()
        {
            entity.transform.position += direction * speed;
        }
    }
}
