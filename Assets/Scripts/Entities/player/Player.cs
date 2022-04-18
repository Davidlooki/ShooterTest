using UnityEngine;
using Entities.controllers;

namespace Entities.player
{
    public class Player : MonoBehaviour, IEntity
    {

        protected InputReaderManager readerInput;

        protected void Awake() 
        {
            readerInput = new InputReaderManager();    
        }

        // Update is called once per frame
        void Update()
        {
            Vector3? _receivedDirection = readerInput.GetInputFromKeyboard();
            if(_receivedDirection != null)
            {
                MoveCommand _moveCommand = new MoveCommand(this, (Vector3)_receivedDirection);
                _moveCommand.Execute();
            }
        }
    }
}
