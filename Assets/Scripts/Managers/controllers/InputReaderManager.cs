using UnityEngine;

namespace Managers.controllers
{
    public class InputReaderManager
    {
        public InputReaderManager()
        {
            Debug.Log("<color=yellow> Input Reader created</color>");
        }
        public Vector3? GetInputFromKeyboard()
        {
            Vector3? _receive = null;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (_receive != null)
                    _receive = _receive + Vector3.up;
                else
                    _receive = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (_receive != null)
                    _receive = _receive + Vector3.down;
                else
                    _receive = Vector3.down;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (_receive != null)
                    _receive = _receive + Vector3.left;
                else
                    _receive = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                if (_receive != null)
                    _receive = _receive + Vector3.right;
                else
                    _receive = Vector3.right;
            }

            return _receive;
        }
    }
}
